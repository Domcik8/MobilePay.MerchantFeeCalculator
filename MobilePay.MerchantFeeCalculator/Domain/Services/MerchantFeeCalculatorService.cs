﻿using Domain.InvoiceFees.Base;
using Domain.Repositories;
using Domain.TransactionFees.Base;
using System;

namespace Domain.Services
{
    public class MerchantFeeCalculatorService : IMerchantFeeCalculatorService
    {
        ITransactionRepository TransactionRepository { get; }
        BaseTransactionFeeService TransactionFeeService { get; }
        BaseInvoiceFeeService InvoiceFeeService { get; }

        public MerchantFeeCalculatorService(
            ITransactionRepository transactionRepository,
            BaseTransactionFeeService transactionFeeService,
            BaseInvoiceFeeService invoiceFeeService)
        {
            TransactionRepository = transactionRepository;
            TransactionFeeService = transactionFeeService;
            InvoiceFeeService = invoiceFeeService;
        }

        public void CalculateFees()
        {
            while (TransactionRepository.HasUnhandledTransactions())
            {
                var transaction = TransactionRepository.GetTransaction();
                if (transaction == null)
                {
                    Console.WriteLine();
                    continue;
                }

                TransactionFeeService.CalculateTransactionFee(transaction);
                InvoiceFeeService.CalculateInvoiceFee(transaction);

                Console.WriteLine($"{transaction.Date:d} {transaction.MerchantName,-8} {transaction.Fee:f2}");
            }
        }
    }
}
