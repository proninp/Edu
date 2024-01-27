namespace RockPaperScissorsGame;

public class HumanPlayer : IPlayer
{
    public Choice GetChoice()
    {
        Choice playerChoice;
        do
        {
            Console.Write("Enter Choice: (R)ock, (P)aper, or (S)cissors: ");
            string input = Console.ReadLine().ToUpper();
            if (input == "R")
            {
                playerChoice = Choice.Rock;
                break;
            }
            else if (input == "P")
            {
                playerChoice = Choice.Paper;
                break;
            }
            else if (input == "S")
            {
                playerChoice = Choice.Scissors;
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again!");
            }
        } while (true);
        
        return playerChoice;
    }
}
