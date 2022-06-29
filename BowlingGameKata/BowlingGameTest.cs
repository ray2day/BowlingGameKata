using System;
using Xunit;

namespace BowlingGameKata
{
    /// <summary>
    /// HINTS:
    /// At a minimum you'll want to use the following tests:
    /// Test for all gutterballs(knocked down 0 pins for the entire game.Total Score == 0)
    /// Test for knocking down 1 pin each time(Total Score == 20)
    /// Test a perfect game(knocked down 10 pins each throw, Total Score == 300)
    /// </summary>
    public class BowlingGameTest
    {
        private Game g;

        public BowlingGameTest()
        {
            g = new Game();
        }

        [Fact]
        public void TestBowlingGameClass()
        {
            Assert.IsType<Game>(g);
        }

        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);

            Assert.Equal(0, g.Score());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);

            Assert.Equal(20, g.Score());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            g.Roll(3);

            RollMany(17, 0);

            Assert.Equal(16, g.Score());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);

            RollMany(16, 0);

            Assert.Equal(24, g.Score());
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12, 10);

            Assert.Equal(300, g.Score());
        }


        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }
    }
}
