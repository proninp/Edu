namespace RockPaperScissorsGame.Tests;

public class RPSTEsts
{
    [Test]
    public void RockBeatsScissors()
    {
        GameManager gm = new GameManager(new ForcedPlayer(Choice.Rock), new ForcedPlayer(Choice.Scissors));
        Assert.That(gm.PlayRound(), Is.EqualTo(RoundResult.Player1Win));
    }

    [Test]
    public void PaperBeatsRock()
    {
        GameManager gm = new GameManager(new ForcedPlayer(Choice.Paper), new ForcedPlayer(Choice.Rock));
        Assert.That(gm.PlayRound(), Is.EqualTo(RoundResult.Player1Win));
    }

    [Test]
    public void ScissorsBeatsPaper()
    {
        GameManager gm = new GameManager(new ForcedPlayer(Choice.Scissors), new ForcedPlayer(Choice.Paper));
        Assert.That(gm.PlayRound(), Is.EqualTo(RoundResult.Player1Win));
    }
}