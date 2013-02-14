using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ExecuteChoice : MonoBehaviour
{
    /// <summary>static required so that class can be accessed from RpsButton.cs</summary>
    public static ExecuteChoice Instance;

    /// <summary> prefabs </summary>
    public Transform Rock;
    public Transform Paper;
    public Transform Scissors;

    private Storage deviceStore = new Storage();
    private Ai aiObject = new Ai();
    private string gameConsole;
    private string gameHistory;
    private Transform player3D;
    private Transform ai3D;
    private List<OutcomeEnum> gameOutcomes = new List<OutcomeEnum>();

    // Use this for initialization
    void Start()
    {
        Instance = this;
        gameHistory = deviceStore.GetHistory();
        gameOutcomes = deviceStore.ConvertToHistoryEnumList(gameHistory);
    }

    private void OnGUI()
    {
        GUILayout.Label(gameHistory);
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 3 - 100, 200, 200));
        GUILayout.Label(gameConsole);
        GUILayout.EndArea();
    }

    /// <summary>  </summary>
    public void DropInChoice(RpsEnum player)
    {
        //cleanup last round
        removeGameObject(player3D);
        removeGameObject(ai3D);

        //calculate this round
        RpsEnum ai = aiObject.GetAiChoice(gameOutcomes);
        OutcomeEnum roundOutcome = getGameOutcome(player, ai);
        string outcomeText = handleOutcome(roundOutcome);
        gameConsole =
            "You chose " + player.ToString() + System.Environment.NewLine +
            "Computer chose " + ai.ToString()
            + outcomeText;

        //Drop in 3D objects
        player3D = createAt("PlayerDrop", player);
        ai3D = createAt("AiDrop", ai);
    }

    private OutcomeEnum getGameOutcome(RpsEnum player, RpsEnum ai)
    {
        if (player == ai)
            return (OutcomeEnum)((int)OutcomeSimple.Tie * 3 + player);
        else if (((int)player % 3) + 1 == (int)ai)
            return (OutcomeEnum)((int)OutcomeSimple.Lose * 3 + player);
        else
            return (OutcomeEnum)((int)OutcomeSimple.Win * 3 + player);
    }

    private string handleOutcome(OutcomeEnum outcomeOfRound)
    {
        gameOutcomes.Add(outcomeOfRound);
        gameHistory = deviceStore.SaveHistory(gameOutcomes);

        string result;
        switch (outcomeOfRound)
        {
            case OutcomeEnum.WinWithRock:
            case OutcomeEnum.WinWithPaper:
            case OutcomeEnum.WinWithScissors:
                result = "won!";
                break;
            case OutcomeEnum.LoseWithRock:
            case OutcomeEnum.LoseWithPaper:
            case OutcomeEnum.LoseWithScissors:
                result = "lost.";
                break;
            case OutcomeEnum.TieWithRock:
            case OutcomeEnum.TieWithPaper:
            case OutcomeEnum.TieWithScissors:
                result = "tied.";
                break;
            case OutcomeEnum.Undetermined:
            default:
                return null;
        }
        return System.Environment.NewLine + "You " + result;
    }

    private void removeGameObject(Transform transformObject)
    {
        if (transformObject != null && transformObject.gameObject != null)
            Destroy(transformObject.gameObject);
    }

    private Transform createAt(string atGameObjName, RpsEnum objectType)
    {
        Transform obj = getPrefab(objectType);
        return Instantiate(obj,
            GameObject.Find(atGameObjName).transform.position,
            obj.rotation) as Transform;
    }

    private Transform getPrefab(RpsEnum ofType)
    {
        switch (ofType)
        {
            case RpsEnum.Rock:
                return Rock;
            case RpsEnum.Paper:
                return Paper;
            case RpsEnum.Scissors:
                return Scissors;
            case RpsEnum.Undetermined:
            default:
                return null;
        }
    }
}