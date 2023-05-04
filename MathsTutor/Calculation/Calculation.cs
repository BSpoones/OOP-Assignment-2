namespace MathsTutor
{
    /*
    * Calculator class, responsible for calculation of multiple cards
    * 
    * SimpleCalculate: Responsible for 2 number 1 operator solutions
    * ComplexCalculate: Responsible for multiple operation solutions
    * 
    */
    public class Calculation
    {
        /*
         * Calculate method
         * 
         * Responsible for calculating card lists of any length
         */
        public static double Calculate(List<Card> cards)
        {
            if (cards.Count == 3) // 3 length list always means 2 number 1 operator
            {
                return SimpleCalculate(cards);
            }
            else
            {
                return ComplexCalculate(cards);
            }
        }

        /*
         * SimpleCalculate method
         * 
         * Responsible for using an operator on two numbers
         */
        public static double SimpleCalculate(List<Card> cards)
        {
            NumberCard number1 = (NumberCard)cards[0];
            OperatorCard operator1 = (OperatorCard)cards[1];
            NumberCard number2 = (NumberCard)cards[2];

            return Math.Round(
                operator1.GetOperator().Calculate(number1.Value, number2.Value),
                2
                );
        }

        /*
         * ComplexCalculate method
         * 
         * Responsible for BODMAS calculations
         * 
         * Run through a list 4 times, for each operation
         * 
         * Keep looking for the operator (e.g /) until there are none left
         *  if found, find the numbers before and after it, to get a 3 item list
         *  calculate it and replace the 3 items in the list with that one answer
         *  repeat
         *  
         *  e.g
         *  
         *  [1,+,10,*,3] will turn into
         *  [1,+,30] which turns into
         *  [31]
         */
        public static double ComplexCalculate(List<Card> cardsInput)
        {

            // SPEC: Using BODMAS
            List<object> cards = cardsInput.Cast<object>().ToList();

            List<string> possibleOperators = new() { "÷", "x", "+", "-" };

            foreach (string possibleOperator in possibleOperators)
            {
                while (true)
                {
                    try
                    {
                        int index = cards.FindIndex(n => n is OperatorCard && ((OperatorCard)n).GetOperator().ToString() == possibleOperator);
                        // Assuming it's found the index of an operator. Will error out and break otherwise

                        // Creating 3 numbers just ike SimpleCalculate
                        NumberCard number1 = (NumberCard)cards[index-1];
                        OperatorCard operator1 = (OperatorCard)cards[index];
                        NumberCard number2 = (NumberCard)cards[index+1];

                        // SimpleCalculate not used as i am choosing not to round until the very end
                        double answer = operator1.GetOperator().Calculate(number1.Value, number2.Value);

                        // Creating a NumberCard so it's compatable with the list
                        NumberCard answerCard = new(Card.SuitType.Spades, answer);

                        // Removing the 3 and replacing with the one card
                        cards.RemoveRange(index - 1, 3);
                        cards.Insert(index - 1, answerCard);

                    }
                    catch
                    {
                        // Any error here will mean that an operator is not found, this means that all operators
                        // of that type have been found and dealt with
                        break;
                    }
                }
            }

            // Once there are no operators left, it means that there is only
            // one item left, the answer
            return Math.Round(
                ((NumberCard)cards[0]).GetValue(),
                2
                );
        }
    }
}
