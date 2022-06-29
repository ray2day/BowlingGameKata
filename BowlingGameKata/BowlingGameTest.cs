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

            Assert.Equal(0, g.Score);
        }


        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);

            Assert.Equal(20, g.Score);
        }

        //public void TestOneSpare()

        //public void TestOneStrike()

        // public void TestPerfectGame()

        // etc..


        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }
    }
}
