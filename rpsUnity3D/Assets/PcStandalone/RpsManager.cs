using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class RpsManager : ScriptableObject
{
    public RpsPlayer.PhaseEnum GamePhase;

    public List<RpsPlayer> Players;

    public UnityEngine.UI.Text InstructionsText;

    private Dictionary<RpsPlayer.PhaseEnum, string> instructions = new Dictionary<RpsPlayer.PhaseEnum, string>()
    {
        {RpsPlayer.PhaseEnum.Picking, "Press a key to make a selection"},
        {RpsPlayer.PhaseEnum.Picked, "All players must make a selection"},
        {RpsPlayer.PhaseEnum.Comparing, ""},
        {RpsPlayer.PhaseEnum.Rematch, "Press a key to vote for a rematch"},
    };

    void OnEnable()
    {
        Players = new List<RpsPlayer>();
        Debug.Log("OnEnable player count " + Players.Count);
    }

    public void UpdateInstructionText()
    {
        if (InstructionsText != null)
        {
            InstructionsText.text = instructions[GamePhase];
        }
    }

    public void CheckAllReady()
    {
        bool allPicked = Players.All(p => p.phase == RpsPlayer.PhaseEnum.Picked);

        if (allPicked)
        {
            int Rocks = Players.Where(p => p.choice == RpsPlayer.RpsChoiceEnum.Rock).Count();
            int Papers = Players.Where(p => p.choice == RpsPlayer.RpsChoiceEnum.Paper).Count();
            int Scissors = Players.Where(p => p.choice == RpsPlayer.RpsChoiceEnum.Scissors).Count();

            foreach (var player in Players)
            {
                //                Debug.Log(Players.Count + ":count ("
                //                 + Rocks + "," + Papers + "," + Scissors
                //                  + ") choice:" + player.choice);
                player.phase = RpsPlayer.PhaseEnum.Comparing;
                switch (player.choice)
                {
                    case RpsPlayer.RpsChoiceEnum.Rock:
                        if (Scissors > 0)
                        {
                            player.Score += Scissors;
                            player.Win();
                        }
                        break;
                    case RpsPlayer.RpsChoiceEnum.Paper:
                        if (Rocks > 0)
                        {
                            player.Score += Rocks;
                            player.Win();
                        }
                        break;
                    case RpsPlayer.RpsChoiceEnum.Scissors:
                        if (Papers > 0)
                        {
                            player.Score += Papers;
                            player.Win();
                        }
                        break;
                    default:
                        break;
                }
            }
            GamePhase = RpsPlayer.PhaseEnum.Rematch;
        }
        else
        {
            GamePhase = RpsPlayer.PhaseEnum.Picked;
        }
        UpdateInstructionText();
    }

    public void CheckAllRematch()
    {
        bool allRematch = Players.All(p => p.phase == RpsPlayer.PhaseEnum.Rematch);

        Debug.Log(Players.Count + " allRematch " + allRematch);
        if (allRematch)
        {
            GamePhase = RpsPlayer.PhaseEnum.Picking;
            UpdateInstructionText();
            foreach (var player in Players)
            {
                player.Rematch();
            }
        }
    }
}
