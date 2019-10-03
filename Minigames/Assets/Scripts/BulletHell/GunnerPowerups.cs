using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunnerPowerups : PowerupParent
{

    public PC_BulletHell GunnerRefP1;
    public PC_BulletHell GunnerRefP2;

    public Image P1PowerTimer;

    public Image P2PowerTimer;

    private PC_BulletHell currentShooter;

    public PC_BulletHell declareGunner;

    // Start is called before the first frame update
    void Start()
    {
        base.Spawn_Control();
        ConnectReference();
    }

    // Update is called once per frame
    void Update()
    {
        Deactivate();
    }
    private void FixedUpdate()
    {
        base.Spawn_Timer();


    }

    void ConnectReference()
    {
        GunnerRefP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PC_BulletHell>();
        GunnerRefP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PC_BulletHell>();

        

    }

    public override void ExecutePowerup(bool red, bool yellow, bool green, bool white)
    {
        if (red == true) { RedFiring();}
        else if (yellow == true) { YellowFiring();}
        else if (green == true) { GreenFiring(); }
        else if (white == true) { WhiteFiring(); }
       
    }

     public void RedFiring()
    {
        base.StartCoroutine(PowerupTimer(seconds:base.Powerup_Duration, declareGunner, Color.red));
        ObjectPool.pool_Instance.pool_RedProjTime = true;
            
       
    }
    public void YellowFiring()
    {
        base.StartCoroutine(PowerupTimer(seconds: base.Powerup_Duration, declareGunner, Color.yellow));
        ObjectPool.pool_Instance.pool_YellowProjTime = true;
            
   

    }
    public void GreenFiring()
    {
        base.StartCoroutine(PowerupTimer(seconds: base.Powerup_Duration, declareGunner, Color.green));
        ObjectPool.pool_Instance.pool_GreenProjTime = true;
           
      
    }
    public void WhiteFiring()
    {
        base.StartCoroutine(PowerupTimer(seconds: base.Powerup_Duration, declareGunner, Color.white));

        if (GunnerRefP1.bHell_isShoot == true)
        {
            GunnerRefP1.AimingCreation();
        }
        else if (GunnerRefP2.bHell_isShoot == true)
        {
            GunnerRefP2.AimingCreation();
        }
        ObjectPool.pool_Instance.pool_WhiteProjTime = true;
         




    }

    public void GetGunner(PC_BulletHell Gunner)
    {
        //pass touched player here.

        declareGunner = Gunner;

    }


    public void Deactivate()
    {   
        if(Powerup_Activated == false) { 
        ObjectPool.pool_Instance.pool_RedProjTime = false;
        ObjectPool.pool_Instance.pool_YellowProjTime = false;
        ObjectPool.pool_Instance.pool_GreenProjTime = false;
        ObjectPool.pool_Instance.pool_WhiteProjTime = false;
            ExecutePowerup(false, false, false, false);
            GunnerRefP1.AimingDestroy();
            GunnerRefP2.AimingDestroy();
        }
    }
}
