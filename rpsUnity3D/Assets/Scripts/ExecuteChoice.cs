using UnityEngine;
using System.Collections;

public class ExecuteChoice : MonoBehaviour
{
    /// <summary>static required so that class can be accessed from RpsButton.cs</summary>
    public static ExecuteChoice Instance;

    /// <summary> prefabs </summary>
    public Transform Rock;
    public Transform Paper;
    public Transform Scissors;

    private string gameConsole;
    private Transform player3D;
    private Transform ai3D;

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 3 - 100, 200, 200));
        GUILayout.Label(gameConsole);
        GUILayout.EndArea();
    }

    private System.Random rnd = new System.Random();

    /// <summary>  </summary>
    public void DropInChoice(RpsEnum player)
    {
        //cleanup last round
        removeGameObject(player3D);
        removeGameObject(ai3D);

        //diplay next round
        RpsEnum ai = (RpsEnum)rnd.Next(1, 4);
        string result;
        if (player == ai)
            result = "tied.";
        else if (((int)player % 3) + 1 == (int)ai)
            result = "lost.";
        else
            result = "won!";
        gameConsole = "Computer chose " + ai.ToString()
            + System.Environment.NewLine + "You " + result;

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