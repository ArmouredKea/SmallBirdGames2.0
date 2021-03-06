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
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
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

                CharacterCarryOver.p1Score++;
                p1Wins[CharacterCarryOver.p1Score - 1] = "FillingFrenzy";
                Debug.Log("Player 1: " + CharacterCarryOver.p1Score);
                Debug.Log("Player 2: " + CharacterCarryOver.p2Score);

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

                CharacterCarryOver.p2Score++;
                p2Wins[CharacterCarryOver.p2Score - 1] = "FillingFrenzy";
                Debug.Log("Player 1: " + CharacterCarryOver.p1Score);
                Debug.Log("Player 2: " + CharacterCarryOver.p2Score);

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

                CharacterCarryOver.p1Score++;
                CharacterCarryOver.p2Score++;
                p1Wins[CharacterCarryOver.p1Score - 1] = "FillingFrenzy";
                p2Wins[CharacterCarryOver.p2Score - 1] = "FillingFrenzy";
                Debug.Log("Player 1: " + CharacterCarryOver.p1Score);
                Debug.Log("Player 2: " + CharacterCarryOver.p2Score);

            }

            base.TokensUpdate();

            //tokens animation
            if (player1.GetComponent<GameController>().points > player2.GetComponent<GameController>().points) {
                p1Tokens[CharacterCarryOver.p1Score - 1].GetComponent<Animator>().enabled = true;
                p1Tokens[CharacterCarryOver.p1Score - 1].GetComponent<Animator>().SetBool("Spin", true);
            } else if (player1.GetComponent<GameController>().points < player2.GetComponent<GameController>().points) {
                p2Tokens[CharacterCarryOver.p2Score - 1].GetComponent<Animator>().SetBool("Spin", true);
                p2Tokens[CharacterCarryOver.p2Score - 1].GetComponent<Animator>().enabled = true;
            } else {
                p1Tokens[CharacterCarryOver.p1Score - 1].GetComponent<Animator>().enabled = true;
                p2Tokens[CharacterCarryOver.p2Score - 1].GetComponent<Animator>().enabled = true;
                p1Tokens[CharacterCarryOver.p1Score - 1].GetComponent<Animator>().SetBool("Spin", true);
                p2Tokens[CharacterCarryOver.p2Score - 1].GetComponent<Animator>().SetBool("Spin", true);
            }
            StartCoroutine(TokenSound(0.9f));

            p1Score.GetComponent<Text>().text = CharacterCarryOver.p1Score.ToString();
            p2Score.GetComponent<Text>().text = CharacterCarryOver.p2Score.ToString();

            pauseButton.SetActive(false);
            pauseOvercooked.GetComponent<Pause_Overcooked>().PauseButton();

            gameCanEnd = false;
        }
    }

    protected override void FixedUpdate() {

    }
}
