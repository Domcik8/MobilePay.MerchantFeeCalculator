﻿using Domain.InvoiceFees.Base;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.InvoiceFees.Rules
{
    /// <summary>
    /// Add invoice fixed fee only to first transaction in the month.
    /// </summary>
    public class FirstMonthlyInvoiceFeeRuleDecorator : BaseInvoiceFeeDecorator
    {
        /// <summary>
        /// Month for which the fee is being calculated.
        /// </summary>
        private DateTime FeeMonth = DateTime.MinValue;

        private List<string> IssuedMonthlyFees = new List<string>();

        public FirstMonthlyInvoiceFeeRuleDecorator(BaseInvoiceFeeService invoiceFeeService)
            : base(invoiceFeeService) { }

        public override void CalculateInvoiceFee(Transaction transaction)
        {
            if (IsNewFeeMonth(transaction))
                UpdateFeeMonth(transaction);

            if (HasFeeBeenPaid(transaction))
                return;

            IssuedMonthlyFees.Add(transaction.MerchantName);

            base.CalculateInvoiceFee(transaction);
        }

        private bool IsNewFeeMonth(Transaction transaction)
        {
            return !(transaction.Date.Month == FeeMonth.Month && transaction.Date.Year == FeeMonth.Year);
        }

        private void UpdateFeeMonth(Transaction transaction)
        {
            IssuedMonthlyFees.Clear();
            FeeMonth = transaction.Date;
        }

        private bool HasFeeBeenPaid(Transaction transaction)
        {
            return IssuedMonthlyFees.Contains(transaction.MerchantName);
        }
    }
}