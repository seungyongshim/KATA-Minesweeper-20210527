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

        [Fact]
        public void NearBombsCount()
        {
            // Arrange
            var cell = new Cell();

            // Act
            cell.NearBombsCount = 7;

            // Assert
            cell.ToString().Should().Be("7");
        }

        [Fact]
        public void IsCover()
        {
            // Arrange
            var cell = new Cell();

            // Act

            // Assert
            cell.ToString().Should().Be(".");
        }
    }
}
