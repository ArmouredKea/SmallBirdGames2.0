﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Overcooked : Score
{

    public GameObject player1;
    public GameObject player2;
    public GameObject pauseOvercooked;

    // Start is called before the first frame update
    protected override void Start() {
        
    }

    // Update is called once per frame
    protected override void Update() {
        if (!paused) {
            currentTime -= Time.deltaTime;
        }

        //checks number of lives for each player or when the timer reaches 0 to display score
        if (currentTime <= 0f && gameCanEnd) {
            scoreTextbox.SetActive(true);

            if (player1.GetComponent<GameController>().points > player2.GetComponent<GameController>().points) {
                if (CharacterCarryOver.player1 == "Bo") {
                    winBo.SetActive(true);
                    p1Bo.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Hiro") {
                    winHiro.SetActive(true);
                    p1Hiro.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Mika") {
                    winMika.SetActive(true);
                    p1Mika.SetActive(true);
                }

                if (CharacterCarryOver.player2 == "Bo") {
                    p2Bo.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Hiro") {
                    p2Hiro.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Mika") {
                    p2Mika.SetActive(true);
                }

                PlayerController.p1Score++;

            } else if (player1.GetComponent<GameController>().points < player2.GetComponent<GameController>().points) {
                if (CharacterCarryOver.player2 == "Bo") {
                    winBo.SetActive(true);
                    p2Bo.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Hiro") {
                    winHiro.SetActive(true);
                    p2Hiro.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Mika") {
                    winMika.SetActive(true);
                    p2Mika.SetActive(true);
                }

                if (CharacterCarryOver.player1 == "Bo") {
                    p1Bo.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Hiro") {
                    p1Hiro.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Mika") {
                    p1Mika.SetActive(true);
                }

                PlayerController.p2Score++;

            } else {
                if (CharacterCarryOver.player1 == "Bo") {
                    drawP1Bo.SetActive(true);
                    p1Bo.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Hiro") {
                    drawP1Hiro.SetActive(true);
                    p1Hiro.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Mika") {
                    drawP1Mika.SetActive(true);
                    p1Mika.SetActive(true);
                }

                if (CharacterCarryOver.player2 == "Bo") {
                    drawP2Bo.SetActive(true);
                    p2Bo.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Hiro") {
                    drawP2Hiro.SetActive(true);
                    p2Hiro.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Mika") {
                    drawP2Mika.SetActive(true);
                    p2Mika.SetActive(true);
                }

                PlayerController.p1Score++;
                PlayerController.p2Score++;

            }

            if (PlayerController.p1Score == 0) {
                p1Score0.SetActive(true);
            } else if (PlayerController.p1Score == 1) {
                p1Score1.SetActive(true);
            } else if (PlayerController.p1Score == 2) {
                p1Score2.SetActive(true);
            } else if (PlayerController.p1Score == 3) {
                p1Score3.SetActive(true);
            }

            if (PlayerController.p2Score == 0) {
                p2Score0.SetActive(true);
            } else if (PlayerController.p2Score == 1) {
                p2Score1.SetActive(true);
            } else if (PlayerController.p2Score == 2) {
                p2Score2.SetActive(true);
            } else if (PlayerController.p2Score == 3) {
                p2Score3.SetActive(true);
            }

            Debug.Log(PlayerController.p1Score);
            Debug.Log(PlayerController.p2Score);

            pauseButton.SetActive(false);
            pauseOvercooked.GetComponent<Pause_Overcooked>().paused = false;
            pauseOvercooked.GetComponent<Pause_Overcooked>().PauseButton();

            gameCanEnd = false;

        }
    }
}