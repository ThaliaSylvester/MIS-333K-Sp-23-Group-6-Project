using Microsoft.AspNetCore.Identity;
using Group_6_Final_Project.Utilities;
using Group_6_Final_Project.DAL;
using Group_6_Final_Project.Models;
using Microsoft.SqlServer.Server;
using static System.Reflection.Metadata.BlobBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Group_6_Final_Project.Seeding
{
    public static class SeedTransactionDetails
    {
        public static void TransactionDetails(AppDbContext db)
        {
            // Create a counter and a flag to know which record is causing problems
            int intTransactionDetailsAdded = 0;
            string strTransactionDetailsID = "Begin";

            // Add the list of TransactionDetails
            List<TransactionDetail> transactionDetails = new List<TransactionDetail>();

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "1",
                TransactionID = "1",
                SeatSelection = SeatSelection.A1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "1",
                TransactionID = "2",
                SeatSelection = SeatSelection.A2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "1",
                TransactionID = "3",
                SeatSelection = SeatSelection.A3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "1",
                TransactionID = "4",
                SeatSelection = SeatSelection.A4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "1",
                TransactionID = "5",
                SeatSelection = SeatSelection.A5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "1",
                TransactionID = "6",
                SeatSelection = SeatSelection.B1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "1",
                TransactionID = "7",
                SeatSelection = SeatSelection.B2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "1",
                TransactionID = "8",
                SeatSelection = SeatSelection.B3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "1",
                TransactionID = "9",
                SeatSelection = SeatSelection.B4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "1",
                TransactionID = "10",
                SeatSelection = SeatSelection.B5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "2",
                TransactionID = "1",
                SeatSelection = SeatSelection.A1,
                SeniorTicket = true,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "2",
                TransactionID = "2",
                SeatSelection = SeatSelection.A2,
                SeniorTicket = true,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "2",
                TransactionID = "3",
                SeatSelection = SeatSelection.A3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "2",
                TransactionID = "4",
                SeatSelection = SeatSelection.A4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "2",
                TransactionID = "5",
                SeatSelection = SeatSelection.A5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "2",
                TransactionID = "6",
                SeatSelection = SeatSelection.B1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "2",
                TransactionID = "7",
                SeatSelection = SeatSelection.B2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "2",
                TransactionID = "8",
                SeatSelection = SeatSelection.B3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "2",
                TransactionID = "9",
                SeatSelection = SeatSelection.B4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "2",
                TransactionID = "10",
                SeatSelection = SeatSelection.B5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "3",
                TransactionID = "1",
                SeatSelection = SeatSelection.C2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "3",
                TransactionID = "2",
                SeatSelection = SeatSelection.C3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "4",
                TransactionID = "1",
                SeatSelection = SeatSelection.C4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "4",
                TransactionID = "2",
                SeatSelection = SeatSelection.C5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "5",
                TransactionID = "1",
                SeatSelection = SeatSelection.A1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "6",
                TransactionID = "1",
                SeatSelection = SeatSelection.A2,
                SeniorTicket = true,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "7",
                TransactionID = "1",
                SeatSelection = SeatSelection.A3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "8",
                TransactionID = "1",
                SeatSelection = SeatSelection.A4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "9",
                TransactionID = "1",
                SeatSelection = SeatSelection.A5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "10",
                TransactionID = "1",
                SeatSelection = SeatSelection.B1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "11",
                TransactionID = "1",
                SeatSelection = SeatSelection.B2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "12",
                TransactionID = "1",
                SeatSelection = SeatSelection.B3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "13",
                TransactionID = "1",
                SeatSelection = SeatSelection.B4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "14",
                TransactionID = "1",
                SeatSelection = SeatSelection.B5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "15",
                TransactionID = "1",
                SeatSelection = SeatSelection.E1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "16",
                TransactionID = "1",
                SeatSelection = SeatSelection.E2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "17",
                TransactionID = "1",
                SeatSelection = SeatSelection.E3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "18",
                TransactionID = "1",
                SeatSelection = SeatSelection.E4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "19",
                TransactionID = "1",
                SeatSelection = SeatSelection.E5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "20",
                TransactionID = "1",
                SeatSelection = SeatSelection.C4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "21",
                TransactionID = "1",
                SeatSelection = SeatSelection.C5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "22",
                TransactionID = "1",
                SeatSelection = SeatSelection.D1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "23",
                TransactionID = "1",
                SeatSelection = SeatSelection.A2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "24",
                TransactionID = "1",
                SeatSelection = SeatSelection.A3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "25",
                TransactionID = "1",
                SeatSelection = SeatSelection.A4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "26",
                TransactionID = "1",
                SeatSelection = SeatSelection.A5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "27",
                TransactionID = "1",
                SeatSelection = SeatSelection.B1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "28",
                TransactionID = "1",
                SeatSelection = SeatSelection.B2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "29",
                TransactionID = "1",
                SeatSelection = SeatSelection.B3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "30",
                TransactionID = "1",
                SeatSelection = SeatSelection.B4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "31",
                TransactionID = "1",
                SeatSelection = SeatSelection.B5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "32",
                TransactionID = "1",
                SeatSelection = SeatSelection.E1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "33",
                TransactionID = "1",
                SeatSelection = SeatSelection.E2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "34",
                TransactionID = "1",
                SeatSelection = SeatSelection.E3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "35",
                TransactionID = "1",
                SeatSelection = SeatSelection.E4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "36",
                TransactionID = "1",
                SeatSelection = SeatSelection.E5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "37",
                TransactionID = "1",
                SeatSelection = SeatSelection.C4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "38",
                TransactionID = "1",
                SeatSelection = SeatSelection.C5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "39",
                TransactionID = "1",
                SeatSelection = SeatSelection.D1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "39",
                TransactionID = "2",
                SeatSelection = SeatSelection.A2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "39",
                TransactionID = "3",
                SeatSelection = SeatSelection.A3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "40",
                TransactionID = "1",
                SeatSelection = SeatSelection.A4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "40",
                TransactionID = "2",
                SeatSelection = SeatSelection.A5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "40",
                TransactionID = "3",
                SeatSelection = SeatSelection.B1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "40",
                TransactionID = "4",
                SeatSelection = SeatSelection.B2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "40",
                TransactionID = "5",
                SeatSelection = SeatSelection.B3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "40",
                TransactionID = "6",
                SeatSelection = SeatSelection.B4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "41",
                TransactionID = "1",
                SeatSelection = SeatSelection.B5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "41",
                TransactionID = "2",
                SeatSelection = SeatSelection.E1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "42",
                TransactionID = "1",
                SeatSelection = SeatSelection.E2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "42",
                TransactionID = "2",
                SeatSelection = SeatSelection.E3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "43",
                TransactionID = "1",
                SeatSelection = SeatSelection.E4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "43",
                TransactionID = "2",
                SeatSelection = SeatSelection.E5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "43",
                TransactionID = "3",
                SeatSelection = SeatSelection.C4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "43",
                TransactionID = "4",
                SeatSelection = SeatSelection.C5,
                SeniorTicket = false,
                CashCard = true
            });

            // Continue adding more TransactionDetail objects for the new data sets
            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "44",
                TransactionID = "1",
                SeatSelection = SeatSelection.B2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "44",
                TransactionID = "2",
                SeatSelection = SeatSelection.B3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "44",
                TransactionID = "3",
                SeatSelection = SeatSelection.B4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "45",
                TransactionID = "1",
                SeatSelection = SeatSelection.B5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "46",
                TransactionID = "1",
                SeatSelection = SeatSelection.E1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "46",
                TransactionID = "2",
                SeatSelection = SeatSelection.E2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "47",
                TransactionID = "1",
                SeatSelection = SeatSelection.E3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "47",
                TransactionID = "2",
                SeatSelection = SeatSelection.E4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "48",
                TransactionID = "1",
                SeatSelection = SeatSelection.E5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "49",
                TransactionID = "1",
                SeatSelection = SeatSelection.E5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "50",
                TransactionID = "1",
                SeatSelection = SeatSelection.A4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "50",
                TransactionID = "2",
                SeatSelection = SeatSelection.E1,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "50",
                TransactionID = "3",
                SeatSelection = SeatSelection.E2,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "50",
                TransactionID = "4",
                SeatSelection = SeatSelection.E3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "50",
                TransactionID = "5",
                SeatSelection = SeatSelection.E4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "50",
                TransactionID = "6",
                SeatSelection = SeatSelection.E5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "50",
                TransactionID = "7",
                SeatSelection = SeatSelection.B3,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "50",
                TransactionID = "8",
                SeatSelection = SeatSelection.B4,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "50",
                TransactionID = "9",
                SeatSelection = SeatSelection.B5,
                SeniorTicket = false,
                CashCard = true
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "51",
                TransactionID = "1",
                SeatSelection = SeatSelection.C3,
                SeniorTicket = false,
                CashCard = false
            });

            transactionDetails.Add(new TransactionDetail
            {
                TransactionDetailID = "51",
                TransactionID = "2",
                SeatSelection = SeatSelection.C4,
                SeniorTicket = false,
                CashCard = false
            });

            try
            {
                // Loop through each of the TransactionDetails in the list
                foreach (TransactionDetail TransactionDetailsToAdd in transactionDetails)
                {
                    // Set the flag to the current title to help with debugging
                    strTransactionDetailsID = TransactionDetailsToAdd.TransactionDetailID;

                    // Look to see if the TransactionDetails is in the database - this assumes that no
                    // two TransactionDetails have the same title
                    TransactionDetail dbTransactionDetails = db.transactionDetails.FirstOrDefault(b => b.TransactionDetailID == TransactionDetailsToAdd.TransactionDetailID);

                    if (dbTransactionDetails == null)
                    {
                        // TransactionDetails not in the database, so add it
                        db.transactionDetails.Add(TransactionDetailsToAdd);
                    }
                    else
                    {
                        // TransactionDetails is in the database, so update its properties
                        dbTransactionDetails.TransactionDetailID = TransactionDetailsToAdd.TransactionDetailID;
                        dbTransactionDetails.TransactionID = TransactionDetailsToAdd.TransactionID;
                        dbTransactionDetails.SeatSelection = TransactionDetailsToAdd.SeatSelection;
                        dbTransactionDetails.SeniorTicket = TransactionDetailsToAdd.SeniorTicket;
                        dbTransactionDetails.CashCard = TransactionDetailsToAdd.CashCard;
                    }

                    // Save changes to the database
                    db.SaveChanges();

                    // Update the counter to help with debugging
                    intTransactionDetailsAdded++;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                string msg = "TransactionDetails added: " + intTransactionDetailsAdded + "; Error on " + strTransactionDetailsID;
                throw new InvalidOperationException(ex.Message + msg);
            }
        }
    }
}
