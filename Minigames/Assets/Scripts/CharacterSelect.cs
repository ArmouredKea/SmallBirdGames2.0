using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

    private static int playerClicks;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c1Text;
    public GameObject c2Text;
    public GameObject c3Text;
    public GameObject sceneCanvas;

    // Start is called before the first frame update
    void Start() {

        playerClicks = 0;

    }

    // Update is called once per frame
    void Update() {

    }

    //checks for first and second character selection on click/touch
    public void CharacterSelected() {

        playerClicks++;

        if (playerClicks == 1) {
            if (gameObject.name == "Character1") {
                c1Text.SetActive(true);
                c1Text.GetComponent<Text>().text = "P1";
                gameObject.SetActive(false);
            } else if (gameObject.name == "Character2") {
                c2Text.SetActive(true);
                c2Text.GetComponent<Text>().text = "P1";
                gameObject.SetActive(false);
            } else if (gameObject.name == "Character3") {
                c3Text.SetActive(true);
                c3Text.GetComponent<Text>().text = "P1";
                gameObject.SetActive(false);
            }
        } else if (playerClicks == 2) {
            if (gameObject.name == "Character1") {
                c1Text.SetActive(true);
                c1Text.GetComponent<Text>().text = "P2";
                sceneCanvas.GetComponent<SceneManagement>().NextMinigameDelay();
                gameObject.SetActive(false);
            } else if (gameObject.name == "Character2") {
                c2Text.SetActive(true);
                c2Text.GetComponent<Text>().text = "P2";
                sceneCanvas.GetComponent<SceneManagement>().NextMinigameDelay();
                gameObject.SetActive(false);
            } else if (gameObject.name == "Character3") {
                c3Text.SetActive(true);
                c3Text.GetComponent<Text>().text = "P2";
                sceneCanvas.GetComponent<SceneManagement>().NextMinigameDelay();
                gameObject.SetActive(false);
            }

        }

    }

}
