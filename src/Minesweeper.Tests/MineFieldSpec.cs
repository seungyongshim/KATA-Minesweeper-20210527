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
            sut.Cells.Select(x => x.IsBomb)
                     .Count()
                     .Should().Be(3);
        }
    }
}
