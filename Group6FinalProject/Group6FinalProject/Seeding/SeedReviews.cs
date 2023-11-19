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
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "Jurassic Park")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Five,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net")?.Id ?? string.Empty,
                Description = "Best Movie I've ever seen.",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Secret Life of Walter Mitty")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Four,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com")?.Id ?? string.Empty,
                Description = "Not bad.",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "Jurassic Park")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Five,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                Description = "Changed my life",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Goonies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Five,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "franco@example.com")?.Id ?? string.Empty,
                Description = "Great family adventure Movie",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Goonies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Four,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "wchang@example.com")?.Id ?? string.Empty,
                Description = "Good Movie",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Goonies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.One,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com")?.Id ?? string.Empty,
                Description = "Worst thing I've ever seen",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Goonies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Five,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                Description = "Reminded me of my summers in the NW",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Goonies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Five,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "shdixon@aoll.com")?.Id ?? string.Empty,
                Description = "I love a good treasure hunt!",
                Status = Status.NeedsReview,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Goonies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Three,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org")?.Id ?? string.Empty,
                Description = "Meh",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Hobbit: The Battle of Five Armies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Four,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com")?.Id ?? string.Empty,
                Description = " ",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Hobbit: The Battle of Five Armies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Four,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                Description = " ",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Hobbit: The Battle of Five Armies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Five,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net")?.Id ?? string.Empty,
                Description = " ",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Hobbit: The Battle of Five Armies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Five,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "franco@example.com")?.Id ?? string.Empty,
                Description = " ",
                Status = Status.Approved,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Hobbit: The Battle of Five Armies")?.MovieID,
                Rating = CustomerRating.One,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "wchang@example.com")?.Id ?? string.Empty,
                Description = "Too long",
                Status = Status.NeedsReview,
            });

            Reviews.Add(new Review
            {
                MovieID = db.Movies.FirstOrDefault(m => m.Title == "The Hobbit: The Battle of Five Armies")?.MovieID ?? string.Empty,
                Rating = CustomerRating.Two,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com")?.Id ?? string.Empty,
                Description = "Did they really need to drag this out into its own Movie?",
                Status = Status.NeedsReview,
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
                        dbReviews.Rating = ReviewsToAdd.Rating;
                        dbReviews.Description = ReviewsToAdd.Description;
                        dbReviews.Status = ReviewsToAdd.Status;
                        dbReviews.MovieID = ReviewsToAdd.MovieID;
                        dbReviews.UserID = ReviewsToAdd.UserID;

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