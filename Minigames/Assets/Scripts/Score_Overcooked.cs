﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Overcooked : Score
{

    public GameObject player1;
    public GameObject player2;
    public GameObject pauseOvercooked;
    public GameObject characterManagement;

    // Start is called before the first frame update
    protected override void Start() {

    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();

        //checks number of lives for each player or when the timer reaches 0 to display score
        if (currentTime <= 0f && gameCanEnd) {
            scoreTextbox.SetActive(true);

            if (player1.GetComponent<GameController>().points > player2.GetComponent<GameController>().points) {
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

                PlayerController.p1Score++;
                p1Wins[PlayerController.p1Score - 1] = "FillingFrenzy";

            } else if (player1.GetComponent<GameController>().points < player2.GetComponent<GameController>().points) {
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

                PlayerController.p2Score++;
                p2Wins[PlayerController.p2Score - 1] = "FillingFrenzy";

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

                PlayerController.p1Score++;
                PlayerController.p2Score++;
                p1Wins[PlayerController.p1Score - 1] = "FillingFrenzy";
                p2Wins[PlayerController.p2Score - 1] = "FillingFrenzy";

            }

            for (int i = 0; i < PlayerController.p1Score; i++) {
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

            for (int i = 0; i < PlayerController.p2Score; i++) {
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

            p1Score.GetComponent<Text>().text = PlayerController.p1Score.ToString();
            p2Score.GetComponent<Text>().text = PlayerController.p2Score.ToString();

            pauseButton.SetActive(false);
            pauseOvercooked.GetComponent<Pause_Overcooked>().PauseButton();

            gameCanEnd = false;

        }
    }

    protected override void FixedUpdate() {

    }
}
