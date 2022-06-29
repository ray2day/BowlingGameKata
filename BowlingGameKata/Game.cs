using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class Game
    {
        private int[] _rolls;
        private int _currentRoll;

        public Game()
        {
            _rolls = new int[21];
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score = StrikeBonus(score, frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score = SpareBonus(score, frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score = SumOfBallsInFrame(score, frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private int SumOfBallsInFrame(int score, int frameIndex)
        {
            score += _rolls[frameIndex] + _rolls[frameIndex + 1];
            return score;
        }

        private int SpareBonus(int score, int frameIndex)
        {
            score += 10 + _rolls[frameIndex + 2];
            return score;
        }

        private int StrikeBonus(int score, int frameIndex)
        {
            score += 10 + _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
            return score;
        }

        private bool IsSpare(int i)
        {
            return _rolls[i] + _rolls[i + 1] == 10;
        }

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }
    }
}
