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

        if (paused) {
            Component[] childrenActorScripts;
            childrenActorScripts = GetComponentsInChildren(typeof(PC_BumperCars));

            if (childrenActorScripts != null) {
                foreach (PC_BumperCars actor in childrenActorScripts) {
                    actor.PauseCharacter();
                }
            }

            paused = false;

        } else {
            Component[] childrenActorScripts;
            childrenActorScripts = GetComponentsInChildren(typeof(PC_BumperCars));

            if (childrenActorScripts != null) {
                foreach (PC_BumperCars actor in childrenActorScripts) {
                    actor.UnpauseCharacter();
                }
            }

            paused = true;

        }

    }

}
