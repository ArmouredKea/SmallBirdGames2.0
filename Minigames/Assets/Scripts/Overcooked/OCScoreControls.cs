﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OCScoreControls : MonoBehaviour
{
    public GameObject player1Control;
    public GameObject player2Control;

    public GameObject endText;
    public GameObject overallScore;
    public GameObject minigameChanger;

    private bool gameEnded = true;

    void Start() {
        Time.timeScale = 1f;
    }

    void Update() {
        if (player1Control.gameObject.GetComponent<GameController>().gameEnd && gameEnded) {

            endText.SetActive(true);
            overallScore.SetActive(true);
            minigameChanger.SetActive(true);
            //adds score to overall score
            if (player1Control.gameObject.GetComponent<GameController>().points > player2Control.gameObject.GetComponent<GameController>().points) {
                CharacterCarryOver.p1Score++;
                endText.GetComponent<Text>().text = "Player 1 Wins!";
            } else if (player1Control.gameObject.GetComponent<GameController>().points < player2Control.gameObject.GetComponent<GameController>().points) {
                CharacterCarryOver.p2Score++;
                endText.GetComponent<Text>().text = "Player 2 Wins!";
            } else if (player1Control.gameObject.GetComponent<GameController>().points == player2Control.gameObject.GetComponent<GameController>().points) {
                CharacterCarryOver.p1Score++;
                CharacterCarryOver.p2Score++;
                endText.GetComponent<Text>().text = "Draw!";
            }

            overallScore.GetComponent<Text>().text = "[P1] " + CharacterCarryOver.p1Score + " - " + CharacterCarryOver.p2Score + " [P2]";
            gameEnded = false;
            Time.timeScale = 0;

        }

    }
}
