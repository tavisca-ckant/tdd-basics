using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private int[] GenerateArray (int value, int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = value;
            return array;
        }

        [Fact]
        public void AllStrike()
        {
            var actual = Game.CalculateFinalScore(GenerateArray(10, 12));
            var expected = 300;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AllSpare()
        {
            var actual = Game.CalculateFinalScore(GenerateArray(5, 21));
            var expected = 150;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ZeroScore()
        { 
            var actual = Game.CalculateFinalScore(GenerateArray(0, 20));
            var expected = 0;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ZeroSpareZeroStrike()
        { 
            var actual = Game.CalculateFinalScore(new[] { 3, 2, 4, 2, 3, 2, 4, 3, 1, 3, 4, 3, 2, 1, 2, 1, 2, 1, 6, 1 });
            var expected = 50;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnlySpareZeroStrike()
        { 
            var actual = Game.CalculateFinalScore(new[] { 3, 2, 4, 4, 3, 2, 5, 5, 3, 2, 5, 5, 3, 2, 5, 5, 3, 2, 5, 5, 6 });
            var expected = 88;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ZeroSpareOnlyStrike()
        { 
            var actual = Game.CalculateFinalScore(new[] { 3, 2, 10, 3, 2, 10, 2, 2, 10, 3, 2, 10, 3, 2, 10, 3, 3 });
            var expected = 99;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LastFrameAllStrike()
        {
            var actual = Game.CalculateFinalScore(new[] { 3, 1, 6, 3, 2, 6, 1, 2, 6, 3, 1, 6, 3, 2, 2, 3, 3, 2, 10, 10, 10 });
            var expected = 85;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RandomSpareRandomStrike()
        {
            var actual = Game.CalculateFinalScore(new[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 });
            var expected = 187;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InputMoreThanRange() 
        {
             
            Assert.Throws<IndexOutOfRangeException>(() => Game.CalculateFinalScore(new[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10, 2, 3 }));
        }

        [Fact]
        public void InputLessThanRange()   
        {  
            Assert.Throws<ArgumentException>(() => Game.CalculateFinalScore(new[] { 10, 9, 1, 5, 5, 9, 1, 10, 2, 3 }));
        }

        [Fact]
        public void WrongInput()   
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Game.CalculateFinalScore(new[] { 10, 10, 10, 12, 10, 10, 10, 10, 10, 10, 10, 10 }));
        }

        [Fact]
        public void MaximumStrike()  
        { 
            Assert.Throws<ArgumentOutOfRangeException>(() => Game.CalculateFinalScore(GenerateArray(10, 13)));
        }
    }
}
