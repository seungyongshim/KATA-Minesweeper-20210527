using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Minesweeper.Tests
{
    public class MineFieldSpec
    {
        [Fact]
        public void Constucture()
        {
            // Arrange
            var sut = new MineField(3, 3);

            // Act

            // Assert
            sut.Cells.Count().Should().Be(9);
        }

        [Fact]
        public void GenerateBombs()
        {
            // Arrange
            var sut = new MineField(3, 3);

            // Act
            sut.GenerateBombs(3);

            // Assert
            sut.Cells.Where(x => x.IsBomb)
                     .Count()
                     .Should().Be(3);
        }

        [Fact]
        public void CalculatedNearBombsCount()
        {
            // Arrange
            var sut = new MineField(3, 3);
            sut.Cells[0].SetBomb();
            sut.Cells[2].SetBomb();

            // Act
            sut.CalculatedNearBombsCount();

            // Assert
            sut.Cells.Select(x => x.NearBombsCount)
                     .Should()
                     .BeEquivalentTo(0, 2, 0,
                                     1, 2, 1,
                                     0, 0, 0);
        }

        [Fact]
        public void Click()
        {
            // Arrange
            var sut = new MineField(3, 3);
            sut.Cells[0].SetBomb();
            sut.CalculatedNearBombsCount();

            // Act
            sut.Click(2, 2);

            // Assert
            sut.Cells.Select(x => x.ToString())
                     .Should()
                     .BeEquivalentTo(".", "1", "0",
                                     "1", "1", "0",
                                     "0", "0", "0");
        }
    }
}
