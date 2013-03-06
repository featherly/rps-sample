using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//http://forum.unity3d.com/threads/98230-Security-Exception-ECall-methods-must-be-packaged-into-a-system-module.
//#if UNIT_TEST //TODO: this requires registering UNIT_TEST somehow
//public class Debug
//{
//    public static void Log(string s) { Console.WriteLine(s); }
//    public static void LogWarning(string s) { Console.WriteLine(s); }
//    public static void LogError(string s) { Console.WriteLine(s); }
//}

//public class MonoBehaviour
//{

//}
//#endif

public class ExecuteChoice : MonoBehaviour
{
    /// <summary>static required so that class can be accessed from RpsButton.cs</summary>
    public static ExecuteChoice Instance;

    /// <summary> prefabs </summary>
    public Transform Rock;
    public Transform Paper;
    public Transform Scissors;

    private Storage deviceStore = new Storage();
    private Referee referee = new Referee();
    private Ai aiObject = new Ai();
    private string gameConsole;
    private string gameHistory;
    private Transform player3D;
    private Transform ai3D;
    private List<OutcomeEnum> gameOutcomes = new List<OutcomeEnum>();
	
	private bool firstRun = true;
	private int lblWidth, lblHeight, lblLeft, lblTop;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        gameHistory = deviceStore.GetHistory();
        gameOutcomes = deviceStore.ConvertToHistoryEnumList(gameHistory);
		
		//If this code could access the default GUI.skin we could do the "firstRun" here
		//Globals.myGuiSkin = //GameObject.FindWithTag("GUI") as GUISkin; // 
			//ScriptableObject.CreateInstance(typeof(GUISkin)) as GUISkin;
    }

    private void OnGUI()
    {
		if (firstRun)
		{
			GUIStyle myStyl = new GUIStyle();
			myStyl.normal.textColor = GUI.skin.label.normal.textColor;
			myStyl.fontSize = (Screen.height+Screen.width)/40;
			myStyl.alignment = TextAnchor.MiddleCenter;
			Globals.FontSized = myStyl;
			
			lblWidth = Screen.width / 2;
			lblHeight = Screen.height / 2;
			lblLeft = Screen.width / 2 - lblWidth / 2;
			lblTop = Screen.height / 2 - lblHeight / 2;
			firstRun = false;
		}
		
        GUILayout.Label(gameHistory, Globals.FontSized);
        GUILayout.BeginArea(new Rect(lblLeft, lblTop, lblWidth, lblHeight));
        GUILayout.Label(gameConsole, Globals.FontSized);
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
        OutcomeEnum roundOutcome = referee.GetGameOutcome(player, ai);
        string gameHistoryUpdate;
        string outcomeText = referee.HandleOutcome(roundOutcome, ref gameOutcomes, out gameHistoryUpdate);

        //Update UI elements
        gameHistory = gameHistoryUpdate;
        gameConsole =
            "You chose " + player.ToString() + System.Environment.NewLine +
            "Computer chose " + ai.ToString()
            + outcomeText;

        //Drop in 3D objects
        player3D = createAt("PlayerDrop", player);
        ai3D = createAt("AiDrop", ai);
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