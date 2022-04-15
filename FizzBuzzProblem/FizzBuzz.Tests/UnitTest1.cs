using FizzBuzz.Models;
using FizzBuzz.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace FizzBuzz.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ProcessResult_Returns_Result()
        {
            ProcessFizBuzz fizbuzz = new ProcessFizBuzz();
            string commaseparatedInputString = "A,1,3,5,5";
            IDictionary<string[], ProcessResult> processResult = fizbuzz.ProcessAndReturn(commaseparatedInputString);
            Assert.True(processResult!=null);
        }

        [Fact]
        public void ProcessResult_Matches_Records_Returned()
        {
            ProcessFizBuzz fizbuzz = new ProcessFizBuzz();
            string commaseparatedInputString = "A,1,3,5,5";
            IDictionary<string[], ProcessResult> processResult = fizbuzz.ProcessAndReturn(commaseparatedInputString);
            Assert.True(processResult.Count == commaseparatedInputString.Split(",").Length);
        }

        [Fact]
        public void ProcessResult_Throws_Exception()
        {
            ProcessFizBuzz fizbuzz = new ProcessFizBuzz();
            string commaseparatedInputString = null;
            Assert.Throws<NullReferenceException>(() => fizbuzz.ProcessAndReturn(commaseparatedInputString));
        }
    }
}