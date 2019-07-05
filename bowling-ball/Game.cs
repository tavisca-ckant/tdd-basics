using System;

namespace BowlingBall
{
    public class Game
    {
        public static void Main(string[] args)
        {
            var pinScoresArray = ToIntArray(args);
            Console.WriteLine(Game.CalculateFinalScore(pinScoresArray));
        }

        private static int[] ToIntArray(string[] arr)
        {
            int[] intArray = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                intArray[i] = int.Parse(arr[i]);
            return intArray;
        }

        public static int CalculateFinalScore(int[] pins)
        {
            CheckInput(pins);
            int[] frameScore = new int[10];
            int frameIndex = 0;
            int score = 0;

            for (int i = 0; i < pins.Length - 2; i++)
            {

                var isStrike = (pins[i] == 10);
                var isSpare = (pins[i] + pins[i + 1] == 10);
                var isNormalScore = (pins[i] + pins[i + 1] < 10);

                if (isStrike)
                {
                    frameScore[frameIndex++] = StrikeScore(pins, score, i);
                }
                else if (isSpare)
                {
                    frameScore[frameIndex++] = SpareScore(pins, score, i);
                    i++;
                }

                if (isNormalScore)
                {
                    frameScore[frameIndex++] = NormalScore(pins, score, i);
                    i++;
                    var isLastFrame = (i == pins.Length - 3);
                    if (isLastFrame)
                    {
                        score = frameScore[frameIndex - 1];
                        frameScore[frameScore.Length - 1] = NormalScore(pins, score, i + 1);
                    }
                }

                score = frameScore[frameIndex - 1];
            }
            return frameScore[9];
        }

        private static int NormalScore(int[] pins, int score, int i)
        {
            score += pins[i] + pins[i + 1];
            return score;
        }

        private static int StrikeScore(int[] pins, int score, int i)
        {
            score += pins[i] + pins[i + 1] + pins[i + 2];
            return score;
        }

        private static int SpareScore(int[] pins, int score, int i)
        {
            score += pins[i] + pins[i + 1] + pins[i + 2];
            return score;
        }

        public static void CheckInput(int[] pins)
        {
            int strikesCount = 0;

            CheckPinsLength(pins);

            strikesCount = CheckScoreOfEachPin(pins, strikesCount);

            CheckNumberOfStrikes(strikesCount);

            CheckScoreOfEachFrame(pins);

        }

        private static void CheckPinsLength(int[] pins)
        {
            if (pins.Length > 21 || pins.Length < 12)
                throw new ArgumentException("Input must be from 12 to 21 inclusive");
        }

        private static int CheckScoreOfEachPin(int[] pins, int strikesCount)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                if (pins[i] < 0 || pins[i] > 10)
                    throw new ArgumentOutOfRangeException("i", "Pins can be from 0 to 10");
                if (pins[i] == 10)
                    strikesCount++;
            }
            return strikesCount;
        }

        private static void CheckScoreOfEachFrame(int[] pins)
        {
            for (int i = 0; i < pins.Length - 1; i++)
            {
                if (pins[i] == 10)
                    continue;
                if (pins[i] + pins[i + 1] > 10)
                    throw new ArgumentException("Single frame can have max of 10 pins to bowl");
                i++;
            }
        }

        private static void CheckNumberOfStrikes(int strikesCount)
        {
            if (strikesCount > 12)
                throw new ArgumentOutOfRangeException("strikesCount", "Max Strikes can be 12 in a Game");
        }
    }
}
