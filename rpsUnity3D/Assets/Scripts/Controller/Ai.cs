using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Ai
{
    public static Ai Instance = new Ai();

    private System.Random rnd = new System.Random();

    public Ai()
    {
    }

    /// <summary> Gets the AIs move choice when given the games history of move choices </summary>
    /// <param name="gameHistory">human players history of move choices in order of oldest to newest</param>
    /// <returns>the AIs move choice</returns>
    public RpsEnum GetAiChoice(List<OutcomeEnum> gameHistory)
    {
        //TODO: use gameHistory to make more intelligent ai moves
        return (RpsEnum)rnd.Next(1, 4);
    }
}