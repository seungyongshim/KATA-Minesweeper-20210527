using System;
using FluentAssertions;
using Xunit;

namespace Minesweeper.Tests
{
    public class CellSpec
    {
        [Fact]
        public void IsBomb()
        {
            // Arrange
            var cell = new Cell();

            // Act
            cell.SetBomb();

            // Assert
            cell.ToString().Should().Be("*");
        }
    }
}
