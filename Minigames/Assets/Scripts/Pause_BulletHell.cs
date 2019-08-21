using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_BulletHell : Pause
{

    public GameObject countTimer;
    public ObjectPool poolManage;
    public GunnerPowerups gPowerup;
    public RunnerPowerups rPowerup;
    public GameObject PauseMenuRef;


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

        if (!paused)
        {
            Component[] childrenCharacterScripts;
            childrenCharacterScripts = GetComponentsInChildren(typeof(PC_BulletHell));

            if (childrenCharacterScripts != null)
            {
                foreach (PC_BulletHell character in childrenCharacterScripts)
                {
                    character.PauseCharacter();
                }
            }

            poolManage.PausePool(true); //This calls the ObjectPool, which already has access to all active proj.
            countTimer.GetComponent<CountdownTimer>().paused = true;
            gPowerup.paused = true;
            //rPowerup.paused = true;
            rPowerup.PauseEffect();
            paused = true;
            //line Luke added to show the pause menu
            PauseMenuRef.GetComponent<PauseMenu>().togglePauseMenu();
            //------------
        }
        else
        {
            Component[] childrenCharacterScripts;
            childrenCharacterScripts = GetComponentsInChildren(typeof(PC_BulletHell));

            if (childrenCharacterScripts != null)
            {
                foreach (PC_BulletHell character in childrenCharacterScripts)
                {
                    character.UnpauseCharacter();
                }
            }



            countTimer.GetComponent<CountdownTimer>().paused = false;
            //projManage_B.GetComponent<BombSchtuff>().paused = false;

            paused = false;
            gPowerup.paused = false;
            rPowerup.UnpauseEffect();
            poolManage.PausePool(false);
        }

    }
}
