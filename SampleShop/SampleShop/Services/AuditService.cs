using System;
using SampleShop.Events;
using SampleShop.Interfaces;

namespace SampleShop.Services
{
    public class AuditService : IAuditService
    {
        //TODO
        // Make sure the Logger is added using Dependency Injection

        private readonly ILogger _logger;
        public AuditService(ILogger log)
        {
            _logger = log;
        }

        protected void TransactionProcessedEventHandler(object sender, TransactionProcessedEventArgs e)
        {
            _logger.WriteToLog($"AUDIT LOG: {e.TransactionType} for ${e.Amount} processed");
        }

        /// <summary>
        /// Subscribes to TransactionService's OnTransactionProcessed and writes to log.
        /// </summary>
        public void Subscribe(ITransactionService transactionService)
        {
            // TODO
            // Implement method that subscribes to TransactionService's OnTransactionProcessed
            // and writes the following string to log:
            //       'AUDIT LOG: TransactionType for $100 processed'
            // where TransactionType must be changed to the TransactionType used in the event
            // and 100 must be changed to the amount used in the event
            //throw new NotImplementedException();

            transactionService.OnTransactionProcessed += TransactionProcessedEventHandler;
        }




    }
}
