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
            int intTransactionsID = 0;

            //Add the list of Transactions
            List<Transaction> Transactions = new List<Transaction>();

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 1),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A1,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 0, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A2,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 0, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A3,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 0, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A4,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 0, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A5,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 0, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B1,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 0, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B2,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 0, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B3,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 0, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B4,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 0, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B5,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 0, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 5),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A1,
                        MoviePrice = 10.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 16, 30, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A2,
                        MoviePrice = 10.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 16, 30, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A3,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 16, 30, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A4,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 16, 30, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A5,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 16, 30, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B1,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 16, 30, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B2,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 16, 30, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B3,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 16, 30, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B4,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 16, 30, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B5,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 16, 30, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C2,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 00, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C3,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 00, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 14),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C4,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 00, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C5,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 23, 11, 00, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 5),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "franco@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A1,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "wchang@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A2,
                        MoviePrice = 10.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 14),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A3,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A4,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 5),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "shdixon@aoll.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A5,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B1,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 14),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B2,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B3,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 5),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B4,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Cancelled,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B5,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 14),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "elowe@netscare.net")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E1,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E2,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E3,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E4,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E5,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C4,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 20),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C5,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 24, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.D1,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A2,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A3,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A4,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "franco@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A5,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "wchang@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B1,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B2,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Cancelled,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "shdixon@aoll.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B3,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B4,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B5,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E1,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Cancelled,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E2,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "elowe@netscare.net")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E3,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E4,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E5,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C4,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C5,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 21, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.D1,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A2,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A3,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 1),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A4,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                     new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A5,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                      new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B1,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B2,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B3,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B4,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 1),
                PurchaseStatus = PurchaseStatus.Cancelled,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B5,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E1,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 1),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E2,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E3,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 1),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E4,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E5,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C4,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C5,
                        MoviePrice = 15.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 19, 30, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 1),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B2,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 12, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B3,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 12, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B4,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 12, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 1),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B5,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 12, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });
            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 1),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "franco@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E1,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 12, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E2,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 12, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 1),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "wchang@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E3,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 12, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E4,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 12, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 1),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E5,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 12, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 15),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E5,
                        MoviePrice = 12.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 25, 9, 00, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 24),
                PurchaseStatus = PurchaseStatus.Cancelled,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.A4,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 27, 11, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E1,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 27, 11, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E2,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 27, 11, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E3,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 27, 11, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E4,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 27, 11, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.E5,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 27, 11, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B3,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 27, 11, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B4,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 27, 11, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.B5,
                        MoviePrice = 5.00m,
                        PaymentMethod = PaymentMethod.CashCard,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 11, 27, 11, 00, 0) && ds.Theatre == Theatre.Theatre1)?.ScheduleID ?? default(int)
                    },
                }
            });

            Transactions.Add(new Transaction
            {
                TransactionDate = new DateTime(2023, 11, 26),
                PurchaseStatus = PurchaseStatus.Purchased,
                UserID = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com")?.Id ?? string.Empty,
                TransactionDetail = new List<TransactionDetail>
                {
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C3,
                        MoviePrice = 0.00m,
                        PaymentMethod = PaymentMethod.Points,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 12, 4, 22, 00, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                    new TransactionDetail
                    {
                        NumberOfTickets = 1,
                        SeatSelection = SeatSelection.C4,
                        MoviePrice = 0.00m,
                        PaymentMethod = PaymentMethod.Points,
                        ScheduleID = db.Schedules.FirstOrDefault(ds => ds.StartTime == new DateTime(2023, 12, 4, 22, 00, 0) && ds.Theatre == Theatre.Theatre2)?.ScheduleID ?? default(int)
                    },
                }
            });

            try
            {
                // Loop through each of the Transactions in the list
                foreach (Transaction TransactionsToAdd in Transactions)
                {
                    // Set the flag to the current title to help with debugging
                    intTransactionsID = TransactionsToAdd.TransactionID;

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
                        dbTransactions.PurchaseStatus = TransactionsToAdd.PurchaseStatus;

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
                String msg = "  Repositories added:" + intTransactionsAdded + "; Error on " + intTransactionsID;

                // Throw the exception with the new message
                throw new InvalidOperationException(ex.Message + msg);
            }
        }
    }
}