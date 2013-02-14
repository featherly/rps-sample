using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Storage
{
    private const string keyHistory = "OutcomeHistory";

    public Storage()
    {
    }

    #region [ Player Win/Lose History ]
    public string GetHistory()
    {
        return PlayerPrefs.GetString(keyHistory);
    }

    public List<OutcomeEnum> ConvertToHistoryEnumList(string asString)
    {
        List<OutcomeEnum> outcomeHistory = new List<OutcomeEnum>();
        foreach (var character in asString)
        {
            outcomeHistory.Add(getHistoryEnumRepresentation(character));
        }
        return outcomeHistory;
    }

    /// <summary> Saves the Win/Lose/Tie history </summary>
    /// <param name="outcomeHistory"></param>
    /// <returns>outcomeHistory as a string value</returns>
    public string SaveHistory(List<OutcomeEnum> outcomeHistory)
    {
        string gameHistory = new string(
            outcomeHistory.Reverse<OutcomeEnum>().Take(10)
            .SelectMany(e => getHistoryCharRepresentation(e).ToString())
            .Reverse()
            .ToArray()
            );
        SaveHistory(gameHistory);
        return gameHistory;
    }
    public void SaveHistory(string outcomeHistory)
    {
        //up to 1MB of storage http://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.html
        PlayerPrefs.SetString(keyHistory, outcomeHistory);
    }

    private char getHistoryCharRepresentation(OutcomeEnum outcome)
    {
        switch (outcome)
        {
            case OutcomeEnum.WinWithRock:
                return 'R';
            case OutcomeEnum.WinWithPaper:
                return 'P';
            case OutcomeEnum.WinWithScissors:
                return 'S';
            case OutcomeEnum.LoseWithRock:
                return 'r';
            case OutcomeEnum.LoseWithPaper:
                return 'p';
            case OutcomeEnum.LoseWithScissors:
                return 's';
            case OutcomeEnum.TieWithRock:
                return 'O';
            case OutcomeEnum.TieWithPaper:
                return 'I';
            case OutcomeEnum.TieWithScissors:
                return 'X';
            case OutcomeEnum.Undetermined:
            default:
                return '?';
        }
    }

    private OutcomeEnum getHistoryEnumRepresentation(char outcome)
    {
        switch (outcome)
        {
            case 'R':
                return OutcomeEnum.WinWithRock;
            case 'P':
                return OutcomeEnum.WinWithPaper;
            case 'S':
                return OutcomeEnum.WinWithScissors;
            case 'r':
                return OutcomeEnum.LoseWithRock;
            case 'p':
                return OutcomeEnum.LoseWithPaper;
            case 's':
                return OutcomeEnum.LoseWithScissors;
            case 'O':
                return OutcomeEnum.TieWithRock;
            case 'I':
                return OutcomeEnum.TieWithPaper;
            case 'X':
                return OutcomeEnum.TieWithScissors;
            case '?':
            default:
                return OutcomeEnum.Undetermined;
        }
    }
    #endregion [ Player Win/Lose History ]
}