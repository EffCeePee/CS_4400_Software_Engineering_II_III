using System;
using System.Collections.Specialized;
using System.IO;

namespace Bowling1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TEN = 10;
            string _file = "Bowling.txt";

            Console.WriteLine("Please enter a file name or press 1 to use sample data.");
            string input = Console.ReadLine();

            if (input != "1")
                _file = input;

            StreamReader bowlingStreamReader = new StreamReader(_file);
            Char[] _whitespace = null;
            int [] _scores = new int[21];
            int _frameScore = 0;
            int _runningScore = 0;
            var index = 0;
            
             


            string line = bowlingStreamReader.ReadToEnd();
            
            var temp = line.Split(_whitespace, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < temp.Length; i++)
            {
               _scores[i] = Convert.ToInt32(temp[i]);
            }

            for (int i = 0; i < TEN; i++)
            {
                if (_scores[index] == TEN)
                {
                    _frameScore = _scores[index] + _scores[index + 1] + _scores[index + 2];
                    _runningScore += _frameScore;
                    index++;
                    Console.WriteLine("Frame {0}: \tRunning Score: {1} \tFrame Score: {2}", i+1, _runningScore, _frameScore);
                }
                else if ((_scores[index] + _scores[index + 1]) == TEN)
                {
                    _frameScore = _scores[index] + _scores[index + 1] + _scores[index + 2];
                    _runningScore += _frameScore;
                    index += 2;
                    Console.WriteLine("Frame {0}: \tRunning Score: {1} \tFrame Score: {2}", i + 1, _runningScore, _frameScore);
                }
                else if ((_scores[index] + _scores[index + 1]) != TEN)
                {
                    _frameScore = _scores[index] + _scores[index + 1];
                    _runningScore += _frameScore;
                    index += 2;
                    Console.WriteLine("Frame {0}: \tRunning Score: {1} \tFrame Score: {2}", i + 1, _runningScore, _frameScore);
                }
            }

            Console.ReadLine();
        }
    }
}
