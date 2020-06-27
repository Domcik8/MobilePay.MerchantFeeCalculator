﻿using Application.InvoiceFees.Rules;
using Application.TransactionFees;
using Domain;
using FluentAssertions;
using System;
using Xunit;

namespace Application.UnitTests.InvoiceFees.Rules
{
    public class FirstMonthlyInvoiceFixedFeeDecoratorTests
    {
        [Fact]
        public void CalculateMerchantFee_ForMoreThenOneMonthlyTransactions_ShouldNotIncludeInvoiceFee()
        {
            // Arrange
            var transaction1 = new Transaction { Date = new DateTime(2018, 09, 02), MerchantName = "7-Eleven", Fee = 1 };
            var transaction2 = new Transaction { Date = new DateTime(2018, 09, 05), MerchantName = "Netto", Fee = 1 };
            var transaction3 = new Transaction { Date = new DateTime(2018, 10, 22), MerchantName = "7-Eleven", Fee = 1 };
            var transaction4 = new Transaction { Date = new DateTime(2018, 10, 29), MerchantName = "7-Eleven", Fee = 1 };

            var expected1 = transaction1.Fee + InvoiceFixedFeeService.StandardInvoiceFixedFee;
            var expected2 = transaction2.Fee + InvoiceFixedFeeService.StandardInvoiceFixedFee;
            var expected3 = transaction3.Fee + InvoiceFixedFeeService.StandardInvoiceFixedFee;
            var expected4 = transaction4.Fee;

            var invoiceFeeService = new InvoiceFixedFeeService();
            var sut = new FirstMonthlyInvoiceFixedFeeDecorator(invoiceFeeService);

            // Act
            sut.CalculateMerchantFee(transaction1);
            var actual1 = transaction1.Fee;

            sut.CalculateMerchantFee(transaction2);
            var actual2 = transaction2.Fee;

            sut.CalculateMerchantFee(transaction3);
            var actual3 = transaction3.Fee;

            sut.CalculateMerchantFee(transaction4);
            var actual4 = transaction4.Fee;

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
            actual3.Should().Be(expected3);
            actual4.Should().Be(expected4);
        }
    }
}