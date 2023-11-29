using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Group_6_Final_Project.DAL;
using Group_6_Final_Project.Models;
using Group_6_Final_Project.Utilities;
using System;
using Microsoft.EntityFrameworkCore;

namespace Group_6_Final_Project.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly PasswordValidator<AppUser> _passwordValidator;
        private readonly AppDbContext _context;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _context = appDbContext;
            _userManager = userManager;
            _signInManager = signIn;
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel rvm)
        {
            //if registration data is valid, create a new user on the database
            if (ModelState.IsValid == false)
            {
                //this is the sad path - something went wrong, 
                //return the user to the register page to try again
                return View(rvm);
            }

            //this code maps the RegisterViewModel to the AppUser domain model
            AppUser newUser = new AppUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber,
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                DateOfBirth = rvm.DateOfBirth,
                AddressLine1 = rvm.AddressLine1,
                AddressLine2 = rvm.AddressLine2,
                City = rvm.City,
                State = rvm.State,
                Zip = rvm.Zip
            };

            //Create AddUserModel
            AddUserModel aum = new AddUserModel()
            {
                User = newUser,
                Password = rvm.Password,

                // You will need to change this value if you want to 
                //add the user to a different role - just specify the role name.
                RoleName = "Customer"
            };

            //This code uses the AddUser utility to create a new user with the specified password
            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded) //everything is okay
            {
                //NOTE: This code logs the user into the account that they just created
                //You may or may not want to log a user in directly after they register - check
                //the business rules!
                Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, false, lockoutOnFailure: false);

                //Send the user to the home page
                return RedirectToAction("Index", "Home");
            }
            else  //the add user operation didn't work, and we need to show an error message
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send user back to page with errors
                return View(rvm);
            }
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl; //pass along the page the user should go back to
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel lvm, string returnUrl)
        {
            //if user forgot to include user name or password,
            //send them back to the login page to try again
            if (lvm.Email == null || lvm.Password == null)
            {
                Console.WriteLine(lvm.Email);
                Console.WriteLine(lvm.Password);
                return View(lvm);
            }
            Console.WriteLine("I succeeded!");

            //attempt to sign the user in using the SignInManager
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);

            //if the login worked, take the user to either the url
            //they requested OR the homepage if there isn't a specific url
            if (result.Succeeded)
            {
                //return ?? "/" means if returnUrl is null, substitute "/" (home)
                return Redirect(returnUrl ?? "/");
            }
            else //log in was not successful
            {
                //add an error to the model to show invalid attempt
                ModelState.AddModelError("", "Invalid login attempt.");
                //send user back to login page to try again
                return View(lvm);
            }
        }

        public IActionResult AccessDenied()
        {
            return View("Error", new string[] { "You are not authorized for this resource" });
        }

        //GET: Account/Index
        public IActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            // Get user info
            String id = User.Identity.Name;
            AppUser user = _context.Users
                                   .Include(u => u.Transactions) // Include transactions for popcorn points calculation
                                   .FirstOrDefault(u => u.UserName == id);

            if (user != null)
            {
                // Populate the view model
                ivm.Email = user.Email;
                ivm.HasPassword = true; 
                ivm.UserID = user.Id;
                ivm.UserName = user.UserName;
                ivm.FirstName = user.FirstName;
                ivm.LastName = user.LastName;
                ivm.PhoneNumber = user.PhoneNumber;
                ivm.DateOfBirth = user.DateOfBirth;
                ivm.AddressLine1 = user.AddressLine1;
                ivm.AddressLine2 = user.AddressLine2;
                ivm.City = user.City;
                ivm.State = user.State;
                ivm.Zip = user.Zip;

                // Calculate total popcorn points
                ivm.TotalPopcornPoints = user.Transactions?.Sum(t => t.PopcornPoints) ?? 0;
            }
            else
            {
                // Handle the case where the user is not found, possibly redirect or show an error
                return RedirectToAction("ErrorViewNameHere"); // Replace with appropriate action
            }

            // Send data to the view
            return View(ivm);
        }


        //Logic for change password
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel cpvm)
        {
            //if user forgot a field, send them back to 
            //change password page to try again
            if (ModelState.IsValid == false)
            {
                return View(cpvm);
            }

            //Find the logged in user using the UserManager
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            //Attempt to change the password using the UserManager
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, cpvm.OldPassword, cpvm.NewPassword);

            //if the attempt to change the password worked
            if (result.Succeeded)
            {
                //sign in the user with the new password
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);

                //send the user back to the home page
                return RedirectToAction("Index", "Home");
            }
            else //attempt to change the password didn't work
            {
                //Add all the errors from the result to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send the user back to the change password page to try again
                return View(cpvm);
            }
        }

        // GET: Account/Edit
        public IActionResult EditProfile()
        {
            // Get user information
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            // Map AppUser properties to EditProfileViewModel
            EditProfileViewModel editProfileViewModel = new EditProfileViewModel
            {
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                State = user.State,
                Zip = user.Zip
            };

            return View(editProfileViewModel);
        }

        //POST: Account/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditProfileViewModel epvm)
        {
            if (ModelState.IsValid == false)
            {
                return View(epvm);
            }

            // Find user
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            // Update properties
            user.PhoneNumber = epvm.PhoneNumber;
            user.DateOfBirth = epvm.DateOfBirth;
            user.AddressLine1 = epvm.AddressLine1;
            user.AddressLine2 = epvm.AddressLine2;
            user.City = epvm.City;
            user.State = epvm.State;
            user.Zip = epvm.Zip;

            // Update in database
            IdentityResult result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(epvm);
            }
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            //sign the user out of the application
            _signInManager.SignOutAsync();

            //send the user back to the home page
            return RedirectToAction("Index", "Home");
        }

        
    }
}