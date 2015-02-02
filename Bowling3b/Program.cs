using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling3b
{
    internal class Program
    {


        private static void Main(string[] args)
        {



            int[] frameScores = new int[10];


            for (int i = 0; i < 10; i++)
            {
                frameScores[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Frame " + i + " score: " + frameScores[i]);
            }

            CalculateGameScore gameScore = new CalculateGameScore(frameScores);

            Console.WriteLine("The game score is: " + gameScore.GetGameScore());
        }
    }


    class CalculateGameScore
    {
        public int GameScore = 0;

        public CalculateGameScore(int[] frames)
        {
            for (int i = 0; i < frames.Length; i++)
            {
                GameScore += frames[i];
            }

        }


        public int GetGameScore()
        {
            return GameScore;
        }
    }
}
