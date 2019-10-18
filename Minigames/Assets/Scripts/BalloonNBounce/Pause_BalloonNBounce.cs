using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_BalloonNBounce : Pause
{

    public GameObject countTimer;
    public GameObject timer;
    public ObjectPool2 poolManage;
    public GunnerPowerupsBalloon gPowerup;
    public RunnerPowerupsBalloon rPowerup;
    public GameObject PauseMenuRef;
    public BalloonBounceManage BhellManage;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public override void PauseButton()
    {

        if (!inTutorial) {
            if (!paused) {
                Component[] childrenCharacterScripts;
                childrenCharacterScripts = GetComponentsInChildren(typeof(PC_BalloonNBounce));

                if (childrenCharacterScripts != null) {
                    foreach (PC_BalloonNBounce character in childrenCharacterScripts) {
                        character.PauseCharacter();
                    }
                }

                poolManage.PausePool(true); //This calls the ObjectPool, which already has access to all active proj.
                timer.GetComponent<Score_BalloonNBounce>().paused = true;
                //countTimer.GetComponent<CountdownTimer>().paused = true;
               // gPowerup.paused = true;
                //rPowerup.paused = true;
               // rPowerup.paused = true;
                paused = true;
                BhellManage.paused = true;
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
                childrenCharacterScripts = GetComponentsInChildren(typeof(PC_BalloonNBounce));

                if (childrenCharacterScripts != null) {
                    foreach (PC_BalloonNBounce character in childrenCharacterScripts) {
                        character.UnpauseCharacter();
                    }
                }


                timer.GetComponent<Score_BalloonNBounce>().paused = false;

                //projManage_B.GetComponent<BombSchtuff>().paused = false;

                paused = false;
                gPowerup.paused = false;
                rPowerup.paused = false;
                poolManage.PausePool(false);
                BhellManage.paused = false;
            }
        } else {
            PauseMenuRef.GetComponent<PauseMenu>().togglePauseMenu();
        }

    }


}
