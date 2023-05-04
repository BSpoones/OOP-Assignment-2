using MathsTutor.Gameplay;

namespace MathsTutor
{
    /*
     * Menu Class
     * 
     * This class stores all menus apart from the tutorial
     * 
     * The tutorial is in a seperate class due to the requirements of the specification
     */
    public class Menus
    {
        private static readonly string EnterSelectionString = "Enter Selection: "; // Constant

        public static readonly int MainMenuMax = 5;
        private static readonly string MainMenuString =
            "--------======[]======--------\n"+
            "    Welcome To MathsTutor!    \n"+ // SPEC: Welcome message
            "--------======[]======--------\n" +
            "\n" +
            "Welcome to MathsTutor! The card based maths game\n" +
            "Please select one of the following:\n" +
            " [1] - Show instructions\n" +
            " [2] - 3-Card game\n" +
            " [3] - 5-Card game\n" +
            " [4] - Show leaderboards\n" +
            " [5] - Exit\n" +
            "\n"
            ;

        private static readonly int PlayAgainMenuMax = 2;
        private static readonly string PlayAgainMenuString =
            "-----------\n"+
            "Round over!\n" +
            "-----------\n"+
            "\n" +
            "Please select one of the following\n" +
            " [1] - Deal again\n" +
            " [2] - Exit to main menu\n"+
            "\n"

            ;

        /*
         * Parses string input (1-x), returning an int that is <= maxval and throwing
         * an error if the input is not an int or the int is too high or the int is <1
         */
        public static int ParseChoice(string input, int maxVal)
        {
            // Checks if it is an int
            if (int.TryParse(input, out int choice))
            {
                if (choice < 1 || choice > maxVal) // Range error handling
                {
                    throw new Exception($"{choice} is not between 1 and {maxVal}");
                }
                else
                {
                    return choice;
                }
            }
            else
            {
                throw new Exception($"{input} is not a valid choice. Please enter a number between 1 and {maxVal}");
            }
        }
        /*
         * HandleSelection method
         * 
         * Handles a user input and ensures that the selection is valid,
         * if the selection is invalid, the user will be prompted to re-enter
         * until they get it right
         */
        public static int HandleSelection(int MaxInput)
        {
            int choice = 0;
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    string selection = Console.ReadLine();
                    choice = ParseChoice(selection, MaxInput);
                    validInput = true; // Will error out if ParseChoice fails
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // Defined error messages in method above
                    EnterSelection();
                    continue;
                }
            }
            return choice;
        }

        /*
         * Main Menu method
         * 
         * This menu handles all function calls required by the main menu
         * on the client requirements sheet
         */
        public static void MainMenu()
        {
            // SPEC: Present menu to users
            Console.Clear();
            Console.Write(MainMenuString);
            EnterSelection();

            int choice = HandleSelection(MainMenuMax);

            switch (choice)
            {
                case 1:
                    Tutorial.ShowTutorial();
                    break;
                case 2:
                    ThreeCardGame threeCardGame = new();
                    threeCardGame.Play();
                    break;
                case 3:
                    FiveCardGame fiveCardGame = new();
                    fiveCardGame.Play();
                    break;
                case 4:
                    Statistics.ShowScores();
                    break;
                case 5:
                    MathsTutor.Exit(); // SPEC: Quit option
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Invalid input", "Input must be between 1 and 5");
            }
        }
        /*
         * Writes the EnterSelectionString to the console
         */
        public static void EnterSelection()
        {
            Console.Write(EnterSelectionString);
        }

        /*
         * PlayAgainMenu method
         * 
         * Handles the PlayAgainMenu string and menu response
         */
        public static bool PlayAgainMenu()
        {
            Console.Write(PlayAgainMenuString);
            EnterSelection();

            int choice = HandleSelection(PlayAgainMenuMax);

            switch (choice)
            {
                case 1:
                    return true;
                case 2:
                    return false;
                default:
                    return true;
            }
        }
    }
}
