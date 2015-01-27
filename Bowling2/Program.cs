using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;

namespace Bowling2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileIn init = new FileIn();
            BowlingFrame[] frames = new BowlingFrame[10];
            int index = 0; 
            

            int [] scores = init.getScores();

            for (int i = 0; i < 10; i++)
            {
                if (scores[index] == 10)
                {
                    frames[i] = new StrikeFrame(scores[index], scores[index + 1], scores[index + 2]);
                    Console.WriteLine("The Frame {0} Score: {1}", i + 1 , frames[i].GetFrameScore());
                    index++;
                    

                }
                else if ((scores[index] + scores[index + 1]) == 10)
                {
                    frames[i] = new SpareFrame(scores[index], scores[index + 1], scores[index + 2]);
                    Console.WriteLine("The Frame {0} Score: {1}", i + 1, frames[i].GetFrameScore());
                    index += 2;
                }
                else
                {
                    frames[i] = new OpenFrame(scores[index], scores[index + 1]);
                    Console.WriteLine("The Frame {0} Score: {1}", i + 1, frames[i].GetFrameScore());
                    index += 2;
                }
            }

            CalculateGameScore gameScore = new CalculateGameScore(frames);

            Console.WriteLine("The total game score is : " + gameScore.GetGameScore());

            Console.ReadLine();
        }
    }

    class FileIn
    {
        string _file = "Bowling.txt";
        int[] scores = new int[21];
        Char[] _whitespace = null;

        public FileIn()
        {
            
            Console.WriteLine("Please enter a file name or press 1 to use sample data.");
            string input = Console.ReadLine();

            if (input != "1")
                _file = input;

            StreamReader bowlingStreamReader = new StreamReader(_file);
            string line = bowlingStreamReader.ReadToEnd();

            var temp = line.Split(_whitespace, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < temp.Length; i++)
            {
                scores[i] = Convert.ToInt32(temp[i]);
            }

         }

        public int[] getScores()
        {
            return scores;
        }
    }

    public abstract class BowlingFrame
    {
        private int ballOne;
        private int ballTwo;
        private int frameScore;
        public abstract void ScoreFrame(int i, int j, int k);

        public abstract int GetFrameScore();
    }


    class OpenFrame : BowlingFrame
    {
        private int ballOne = 0;
        private int ballTwo = 0;
        private int frameScore = 0;

        public OpenFrame(int b1, int b2)
        {
            ballOne = b1;
            ballTwo = b2; 
            ScoreFrame(ballOne, ballTwo, 0);
        }


        public override void ScoreFrame(int ballOne, int ballTwo, int ballThree = 0)
        {
            frameScore = ballOne + ballTwo;
        }

        public override int GetFrameScore()
        {
            return frameScore;
        }

    }

    class StrikeFrame : BowlingFrame
    {
        private int ballOne = 0;
        private int ballTwo = 0;
        private int ballThree = 0;
        private int frameScore = 0;

        public StrikeFrame(int b1, int b2, int b3)
        {
            ballOne = b1;
            ballTwo = b2;
            ballThree = b3;
            ScoreFrame(ballOne, ballTwo, ballThree);
        }

        public override void ScoreFrame(int b1, int b2, int b3)
        {
 
            frameScore = ballOne + ballTwo + ballThree;
        }


        public override int GetFrameScore()
        {
            return frameScore;
        }
    }

    class SpareFrame : BowlingFrame
    {
        private int ballOne = 0;
        private int ballTwo = 0;
        private int ballThree = 0;
        private int frameScore = 0;

        public SpareFrame(int b1, int b2, int b3)
        {
            ballOne = b1;
            ballTwo = b2;
            ballThree = b3;
            ScoreFrame(ballOne, ballTwo, ballThree);
        }

        public override void ScoreFrame(int b1, int b2, int b3)
        {
            frameScore = ballOne + ballTwo + ballThree;
        }


        public override int GetFrameScore()
        {
            return frameScore;
        }
    }

    class CalculateGameScore
    {
        public int GameScore = 0;

        public CalculateGameScore(BowlingFrame[] frames)
        {
            for (int i = 0; i < frames.Length; i++)
            {
                GameScore += frames[i].GetFrameScore();
            }

        }


        public int GetGameScore()
        {
            return GameScore;
        }
    }
}
