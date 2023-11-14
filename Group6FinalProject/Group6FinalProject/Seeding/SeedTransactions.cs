using Microsoft.AspNetCore.Identity;
using Group_6_Final_Project.Utilities;
using Group_6_Final_Project.DAL;
using Group_6_Final_Project.Models;
using Microsoft.SqlServer.Server;
using static System.Reflection.Metadata.BlobBuilder;

namespace Group_6_Final_Project.Seeding
{
    public static class SeedTransactions
    {
        public static void Transaction(AppDbContext db)
        {
            //Create a counter and a flag so we will know which record is causing problems
            Int32 intTransactionsAdded = 0;
            int intTransactionsTransactionID = 0;

            //Add the list of Transactions
            List<Transaction> Transactions = new List<Transaction>();

            Transactions.Add(new Transaction
            {
                TransactionID = 1,
                TransactionDate = new DateTime(2023, 11, 1),
                NumberofTickets = 10,
                //PopcornPoints = 50,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 2,
                TransactionDate = new DateTime(2023, 11, 5),
                NumberofTickets = 10,
                //PopcornPoints = 116,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 3,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 2,
                //PopcornPoints = 10,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 4,
                TransactionDate = new DateTime(2023, 11, 14),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 5,
                TransactionDate = new DateTime(2023, 11, 5),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 6,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 10,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 7,
                TransactionDate = new DateTime(2023, 11, 14),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 8,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 9,
                TransactionDate = new DateTime(2023, 11, 5),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 10,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 11,
                TransactionDate = new DateTime(2023, 11, 14),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 12,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 13,
                TransactionDate = new DateTime(2023, 11, 5),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 14,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Cancelled"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 15,
                TransactionDate = new DateTime(2023, 11, 14),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 16,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 17,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 18,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 19,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 20,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 21,
                TransactionDate = new DateTime(2023, 11, 20),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 22,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 23,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 24,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 25,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 26,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 27,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 28,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 29,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Cancelled"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 30,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 9,
                //PopcornPoints = 45,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 31,
                TransactionDate = new DateTime(2023, 11, 26),
                NumberofTickets = 2,
                //PopcornPoints = -200,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 32,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 33,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Cancelled"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 34,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 35,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 36,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 37,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 38,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 1,
                //PopcornPoints = 15,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 39,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 2,
                //PopcornPoints = 30,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 40,
                TransactionDate = new DateTime(2023, 11, 1),
                NumberofTickets = 6,
                //PopcornPoints = 90,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 41,
                TransactionDate = new DateTime(2023, 11, 1),
                NumberofTickets = 2,
                //PopcornPoints = 30,
                Status = "Cancelled"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 42,
                TransactionDate = new DateTime(2023, 11, 1),
                NumberofTickets = 2,
                //PopcornPoints = 30,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 43,
                TransactionDate = new DateTime(2023, 11, 1),
                NumberofTickets = 4,
                //PopcornPoints = 60,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 44,
                TransactionDate = new DateTime(2023, 11, 1),
                NumberofTickets = 3,
                //PopcornPoints = 36,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 45,
                TransactionDate = new DateTime(2023, 11, 1),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 46,
                TransactionDate = new DateTime(2023, 11, 1),
                NumberofTickets = 2,
                //PopcornPoints = 24,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 47,
                TransactionDate = new DateTime(2023, 11, 1),
                NumberofTickets = 2,
                //PopcornPoints = 20,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 48,
                TransactionDate = new DateTime(2023, 11, 1),
                NumberofTickets = 1,
                //PopcornPoints = 10,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 49,
                TransactionDate = new DateTime(2023, 11, 15),
                NumberofTickets = 1,
                //PopcornPoints = 12,
                Status = "Purchased"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 50,
                TransactionDate = new DateTime(2023, 11, 24),
                NumberofTickets = 9,
                //PopcornPoints = 45,
                Status = "Cancelled"
            });

            Transactions.Add(new Transaction
            {
                TransactionID = 51,
                TransactionDate = new DateTime(2023, 11, 26),
                NumberofTickets = 2,
                //PopcornPoints = -200,
                Status = "Purchased"
            });


            try
            {
                // Loop through each of the Transactions in the list
                foreach (Transaction TransactionsToAdd in Transactions)
                {
                    // Set the flag to the current title to help with debugging
                    intTransactionsTransactionID = TransactionsToAdd.TransactionID;

                    // Look to see if the Transactions is in the database - this assumes that no
                    // two Transactions have the same title
                    Transaction dbTransactions = db.Transactions.FirstOrDefault(b => b.TransactionID == TransactionsToAdd.TransactionID);


                    // If dbTransactions is null, this title is not in the database
                    if (dbTransactions == null)
                    {
                        // Add the Transactions to the database and save changes
                        db.Transactions.Add(TransactionsToAdd);
                        db.SaveChanges();

                        // Update the counter to help with debugging
                        intTransactionsAdded += 1;
                    }
                    else // dbTransactions is not null - this title *is* in the database
                    {
                        // Update all of the Transactions's properties
                        dbTransactions.TransactionDate = TransactionsToAdd.TransactionDate;
                        dbTransactions.NumberofTickets = TransactionsToAdd.NumberofTickets;
                        //dbTransactions.//PopcornPoints = TransactionsToAdd.//PopcornPoints;
                        dbTransactions.Status = TransactionsToAdd.Status;

                        // Update the database and save the changes
                        db.Update(dbTransactions);
                        db.SaveChanges();

                        // Update the counter to help with debugging
                        intTransactionsAdded += 1;
                    } // This is the end of the else
                } // This is the end of the foreach loop for the Transactions
            }// This is the end of the try block

            catch (Exception ex) // Something went wrong with adding or updating
            {
                // Build a message using the flags we created
                String msg = "  Repositories added:" + intTransactionsAdded + "; Error on " + intTransactionsTransactionID;

                // Throw the exception with the new message
                throw new InvalidOperationException(ex.Message + msg);
            }
        }
    }
}