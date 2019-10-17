using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

    public GameObject bo;
    public GameObject hiro;
    public GameObject mika;
    public GameObject otherBo;
    public GameObject otherHiro;
    public GameObject otherMika;
    public GameObject tagBo;
    public GameObject tagHiro;
    public GameObject tagMika;
    public GameObject readyButton;
    public GameObject unreadyButton;
    public GameObject otherPlayer;
    public GameObject sceneManagementScript;

    private bool boPicked;
    private bool hiroPicked;
    private bool mikaPicked;
    private Color blackenedColor = new Color(0.5f, 0.5f, 0.5f, 1);
    public bool ready;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    //selecting and deselecting Bo
    public void BoSelected() {
        if (bo.GetComponent<Image>().color != blackenedColor && !ready && !hiroPicked && !mikaPicked) {
            if (!boPicked) {
                boPicked = true;
                tagBo.SetActive(true);
                otherBo.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                readyButton.SetActive(true);
            } else if (boPicked) {
                boPicked = false;
                tagBo.SetActive(false);
                otherBo.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1);
                readyButton.SetActive(false);
            }
        }
    }

    //selecting and deselecting Hiro
    public void HiroSelected() {
        if (hiro.GetComponent<Image>().color != blackenedColor && !ready && !boPicked && !mikaPicked) {
            if (!hiroPicked) {
                hiroPicked = true;
                tagHiro.SetActive(true);
                otherHiro.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                readyButton.SetActive(true);
            } else if (hiroPicked) {
                hiroPicked = false;
                tagHiro.SetActive(false);
                otherHiro.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1);
                readyButton.SetActive(false);
            }
        }
    }

    //selecting and deselecting Mika
    public void MikaSelected() {
        if (mika.GetComponent<Image>().color != blackenedColor && !ready && !boPicked && !hiroPicked) {
            if (!mikaPicked) {
                mikaPicked = true;
                tagMika.SetActive(true);
                otherMika.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                readyButton.SetActive(true);
            } else if (mikaPicked) {
                mikaPicked = false;
                tagMika.SetActive(false);
                otherMika.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1);
                readyButton.SetActive(false);
            }
        }
    }

    //confirms the characters selected and carries it over to the minigames
    public void ConfirmCharacters() {
        if (!ready) {
            ready = true;
            readyButton.SetActive(false);
            unreadyButton.SetActive(true);
            if (boPicked) {
                if (gameObject.tag == "Player1") {
                    CharacterCarryOver.player1 = "Bo";
                } else {
                    CharacterCarryOver.player2 = "Bo";
                }
            } else if (hiroPicked) {
                if (gameObject.tag == "Player1") {
                    CharacterCarryOver.player1 = "Hiro";
                } else {
                    CharacterCarryOver.player2 = "Hiro";
                }
            } else if (mikaPicked) {
                if (gameObject.tag == "Player1") {
                    CharacterCarryOver.player1 = "Mika";
                } else {
                    CharacterCarryOver.player2 = "Mika";
                }
            }
        } else {
            ready = false;
            readyButton.SetActive(true);
            unreadyButton.SetActive(false);
        }

        if (ready && otherPlayer.GetComponent<CharacterSelect>().ready == true) {
            PlayerController.p1Score = 0;
            PlayerController.p2Score = 0;
            SceneManagement.scenes = new List<int>(Enumerable.Range(1, 3));
            sceneManagementScript.GetComponent<SceneManagement>().NextMinigame();
        }
    }
}
