﻿using System.Collections;
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

    //pause and unpause for Overcooked.
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

            Component[] childrenItemControllerScripts;
            childrenItemControllerScripts = GetComponentsInChildren(typeof(ItemController));

            if (childrenItemControllerScripts != null) {
                foreach (ItemController itemController in childrenItemControllerScripts) {
                    itemController.paused = true;
                }
            }

            paused = true;
            //line Luke added to show the pause menu
            PauseMenuRef.GetComponent<PauseMenu>().togglePauseMenu();
            //------------

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

            Component[] childrenItemControllerScripts;
            childrenItemControllerScripts = GetComponentsInChildren(typeof(ItemController));

            if (childrenItemControllerScripts != null) {
                foreach (ItemController itemController in childrenItemControllerScripts) {
                    itemController.paused = false;
                }
            }

            paused = false;

        }

    }
}
