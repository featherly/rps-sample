using System.Collections.Generic;

public class Referee
{
    //TODO: use IoC on deviceStorage so this IsTest property isn't necessary.
    public bool IsTest { get; set; }

    private Storage deviceStore = new Storage();
    private const string won = "won!";
    private const string tied = "tied.";
    private const string lost = "lost.";

    public Referee()
    {
    }

    public OutcomeEnum GetGameOutcome(RpsEnum player, RpsEnum ai)
    {
        OutcomeEnum result;

        if (player == ai)
            result = (OutcomeEnum)((int)OutcomeSimple.Tie * 3 + player);
        else if (((int)player % 3) + 1 == (int)ai)
            result = (OutcomeEnum)((int)OutcomeSimple.Lose * 3 + player);
        else
            result = (OutcomeEnum)((int)OutcomeSimple.Win * 3 + player);

        return result;
    }

    public string HandleOutcome(OutcomeEnum outcomeOfRound, ref List<OutcomeEnum> gameOutcomes, out string gameHistoryUpdate)
    {
        if (gameOutcomes == null)
            gameOutcomes = new List<OutcomeEnum>();

        gameOutcomes.Add(outcomeOfRound);
        gameHistoryUpdate = deviceStore.SaveHistory(gameOutcomes, IsTest);

        string result;
        switch (outcomeOfRound)
        {
            case OutcomeEnum.WinWithRock:
            case OutcomeEnum.WinWithPaper:
            case OutcomeEnum.WinWithScissors:
                result = won;
                break;
            case OutcomeEnum.TieWithRock:
            case OutcomeEnum.TieWithPaper:
            case OutcomeEnum.TieWithScissors:
                result = tied;
                break;
            case OutcomeEnum.LoseWithRock:
            case OutcomeEnum.LoseWithPaper:
            case OutcomeEnum.LoseWithScissors:
                result = lost;
                break;
            case OutcomeEnum.Undetermined:
            default:
                return null;
        }
        return System.Environment.NewLine + "You " + result;
    }
}