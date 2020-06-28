﻿using Domain.Models;

namespace Domain.TransactionFees.Base
{
    public abstract class BaseTransactionFeeService
    {
        public abstract void CalculateTransactionFee(Transaction transaction);
    }
}
