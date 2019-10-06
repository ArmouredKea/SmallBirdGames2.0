using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialsUI : MonoBehaviour
{

    public GameObject[] tutorials;
    public GameObject next;
    public GameObject back;
    public GameObject readyButton;
    public GameObject readyText;
    public GameObject countdownScript;
    public GameObject countdownTimer;
    public GameObject bombSchtuff;
    public GameObject pauseButton;
    public GameObject pauseScript;

    public GameObject otherPlayer;

    public bool ready;
    public int i = 0;

    // Start is called before the first frame updatepublic 
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void NextTutorial() {
        tutorials[i].SetActive(false);
        i++;
        tutorials[i].SetActive(true);
        
        if (i == (tutorials.Length - 1)) {
            next.SetActive(false);
            readyButton.SetActive(true);
        } else if (i >= 1) {
            back.SetActive(true);
        }
    }

    public void PreviousTutorial() {
        tutorials[i].SetActive(false);
        i--;
        tutorials[i].SetActive(true);

        if (i == 0) {
            back.SetActive(false);
        } else if (i == (tutorials.Length - 2)) {
            next.SetActive(true);
            readyButton.SetActive(false);
        }
    }

    public void Ready() {
        tutorials[i].SetActive(false);
        ready = true;
        readyText.SetActive(true);
        next.SetActive(false);
        back.SetActive(false);
        readyButton.SetActive(false);

        if (otherPlayer.GetComponent<TutorialsUI>().ready == true) {
            readyText.SetActive(false);
            otherPlayer.GetComponent<TutorialsUI>().readyText.SetActive(false);
            pauseButton.SetActive(true);
            countdownTimer.SetActive(true);
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "BumperCarsMG") {
                StartCoroutine(countdownScript.GetComponent<CountdownTimer>().Countdown());
                StartCoroutine(bombSchtuff.GetComponent<BombSchtuff>().SpawnBomb(1.5f));
            } else if (scene.name == "OvercookedMG") {
                StartCoroutine(countdownScript.GetComponent<Pause_Overcooked>().Countdown());
            } else if (scene.name == "BulletHell") {
                StartCoroutine(countdownScript.GetComponent<CountdownTimer>().Countdown());
            }
            pauseScript.GetComponent<Pause>().PauseButton();
        }
    }

}
