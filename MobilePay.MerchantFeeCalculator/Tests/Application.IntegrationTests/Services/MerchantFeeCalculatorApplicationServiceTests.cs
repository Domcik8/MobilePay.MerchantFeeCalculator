﻿using Application.Services;
using FluentAssertions;
using System;
using System.IO;
using Xunit;

namespace Application.IntegrationTests.Services
{
    public class MerchantFeeCalculatorApplicationServiceTests
    {
        [Fact]
        public void CalculateFeesTest_WithTransactionsFile_ShouldWriteExpectedConsoleOutput()
        {
            // Arrange
            using StreamReader expectedOutput = new StreamReader("Expected.Result.txt");
            var expected = expectedOutput.ReadToEnd();

            using StringWriter actualOutput = new StringWriter();
            Console.SetOut(actualOutput);

            var sut = new MerchantFeeCalculatorApplicationService();

            // Act
            sut.CalculateFees();
            var actual = actualOutput.ToString();

            // Assert
            expected.Should().Be(actual);
        }
    }
}
