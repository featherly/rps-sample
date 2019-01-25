using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class RpsInstructionText : MonoBehaviour
{
    public RpsManager manager;

    void Start()
    {
        manager.InstructionsText = this.GetComponent<UnityEngine.UI.Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
