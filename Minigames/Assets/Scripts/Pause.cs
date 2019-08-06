using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButton() {

        if (paused == false) {
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
            paused = true;
        } else {
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
            paused = false;
        }

    }

}
