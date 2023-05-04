using System;
using System.IO;

namespace MathsTutor
{
    /*
     * Statistics class
     * 
     * Responsible for writing and reading scores from statistics.txt
     */
    public class Statistics
    {
        public static void AddScore(int score)
        {
            // Getting filepath
            string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string relativePath = @"..\..\..\statistics.txt";
            string fullPath = Path.Combine(directory, relativePath);

            // Writing score to file
            using StreamWriter writer = File.AppendText(fullPath);
            writer.WriteLine(score);
        }
        public static void ShowScores()
        {
            // Getting filepath
            string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string relativePath = @"..\..\..\statistics.txt";
            string fullPath = Path.Combine(directory, relativePath);

            // Reading file
            string fileContents = File.ReadAllText(fullPath);

            // Outputting to user
            Console.Write($"Showing Previous Top Scores:\n\n{fileContents}");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadLine();
        }
    }
}
