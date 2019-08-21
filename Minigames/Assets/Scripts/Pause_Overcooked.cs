using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Overcooked : Pause
{
    public GameObject PauseMenuRef;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public override void PauseButton() {

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

            Component[] childrenDispenserScripts;
            childrenDispenserScripts = GetComponentsInChildren(typeof(Dispenser));

            if (childrenDispenserScripts != null) {
                foreach (Dispenser dispenser in childrenDispenserScripts) {
                    dispenser.paused = true;
                }
            }

            paused = true;
            //line Luke added to show the pause menu
            PauseMenuRef.GetComponent<PauseMenu>().togglePauseMenu();
            //------------

        }
        else {
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

            Component[] childrenDispenserScripts;
            childrenDispenserScripts = GetComponentsInChildren(typeof(Dispenser));

            if (childrenDispenserScripts != null) {
                foreach (Dispenser dispenser in childrenDispenserScripts) {
                    dispenser.paused = false;
                }
            }

            paused = false;

        }

    }
}
