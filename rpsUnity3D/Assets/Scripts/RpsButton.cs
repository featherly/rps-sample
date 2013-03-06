using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class RpsButton : MonoBehaviour
{
    //file:///C:/Apps/Unity/Editor/Data/Documentation/Documentation/Components/gui-Layout.html
    /// <summary> default to the bottom third of the screen </summary>
    public Rect button = new Rect(0, 0, 100, 100);
    public RpsEnum choice = RpsEnum.Undetermined;

    private void OnGUI()
    {
		GUI.skin.button.fontSize = (Screen.height+Screen.width)/40;
        if (button == new Rect(0, 0, 100, 100))
            button = createButton(choice);
        if (GUI.Button(button, choice.ToString()))
            ExecuteChoice.Instance.DropInChoice(choice);
    }

    private Rect createButton(RpsEnum choice)
    {
        float margin = 10;
        float left;
        float top = (Screen.height * 2) / 3 + margin;
        float width = Screen.width / 3 - (2 * margin);
        float height = Screen.height / 3 - (2 * margin);
        switch (choice)
        {
            case RpsEnum.Rock:
                left = 0 + margin;
                return new Rect(left, top, width, height);
            case RpsEnum.Paper:
                left = Screen.width / 3 + margin;
                return new Rect(left, top, width, height);
            case RpsEnum.Scissors:
                left = (Screen.width * 2) / 3 + margin;
                return new Rect(left, top, width, height);
            case RpsEnum.Undetermined:
            default:
                return button;
        }
    }
}