namespace RockPaperScissorsGame
{
    public class ComputerPlayer : IPlayer
    {
        private Random _randomNumberGenerator = new Random();

        public Choice GetChoice()
        {
            Choice playerChoice = (Choice)_randomNumberGenerator.Next(0, 3);
            return playerChoice;
        }
    }
}
