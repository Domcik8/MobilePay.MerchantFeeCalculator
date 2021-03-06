﻿using Domain.TransactionFees.Base;
using Domain.TransactionFees.MerchantPercentageDiscounts.Base;

namespace Domain.TransactionFees.MerchantPercentageDiscounts
{
    /// <summary>
    /// Add transaction fee percentage discount for Circle K.
    /// </summary>
    public class CircleKPercentageDiscountDecorator : BaseMerchantPercentageDiscountDecorator
    {
        private const string CircleKMerchantName = "CIRCLE_K";
        private const decimal CircleKFeeDiscountPercentage = 0.2m;

        public CircleKPercentageDiscountDecorator(BaseTransactionFeeService transactionFeeService)
            : base(transactionFeeService, CircleKMerchantName, CircleKFeeDiscountPercentage) { }
    }
}
