using System;
using Xunit;
using Moq;
using Order.Management;

namespace OrderManagementTests
{
    public class ReportTests
    {
        [Theory]
        [InlineData(1, "-")]
        [InlineData(5, "-----")]
        [InlineData(-2, "")]
        public void ReportTest_InvoiceReport_PrintLineTableWidth(int tableWidth, string assertExpected)
        {
            //Arrange
            var mock = new Mock<Report>();
            mock.Object.tableWidth = tableWidth;

            //Act
            var writeLineOutput = mock.Object.PrintLine(mock.Object.tableWidth);

            //Assert
            Assert.Equal(assertExpected, writeLineOutput);

        }
    }
}
