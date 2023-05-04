namespace MathsTutor
{
    /*
     * MathsTutor class
     * 
     * Responsible for misc methods used in gameplay
     */
    public class MathsTutor
    {
        public static void Run()
        {
            // Running main menu
            while (true)
            {
                Menus.MainMenu();
            }
        }
        /*
         * Combines ASCII card drawings by reading and combining them
         * line by line
         */
        public static string CombineCards(List<Card> cards)
        {
            // Creating 2D line array
            string[][] lines = new string[cards.Count][];

            // Splitting each card drawing
            for (int i = 0; i < cards.Count; i++)
            {
                lines[i] = cards[i].DrawCard().Split("\n");
            }

            string outputString = "";

            // Conbining them back together
            for (int i = 0; i< 6; i++) // Each card has 6 lines exactly
            {
                string outputStringLine = "";

                foreach (string[] line in lines)
                {
                    outputStringLine += $"{line[i]} ";
                }
                outputString += outputStringLine + "\n";
            }

            return outputString;
        }

        public static void Exit()
        {
            Console.WriteLine("\n\nExiting program. Goodbye!"); // SPEC: Goodbye message
            Environment.Exit(0);
        }
    }
}
