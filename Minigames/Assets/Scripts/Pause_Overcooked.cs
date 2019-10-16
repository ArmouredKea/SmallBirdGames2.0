using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Overcooked : Pause
{
    public GameObject PauseMenuRef;
    public GameObject countDownref;
    public GameObject canvaspausebutton;
    public GameObject countdown;
    public GameObject tutorial;
    public GameObject timer;
    public GameObject audioManager;

    // Start is called before the first frame update
    public void Start() {
        canvaspausebutton.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    // Update is called once per frame
    void Update() {

    }

    public void closeTutorial() {
        tutorial.SetActive(false);
        countdown.SetActive(true);
        StartCoroutine(Countdown());
    }

    //pause and unpause for Overcooked.
    public override void PauseButton() {

        if (!inTutorial) {
            if (!paused) {
                Component[] childrenCharacterScripts;
                childrenCharacterScripts = GetComponentsInChildren(typeof(PC_Overcooked));

                if (childrenCharacterScripts != null) {
                    foreach (PC_Overcooked character in childrenCharacterScripts) {
                        character.paused = true;
                    }
                }

                Component[] childrenTimerScripts;
                childrenTimerScripts = GetComponentsInChildren(typeof(GameController));

                if (childrenTimerScripts != null) {
                    foreach (GameController timer in childrenTimerScripts) {
                        timer.paused = true;
                    }
                }

                /*  Component[] childrenItemControllerScripts;
                  childrenItemControllerScripts = GetComponentsInChildren(typeof(ItemController));

                  if (childrenItemControllerScripts != null) {
                      foreach (ItemController itemController in childrenItemControllerScripts) {
                          itemController.paused = true;
                      }
                  } */

                paused = true;
                timer.GetComponent<Score_Overcooked>().paused = true;
                //line Luke added to show the pause menu
                if (canPause) {
                    PauseMenuRef.GetComponent<PauseMenu>().togglePauseMenu();
                }
                //------------
                if (!canPause) {
                    inTutorial = true;
                    canPause = true;
                }
            } else {
                Component[] childrenCharacterScripts;
                childrenCharacterScripts = GetComponentsInChildren(typeof(PC_Overcooked));

                if (childrenCharacterScripts != null) {
                    foreach (PC_Overcooked character in childrenCharacterScripts) {
                        character.paused = false;
                    }
                }

                Component[] childrenTimerScripts;
                childrenTimerScripts = GetComponentsInChildren(typeof(GameController));

                if (childrenTimerScripts != null) {
                    foreach (GameController timer in childrenTimerScripts) {
                        timer.paused = false;
                    }
                }

                /* Component[] childrenItemControllerScripts;
                childrenItemControllerScripts = GetComponentsInChildren(typeof(ItemController));

                if (childrenItemControllerScripts != null) {
                    foreach (ItemController itemController in childrenItemControllerScripts) {
                        itemController.paused = false;
                    }
                } */

                paused = false;
                timer.GetComponent<Score_Overcooked>().paused = false;
            }
        } else {
            PauseMenuRef.GetComponent<PauseMenu>().togglePauseMenu();
        }

    }

    //countdown before game begins
    public IEnumerator Countdown() {

        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 4f;
        int i = 0;
        while (Time.realtimeSinceStartup < pauseTime) {
            if (i == 0 && (pauseTime - Time.realtimeSinceStartup > 3) && (pauseTime - Time.realtimeSinceStartup < 4)) {
                audioManager.GetComponent<AudioManagerScript>().PlayAudio("Button");
                i++;
            } else if (i == 1 && (pauseTime - Time.realtimeSinceStartup > 2) && (pauseTime - Time.realtimeSinceStartup < 3)) {
                audioManager.GetComponent<AudioManagerScript>().PlayAudio("Button");
                i++;
            } else if (i == 2 && (pauseTime - Time.realtimeSinceStartup > 1) && (pauseTime - Time.realtimeSinceStartup < 2)) {
                audioManager.GetComponent<AudioManagerScript>().PlayAudio("Button");
                i++;
            } else if (i == 3 && (pauseTime - Time.realtimeSinceStartup > 0) && (pauseTime - Time.realtimeSinceStartup < 1)) {
                audioManager.GetComponent<AudioManagerScript>().PlayAudio("Button");
                i++;
            }
            yield return 0;
        }

        Time.timeScale = 1;
        countDownref.SetActive(false);
        paused = false;
        canvaspausebutton.SetActive(true);
    }
}
