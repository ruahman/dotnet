using System;
namespace SampleShop.Events
{
    public class TransactionProcessedEventArgs : EventArgs
    {
        public decimal Amount { get; set; }

        public TransactionType TransactionType;

        public TransactionProcessedEventArgs(decimal amount, TransactionType transactionType)
        {
            Amount = amount;
            TransactionType = transactionType;
        }
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
}
