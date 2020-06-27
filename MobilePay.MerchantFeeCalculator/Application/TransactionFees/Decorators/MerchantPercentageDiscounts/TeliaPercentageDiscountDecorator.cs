﻿using Application.TransactionFees.Decorators.MerchantPercentageDiscounts.Base;

namespace Application.TransactionFees.MerchantPercentageDiscounts
{
    public class TeliaPercentageDiscountDecorator : BaseMerchantPercentageDiscountDecorator
    {
        private const string TeliaMerchantName = "TELIA";
        private const decimal TeliaFeeDiscountPercentage = 0.1m;

        public TeliaPercentageDiscountDecorator(
            BaseTransactionFeeService transactionFeeService)
            : base(transactionFeeService, TeliaMerchantName, TeliaFeeDiscountPercentage) { }
    }
}