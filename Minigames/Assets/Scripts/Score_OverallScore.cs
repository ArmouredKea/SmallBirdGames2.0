using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_OverallScore : Score
{
    //calculates the overall score
    protected override void Start() {
        if (CharacterCarryOver.p1Score > CharacterCarryOver.p2Score) {
            if (CharacterCarryOver.player1 == "Bo") {
                p1WinBo.SetActive(true);
            } else if (CharacterCarryOver.player1 == "Hiro") {
                p1WinHiro.SetActive(true);
            } else if (CharacterCarryOver.player1 == "Mika") {
                p1WinMika.SetActive(true);
            }

            if (CharacterCarryOver.player2 == "Bo") {
                p2Bo.SetActive(true);
            } else if (CharacterCarryOver.player2 == "Hiro") {
                p2Hiro.SetActive(true);
            } else if (CharacterCarryOver.player2 == "Mika") {
                p2Mika.SetActive(true);
            }
        } else if (CharacterCarryOver.p1Score < CharacterCarryOver.p2Score) {
            if (CharacterCarryOver.player2 == "Bo") {
                p2WinBo.SetActive(true);
            } else if (CharacterCarryOver.player2 == "Hiro") {
                p2WinHiro.SetActive(true);
            } else if (CharacterCarryOver.player2 == "Mika") {
                p2WinMika.SetActive(true);
            }

            if (CharacterCarryOver.player1 == "Bo") {
                p1Bo.SetActive(true);
            } else if (CharacterCarryOver.player1 == "Hiro") {
                p1Hiro.SetActive(true);
            } else if (CharacterCarryOver.player1 == "Mika") {
                p1Mika.SetActive(true);
            }
        } else {
            if (CharacterCarryOver.player1 == "Bo") {
                p1WinBo.SetActive(true);
            } else if (CharacterCarryOver.player1 == "Hiro") {
                p1WinHiro.SetActive(true);
            } else if (CharacterCarryOver.player1 == "Mika") {
                p1WinMika.SetActive(true);
            }

            if (CharacterCarryOver.player2 == "Bo") {
                p2WinBo.SetActive(true);
            } else if (CharacterCarryOver.player2 == "Hiro") {
                p2WinHiro.SetActive(true);
            } else if (CharacterCarryOver.player2 == "Mika") {
                p2WinMika.SetActive(true);
            }
        }

        for (int i = 0; i < CharacterCarryOver.p1Score; i++) {
            if (p1Wins[i] == "WaterWars") {
                p1Tokens[i].SetActive(true);
                p1Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/WaterWarsToken");
            } else if (p1Wins[i] == "FillingFrenzy") {
                p1Tokens[i].SetActive(true);
                p1Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/FillingFrenzyToken");
            } else if (p1Wins[i] == "BalloonBattle") {
                p1Tokens[i].SetActive(true);
                p1Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/BalloonBattleToken");
            }
        }

        for (int i = 0; i < CharacterCarryOver.p2Score; i++) {
            if (p2Wins[i] == "WaterWars") {
                p2Tokens[i].SetActive(true);
                p2Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/WaterWarsToken");
            } else if (p2Wins[i] == "FillingFrenzy") {
                p2Tokens[i].SetActive(true);
                p2Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/FillingFrenzyToken");
            } else if (p2Wins[i] == "BalloonBattle") {
                p2Tokens[i].SetActive(true);
                p2Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/BalloonBattleToken");
            }
        }

        p1Score.GetComponent<Text>().text = CharacterCarryOver.p1Score.ToString();
        p2Score.GetComponent<Text>().text = CharacterCarryOver.p2Score.ToString();

    }

    // Update is called once per frame
    protected override void Update() {

    }
}
