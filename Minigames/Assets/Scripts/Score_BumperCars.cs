using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_BumperCars : Score
{

    public GameObject bombSchtuff;
    public GameObject pauseBumperCars;

    // Start is called before the first frame update
    protected override void Start() {

    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();

        //checks number of lives for each player or when the timer reaches 0 to display score
        if ((currentTime <= 0f || bombSchtuff.GetComponent<BombSchtuff>().p1Lives == 0 || bombSchtuff.GetComponent<BombSchtuff>().p2Lives == 0) && gameCanEnd) {
            scoreTextbox.SetActive(true);

            if (bombSchtuff.GetComponent<BombSchtuff>().p1Lives > bombSchtuff.GetComponent<BombSchtuff>().p2Lives) {
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
                p1Wins[PlayerController.p1Score - 1] = "WaterWars";

            } else if (bombSchtuff.GetComponent<BombSchtuff>().p1Lives < bombSchtuff.GetComponent<BombSchtuff>().p2Lives) {
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
                p2Wins[PlayerController.p2Score - 1] = "WaterWars";

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
                p1Wins[PlayerController.p1Score - 1] = "WaterWars";
                p2Wins[PlayerController.p2Score - 1] = "WaterWars";

            }

            base.TokensUpdate();

            if (bombSchtuff.GetComponent<BombSchtuff>().p1Lives > bombSchtuff.GetComponent<BombSchtuff>().p2Lives) {
                p1Tokens[PlayerController.p1Score - 1].GetComponent<Animator>().SetBool("Spin", true);
            } else if (bombSchtuff.GetComponent<BombSchtuff>().p1Lives < bombSchtuff.GetComponent<BombSchtuff>().p2Lives) {
                p2Tokens[PlayerController.p2Score - 1].GetComponent<Animator>().SetBool("Spin", true);
            } else {
                p1Tokens[PlayerController.p1Score - 1].GetComponent<Animator>().SetBool("Spin", true);
                p2Tokens[PlayerController.p2Score - 1].GetComponent<Animator>().SetBool("Spin", true);
                Debug.Log("Nani");
            }

            p1Score.GetComponent<Text>().text = PlayerController.p1Score.ToString();
            p2Score.GetComponent<Text>().text = PlayerController.p2Score.ToString();

            pauseButton.SetActive(false);
            pauseBumperCars.GetComponent<Pause_BumperCars>().PauseButton();

            gameCanEnd = false;

        }
    }

    protected override void FixedUpdate() {

    }

}
