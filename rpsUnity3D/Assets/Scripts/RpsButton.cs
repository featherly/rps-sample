using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class RpsButton : MonoBehaviour
{
    //file:///C:/Apps/Unity/Editor/Data/Documentation/Documentation/Components/gui-Layout.html
    /// <summary> default to the bottom third of the screen </summary>
    public Rect button = new Rect(0, Screen.height * 2 / 3, Screen.width, Screen.height / 3);
    public RpsEnum choice = RpsEnum.Undetermined;

    private void OnGUI()
    {
        if (GUI.Button(button, choice.ToString()))
            ExecuteChoice.Instance.DropInChoice(choice);
    }
}