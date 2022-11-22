using System;
using SampleShop.Events;
using SampleShop.Interfaces;

namespace SampleShop.Services
{
    public class TransactionService : ITransactionService
    {

        public event EventHandler<TransactionProcessedEventArgs> OnTransactionProcessed;

        /// <summary>
        /// Processes a deposit and sends an event to every subsciber holding the amount and transactiontype.
        /// amount must be larger than 0.
        /// </summary>
        public void MakeDeposit(decimal amount)
        {
            // TODO
            // Implement method, should call ProcessDeposit with the right amount
            // Method should check if amount is larger than 0 else
            // throw an ArgumentOutOfRangeException. 
            // Method should send an event to every subsciber holding the amount and transactiontype.

            if (amount > 0)
            {
                ProcessDeposit(amount);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        /// <summary>
        /// Processes a withdrawal and sends an event to every subsciber holding the amount and transactiontype.
        /// amount must be larger than 0.
        /// </summary>
        public void MakeWithdrawal(decimal amount)
        {
            // TODO
            // Implement method, should call ProcessWithdrawal and ProcessDeposit both with the right amount
            // Method should check if amount is larger than 0 else
            // throw an ArgumentOutOfRangeException. 
            // Method should send an event to every subsciber holding the amount and transactiontype.

            if (amount > 0)
            {
                ProcessWithdrawal(amount);
                //ProcessDeposit(amount);  that doesn't make any sence!!!
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            //throw new NotImplementedException();
        }

        private void ProcessDeposit(decimal amount)
        {
            // Processing logic not necessary for exam
            OnTransactionProcessed?.Invoke(this, new TransactionProcessedEventArgs(amount, TransactionType.Deposit));
        }

        private void ProcessWithdrawal(decimal amount)
        {
            // Processing logic not necessary for exam
            OnTransactionProcessed?.Invoke(this, new TransactionProcessedEventArgs(amount, TransactionType.Withdrawal));
        }
    }
}
