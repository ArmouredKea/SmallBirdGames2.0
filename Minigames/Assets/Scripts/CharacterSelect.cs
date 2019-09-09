using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

    private static int playerClicks;
    public GameObject c1Text;
    public GameObject c2Text;
    public GameObject c3Text;
    public GameObject confirmButton;
    public GameObject heading;

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
            heading.GetComponent<Text>().text = "Are you ready?";
            confirmButton.SetActive(true);
        } else if (playerClicks == 1) {
            heading.GetComponent<Text>().text = "Player 2's turn to pick!";
            confirmButton.SetActive(false);
        } else {
            heading.GetComponent<Text>().text = "Player 1's turn to pick!";
            confirmButton.SetActive(false);
        }
    }

    //selecting and deselecting Bo
    public void BoSelected() {
        if (playerClicks == 0) {
            c1Text.SetActive(true);
            c1Text.GetComponent<Text>().text = "P1";
            boPicked = true;
            playerClicks++;
        } else if (playerClicks == 1) {
            if (boPicked) {
                c1Text.SetActive(false);
                boPicked = false;
                playerClicks--;
            } else if (!boPicked) {
                c1Text.SetActive(true);
                c1Text.GetComponent<Text>().text = "P2";
                boPicked = true;
                playerClicks++;
            }
        } else if (playerClicks == 2 && boPicked && c1Text.GetComponent<Text>().text == "P2") {
            c1Text.SetActive(false);
            boPicked = false;
            playerClicks--;
        }
    }

    //selecting and deselecting Hiro
    public void HiroSelected() {
        if (playerClicks == 0) {
            c2Text.SetActive(true);
            c2Text.GetComponent<Text>().text = "P1";
            hiroPicked = true;
            playerClicks++;
        } else if (playerClicks == 1) {
            if (hiroPicked) {
                c2Text.SetActive(false);
                hiroPicked = false;
                playerClicks--;
            } else if (!hiroPicked) {
                c2Text.SetActive(true);
                c2Text.GetComponent<Text>().text = "P2";
                hiroPicked = true;
                playerClicks++;
            }
        } else if (playerClicks == 2 && hiroPicked && c2Text.GetComponent<Text>().text == "P2") {
            c2Text.SetActive(false);
            hiroPicked = false;
            playerClicks--;
        }
    }

    //selecting and deselecting Mika
    public void MikaSelected() {
        if (playerClicks == 0) {
            c3Text.SetActive(true);
            c3Text.GetComponent<Text>().text = "P1";
            mikaPicked = true;
            playerClicks++;
        } else if (playerClicks == 1) {
            if (mikaPicked) {
                c3Text.SetActive(false);
                mikaPicked = false;
                playerClicks--;
            } else if (!mikaPicked) {
                c3Text.SetActive(true);
                c3Text.GetComponent<Text>().text = "P2";
                mikaPicked = true;
                playerClicks++;
            }
        } else if (playerClicks == 2 && mikaPicked && c3Text.GetComponent<Text>().text == "P2") {
            c3Text.SetActive(false);
            mikaPicked = false;
            playerClicks--;
        }
    }
}
