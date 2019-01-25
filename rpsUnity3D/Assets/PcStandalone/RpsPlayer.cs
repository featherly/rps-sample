using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpsPlayer : MonoBehaviour
{
    public enum PhaseEnum
    {
        None,
        Picking,
        Picked,
        Comparing,
        Rematch,
    }

    public enum RpsChoiceEnum
    {
        None,
        Rock,
        Paper,
        Scissors,
    }

    public GameObject PlayerReady;
    public ParticleSystem WinParticles;
    public UnityEngine.UI.Text RockText;
    public UnityEngine.UI.Text PaperText;
    public UnityEngine.UI.Text ScissorsText;
    public UnityEngine.UI.Text ScoreText;
    public GameObject RockObj;
    public GameObject PaperObj;
    public GameObject ScissorsObj;
    public RpsManager Manager;

    public KeyCode Rock;
    public KeyCode Paper;
    public KeyCode Scissors;

    public PhaseEnum phase;
    private PhaseEnum lastPhase;
    public RpsChoiceEnum choice;

    //    private Vector3 RockStartPos;
    //    private Vector3 PaperStartPos;
    //    private Vector3 ScissorsStartPos;
    public int Score;

    void Start()
    {
        //       RockStartPos = RockObj.transform.localPosition;
        //       PaperStartPos = PaperObj.transform.localPosition;
        //       ScissorsStartPos = ScissorsObj.transform.localPosition;
        HideReady();
        phase = PhaseEnum.Picking;

        RockText.text = Rock.ToString();
        PaperText.text = Paper.ToString();
        ScissorsText.text = Scissors.ToString();

        Manager.Players.Add(this);
    }

    void Update()
    {
        switch (phase)
        {
            case PhaseEnum.Picking:
                checkPicked();
                break;
            case PhaseEnum.Picked:
            default:
                break;
            case PhaseEnum.Comparing:
                checkCompare();
                checkRematch();
                break;
        }
    }

    private void checkPicked()
    {
        if (Input.GetKeyDown(Rock)
         || Input.GetKeyDown(Paper)
         || Input.GetKeyDown(Scissors))
        {
            if (Input.GetKeyDown(Rock))
            {
                choice = RpsChoiceEnum.Rock;
            }
            else if (Input.GetKeyDown(Paper))
            {
                choice = RpsChoiceEnum.Paper;
            }
            else if (Input.GetKeyDown(Scissors))
            {
                choice = RpsChoiceEnum.Scissors;
            }

            ChoicesVisible(false);
            phase = PhaseEnum.Picked;
            lastPhase = PhaseEnum.Picked;
            PlayerReady.gameObject.SetActive(true);
            Manager.CheckAllReady();
        }
    }

    private void ChoicesVisible(bool isVisible)
    {
        RockObj.SetActive(isVisible);
        PaperObj.SetActive(isVisible);
        ScissorsObj.SetActive(isVisible);
        RockText.enabled = isVisible;
        PaperText.enabled = isVisible;
        ScissorsText.enabled = isVisible;
    }

    private void checkCompare()
    {
        if (lastPhase == PhaseEnum.Picked)
        {
            switch (choice)
            {
                case RpsChoiceEnum.Rock:
                    RockObj.SetActive(true);
                    break;
                case RpsChoiceEnum.Paper:
                    PaperObj.SetActive(true);
                    break;
                case RpsChoiceEnum.Scissors:
                    ScissorsObj.SetActive(true);
                    break;
                default:
                    break;
            }

            ScoreText.text = Score.ToString();
            PlayerReady.gameObject.SetActive(false);
            lastPhase = PhaseEnum.Comparing;
        }
    }

    private void checkRematch()
    {
        if (Input.GetKeyDown(Rock) || Input.GetKeyDown(Paper)
         || Input.GetKeyDown(Scissors))
        {
            phase = PhaseEnum.Rematch;
            PlayerReady.gameObject.SetActive(true);
            Manager.CheckAllRematch();
        }
    }

    public void Rematch()
    {
        phase = RpsPlayer.PhaseEnum.Picking;
        PlayerReady.gameObject.SetActive(false);

        ChoicesVisible(true);
    }

    public void HideReady()
    {
        PlayerReady.gameObject.SetActive(false);
    }

    public void Win()
    {
        WinParticles.Play();
    }
}
