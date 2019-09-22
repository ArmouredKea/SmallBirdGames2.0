using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

    private static int playerClicks;
    public GameObject boP1;
    public GameObject boP2;
    public GameObject hiroP1;
    public GameObject hiroP2;
    public GameObject mikaP1;
    public GameObject mikaP2;
    public GameObject confirmButton;
    public GameObject headingP1;
    public GameObject headingP2;
    public GameObject headingReady;

    private bool boPicked;
    private bool hiroPicked;
    private bool mikaPicked;


    // Start is called before the first frame update
    void Start() {
        playerClicks = 0;
    }

    // Update is called once per frame
    void Update() {
        //checks whose turn it is to pick a character, and whether both players have already picked
        if (playerClicks == 2) {
            headingReady.SetActive(true);
            headingP1.SetActive(false);
            headingP2.SetActive(false);
            confirmButton.SetActive(true);
        } else if (playerClicks == 1) {
            headingReady.SetActive(false);
            headingP1.SetActive(false);
            headingP2.SetActive(true);
            confirmButton.SetActive(false);
        } else {
            headingReady.SetActive(false);
            headingP1.SetActive(true);
            headingP2.SetActive(false);
            confirmButton.SetActive(false);
        }
    }

    //selecting and deselecting Bo
    public void BoSelected() {
        if (playerClicks == 0) {
            boP1.SetActive(true);
            boPicked = true;
            playerClicks++;
        } else if (playerClicks == 1) {
            if (boPicked) {
                boP1.SetActive(false);
                boPicked = false;
                playerClicks--;
            } else if (!boPicked) {
                boP2.SetActive(true);
                boPicked = true;
                playerClicks++;
            }
        } else if (playerClicks == 2 && boPicked && boP2.activeSelf == true) {
            boP2.SetActive(false);
            boPicked = false;
            playerClicks--;
        }
    }

    //selecting and deselecting Hiro
    public void HiroSelected() {
        if (playerClicks == 0) {
            hiroP1.SetActive(true);
            hiroPicked = true;
            playerClicks++;
        } else if (playerClicks == 1) {
            if (hiroPicked) {
                hiroP1.SetActive(false);
                hiroPicked = false;
                playerClicks--;
            } else if (!hiroPicked) {
                hiroP2.SetActive(true);
                hiroPicked = true;
                playerClicks++;
            }
        } else if (playerClicks == 2 && hiroPicked && hiroP2.activeSelf == true) {
            hiroP2.SetActive(false);
            hiroPicked = false;
            playerClicks--;
        }
    }

    //selecting and deselecting Mika
    public void MikaSelected() {
        if (playerClicks == 0) {
            mikaP1.SetActive(true);
            mikaPicked = true;
            playerClicks++;
        } else if (playerClicks == 1) {
            if (mikaPicked) {
                mikaP1.SetActive(false);
                mikaPicked = false;
                playerClicks--;
            } else if (!mikaPicked) {
                mikaP2.SetActive(true);
                mikaPicked = true;
                playerClicks++;
            }
        } else if (playerClicks == 2 && mikaPicked && mikaP2.activeSelf == true) {
            mikaP2.SetActive(false);
            mikaPicked = false;
            playerClicks--;
        }
    }

    //confirms the characters selected and carries it over to the minigames
    public void ConfirmCharacters() {
        if (boP1.activeSelf == true) {
            CharacterCarryOver.player1 = "Bo";
        } else if (hiroP1.activeSelf == true) {
            CharacterCarryOver.player1 = "Hiro";
        } else if (mikaP1.activeSelf == true) {
            CharacterCarryOver.player1 = "Mika";
        }

        if (boP2.activeSelf == true) {
            CharacterCarryOver.player2 = "Bo";
        } else if (hiroP2.activeSelf == true) {
            CharacterCarryOver.player2 = "Hiro";
        } else if (mikaP2.activeSelf == true) {
            CharacterCarryOver.player2 = "Mika";
        }

        PlayerController.p1Score = 0;
        PlayerController.p2Score = 0;
        gameObject.GetComponent<SceneManagement>().NextMinigame();
    }
}
