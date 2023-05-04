-----------------------
# Maths Tutor Console App
-----------------------

# NOTE: THIS PLAN MAY NOT BE THE SAME AS THE FINAL PRODUCT

## Item by item requirements

- Presents a welcome message when application starts:
    - Message inbuilt into the Main Menu method

 - Presents a goodbye message when the application quits
   - Message inbuilt into the Quit method

- Application presents a main menu to users:
   - Main menu has the following:
      ```
         TITLE

         1) Instructions
         2) Deal 3 cards
         3) Deal 5 cards
         4) Show leaderboard
         5) Quit
      ```

   - Instructions show how the game works, to by typed out later
   - Deal 3/5 cards deals 2 numbers + an operator in order,
      or 3 numbers + 2 operators in order
      - User is prompted to give the answer
      - If the answer is correct, then the user is told
      - If the user is incorrect, the user is also told
      - The choice to deal again or return to the menu is shown
   - Quitting runs the Quit method

 - Single Shuffle algorithm of your choide
   - Shuffle algorithm moved from A01 and improved

 - Each class should be a seperate file
   - Class names listed below

 - Card, Pack, and Tutorial classes should be presents
   - Class names listed below

 - Errors should be handled
   - Error handling sorted out, maybe in an error_handling class?

 - OOP aspects
   - Instantiate objects
   - Encapsulation
   - Inherritance
   - Polymorphism
   - Interfaces

 - Application should be tested
   - Testing class required

 - Statistics stored in .txt file
   - PLACEHOLDER

 - Exception handling should be used
   - PLACEHOLDER


## Class structure:

### Program.cs
 - Runs the main menu or the testing class

### Menus.cs
 - Responsible for storing menu strings & handling
   user input
 - MainMenu
 - parseInput():
    - Parses user input returning an int number choice

### Pack.cs
 - Creates card pack
 - Shuffles card pack
 - DealCard (x):
      - Unlike the previous version, DealCard takes an odd int (x)
        and creates a list of alternating types: NumberCard and OperatorCard
        this can be 3, 5, or any amount.

### Card.cs
 - Creates card
 - Also contains card interface:
    - getValue: Shows value the card:
        - x of Suit, if normal card
        - x if NumberCard
        - operator (from suit) if OperatorCard
    format: 2 and the 4 operators
 - drawCard (VIRTUAL): Draws an ASCII card in the following:
      ```
          _____           
         |2    |
         |  ♣  | 
         |     |
         |  ♣  | 
         |____2| 

         
      ```
 - Each card is drawn this way

### NumberCard.cs
 - Inherrits from Card
 - getValue returns only number

### OperatorCard.cs
 - Inherrits from Card
 - OperatorCard contains the operator based on the suit enum
 - Contains a drawCard override:
    - Instead of drawing the card, The operator is placed in
      the middle of where a card would be (5x7 matrix)

### MathsTutor.cs - To be renamed
 - Handles all aspects of MathsTutor
 - This is the main class. The game is run using the run() method
 - Responsible for the following:
    - Dealing 3 or 5 cards, depending on input
    - Converting cards to Number and Operator cards 
      properly & adding to List<Card>
    - Drawing all cards, combining them into a X by 7 grid
    - Calculating the correct answer to the 3/5 card prompted
    - Taking user input, checking if the answer is correct
    - Telling the user if the answer was correct/ incorrect
    - Giving the user the option to deal again / return to main menu
    - If deal again is selected goto the start of this listed
    - If main menu is selected, go to main menu

 - Methods:
   mainMenu():
      - Responsible for handling the main menu
   instructions():
      - Sends the instructions string and returns to the main menu
   playCards(n):
      - Plays n cards
   exit(n):
      - Sends exit string, then closes the program
   drawCards(List<Card>):
      - Draws all cards, combining them into a X by 7 grid

### Calculation.cs
 - Responsible for BIDMAS maths operations
   (It's BIDMAS, not BODMAS. Checkmate American'ts)
 - Methods:
      - calculate(List<Card>):
         - Uses card.value to find out if it's a number or operations
         - Calculates properly regardless of length:
            - Identifies pairs by operator, looking at the values to the left
              and right of the operator, sorts that using DMAS, then calculates,
              then replaces the left and right with the final value?

### ScoreBoard.cs
 - Responsible for creating a leaderboard
 - Methods:
      - drawBoard():
         - Draws the leaderboard, using string formatting etc
         - Reads from scoreboard.txt, with appropriate error handling
           for empty files etc

### Tests.cs:
 - Testing class responsible for the following tests:
