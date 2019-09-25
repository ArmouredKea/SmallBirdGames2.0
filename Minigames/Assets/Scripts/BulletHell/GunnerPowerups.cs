using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerPowerups : PowerupParent
{

    public PC_BulletHell GunnerRefP1;
    public PC_BulletHell GunnerRefP2;
    private PC_BulletHell currentShooter;

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
        base.StartCoroutine(PowerupTimer(seconds:base.Powerup_Duration));
        ObjectPool.pool_Instance.pool_RedProjTime = true;
            
       
    }
    public void YellowFiring()
    {
        base.StartCoroutine(PowerupTimer(base.Powerup_Duration));
        ObjectPool.pool_Instance.pool_YellowProjTime = true;
            
   

    }
    public void GreenFiring()
    {
        base.StartCoroutine(PowerupTimer(base.Powerup_Duration));
        ObjectPool.pool_Instance.pool_GreenProjTime = true;
           
      
    }
    public void WhiteFiring()
    {
        base.StartCoroutine(PowerupTimer(base.Powerup_Duration));

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
