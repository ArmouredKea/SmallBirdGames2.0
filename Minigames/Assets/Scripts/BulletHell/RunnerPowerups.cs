using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPowerups : PowerupParent
{

    [SerializeField]
    private PC_BulletHell declareRunner;

    [SerializeField]
    private float powerupSpeed = 10;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Deactivate();
    }
    private void FixedUpdate()
    {
        if (paused == false)
        {
            base.Spawn_Timer();
        }
    }
    public override void ExecutePowerup(bool red, bool yellow, bool green, bool white)
    {
        if (red == true) { RedPowerup(); }
        else if (yellow == true) { YellowPowerup(); }
        //else if (green == true) { GreenPowerup(); }
        //else if (white == true) { WhitePowerup(); }

    }

    public void GetRunner(PC_BulletHell runner)
    {
        //pass touched player here.

        declareRunner = runner;

    }

    public void RedPowerup()
    {
        base.StartCoroutine(PowerupTimer(seconds: base.Powerup_Duration));
        declareRunner.speed = powerupSpeed;
        declareRunner.GetComponentInChildren<ParticleSystem>().Play(true);


    }
    public void YellowPowerup()
    {
        //base.StartCoroutine(PowerupTimer(base.Powerup_Duration));
        declareRunner.ShieldCreation();
        
        

        //Create/append visual effect here.
        




    }
    public void GreenPowerup()
    {
        base.StartCoroutine(PowerupTimer(base.Powerup_Duration));
        ObjectPool.pool_Instance.pool_GreenProjTime = true;


    }
    public void WhitePowerup()
    {
        base.StartCoroutine(PowerupTimer(base.Powerup_Duration));

        ObjectPool.pool_Instance.pool_WhiteProjTime = true;


    }
    public void Deactivate()
    {
        if (Powerup_Activated == false)
        {
           //stop powerup.
            ExecutePowerup(false, false, false, false);
            if(declareRunner != null)
            { 
                    declareRunner.speed = declareRunner.baseSpeed;
                    declareRunner.GetComponentInChildren<ParticleSystem>().Stop();
                declareRunner.GetComponentInChildren<ParticleSystem>().Clear();
            }

        }
    }

    public void PauseEffect()
    {
        if (declareRunner != null)
        {
            declareRunner.GetComponentInChildren<ParticleSystem>().Pause(true);
            declareRunner.GetComponentInChildren<ParticleSystem>().Stop(true);
            paused = true;
        }
    }
   
    public void UnpauseEffect()
    {
        if (declareRunner != null)
        {
            declareRunner.GetComponentInChildren<ParticleSystem>().Pause(false);
            declareRunner.GetComponentInChildren<ParticleSystem>().Play(true);
            paused = false;
        }
    }

}


