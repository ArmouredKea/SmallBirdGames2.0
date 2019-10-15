using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_BumperCars : Pause
{

    public GameObject timer;
    public GameObject bombSchtuff;
    public GameObject PauseMenuRef;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ResetVariables() {
        Component[] childrenBombScripts;
        childrenBombScripts = GetComponentsInChildren(typeof(BombMovement));

        if (childrenBombScripts != null) {
            foreach (BombMovement bomb in childrenBombScripts) {
                bomb.p1Invulnerable = false;
                bomb.p2Invulnerable = false;
            }
        }
        Physics2D.IgnoreLayerCollision(8, 10, false);
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    //pause and unpause for BumperCars.
    public override void PauseButton() {

        if (!paused) {
            Component[] childrenCharacterScripts;
            childrenCharacterScripts = GetComponentsInChildren(typeof(PC_BumperCars));

            if (childrenCharacterScripts != null) {
                foreach (PC_BumperCars character in childrenCharacterScripts) {
                    character.PauseCharacter();
                }
            }

            Component[] childrenBombScripts;
            childrenBombScripts = GetComponentsInChildren(typeof(BombMovement));

            if (childrenBombScripts != null) {
                foreach (BombMovement bomb in childrenBombScripts) {
                    bomb.PauseBomb();
                }
            }

            foreach (Transform child in transform) {
                if (child.tag == "ExclamationMark")
                    child.gameObject.GetComponent<Animator>().speed = 0;
            }

            timer.GetComponent<Score_BumperCars>().paused = true;
            bombSchtuff.GetComponent<BombSchtuff>().paused = true;
            paused = true;
            //line Luke added to show the pause menu
            if (inTutorial) {
                PauseMenuRef.GetComponent<PauseMenu>().togglePauseMenu();
            }
            //------------
            inTutorial = true;
        } else {
            if (!inTutorial) {
                Component[] childrenCharacterScripts;
                childrenCharacterScripts = GetComponentsInChildren(typeof(PC_BumperCars));

                if (childrenCharacterScripts != null) {
                    foreach (PC_BumperCars character in childrenCharacterScripts) {
                        character.UnpauseCharacter();
                    }
                }

                Component[] childrenBombScripts;
                childrenBombScripts = GetComponentsInChildren(typeof(BombMovement));

                if (childrenBombScripts != null) {
                    foreach (BombMovement bomb in childrenBombScripts) {
                        bomb.UnpauseBomb();
                    }
                }

                foreach (Transform child in transform) {
                    if (child.tag == "ExclamationMark")
                        child.gameObject.GetComponent<Animator>().speed = 1;
                }

                timer.GetComponent<Score_BumperCars>().paused = false;
                bombSchtuff.GetComponent<BombSchtuff>().paused = false;
                paused = false;
            }
        }        

    }
}
