using Microsoft.AspNetCore.Identity;
using Group_6_Final_Project.Utilities;
using Group_6_Final_Project.DAL;
using Group_6_Final_Project.Models;
using Microsoft.SqlServer.Server;
using static System.Reflection.Metadata.BlobBuilder;

namespace Group_6_Final_Project.Seeding
{
    public static class SeedReviews
    {
        public static void Reviews(AppDbContext db)
        {
            //Create a counter and a flag so we will know which record is causing problems
            Int32 intReviewsAdded = 0;
            Int32 intReviewsTitle = 0;

            //Add the list of Reviews
            List<Review> Reviews = new List<Review>();

            Reviews.Add(new Review
            {
                //Movie = "Jurassic Park",
                Rating = CustomerRating.Five,
                //Customer = "Michelle",
                Description = "Best Movie I've ever seen.",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Secret Life of Walter Mitty",
                Rating = CustomerRating.Four,
                //Customer = "Christopher",
                Description = "Not bad.",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "Jurassic Park",
                Rating = CustomerRating.Five,
                //Customer = "Brad",
                Description = "Changed my life",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Goonies",
                Rating = CustomerRating.Five,
                //Customer = "Franco",
                Description = "Great family adventure Movie",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Goonies",
                Rating = CustomerRating.Four,
                //Customer = "Wendy",
                Description = "Good Movie",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Goonies",
                Rating = CustomerRating.One,
                //Customer = "Lim",
                Description = "Worst thing I've ever seen",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Goonies",
                Rating =CustomerRating.Five,
                //Customer = "Brad",
                Description = "Reminded me of my summers in the NW",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Goonies",
                Rating = CustomerRating.Five,
                //Customer = "Shan",
                Description = "I love a good treasure hunt!",
                Status = "Needs Review"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Goonies",
                Rating = CustomerRating.Three,
                //Customer = "Jim Bob",
                Description = "Meh",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Hobbit: The Battle of Five Armies",
                Rating = CustomerRating.Four,
                //Customer = "Christopher",
                Description = "",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Hobbit: The Battle of Five Armies",
                Rating = CustomerRating.Four,
                //Customer = "Brad",
                Description = "",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Hobbit: The Battle of Five Armies",
                Rating = CustomerRating.Five,
                //Customer = "Michelle",
                Description = "",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Hobbit: The Battle of Five Armies",
                Rating = CustomerRating.Five,
                //Customer = "Franco",
                Description = "",
                Status = "Approved"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Hobbit: The Battle of Five Armies",
                Rating = CustomerRating.One,
                //Customer = "Wendy",
                Description = "Too long",
                Status = "Needs Review"
            });

            Reviews.Add(new Review
            {
                //Movie = "The Hobbit: The Battle of Five Armies",
                Rating = CustomerRating.Two,
                //Customer = "Lim",
                Description = "Did they really need to drag this out into its own Movie?",
                Status = "Needs Review"
            });


            try  //attempt to add or update the Reviews
            {
                //loop through each of the Reviews in the list
                foreach (Review ReviewsToAdd in Reviews)
                {
                    //set the flag to the current title to help with debugging
                    intReviewsTitle = ReviewsToAdd.ReviewID;

                    //look to see if the Reviews is in the database - this assumes that no
                    //two Reviews have the same title
                    Review dbReviews = db.Reviews.FirstOrDefault(b => b.ReviewID == ReviewsToAdd.ReviewID);

                    //if the dbReviews is null, this title is not in the database
                    if (dbReviews == null)
                    {
                        //add the Reviews to the database and save changes
                        db.Reviews.Add(ReviewsToAdd);
                        db.SaveChanges();

                        //update the counter to help with debugging
                        intReviewsAdded += 1;
                    }
                    else //dbReviews is not null - this title *is* in the database
                    {
                        //update all of the Reviews's properties
                        //dbReviews.//Movie = ReviewsToAdd.//Movie;
                        dbReviews.Rating = ReviewsToAdd.Rating;
                        //dbReviews.//Customer = ReviewsToAdd.//Customer;
                        dbReviews.Description = ReviewsToAdd.Description;
                        dbReviews.Status = ReviewsToAdd.Status;

                        //update the database and save the changes
                        db.Update(dbReviews);
                        db.SaveChanges();

                        //update the counter to help with debugging
                        intReviewsAdded += 1;
                    } //this is the end of the else
                } //this is the end of the foreach lo op for the Reviews
            }//this is the end of the try block

            catch (Exception ex)//something went wrong with adding or updating
            {
                //Build a messsage using the flags we created
                String msg = "  Repositories added:" + intReviewsAdded + "; Error on " + intReviewsTitle;

                //throw the exception with the new message
                throw new InvalidOperationException(ex.Message + msg);
            }
        }
    }
}