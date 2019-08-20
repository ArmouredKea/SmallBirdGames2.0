using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedProjectile : ProjectileParent
{
    private float DeactivateChance;
    private float DeactivateTimer;

    //Red Balloon Projectile class.

    // Start is called before the first frame update
    //Be fast, but random lifetime.

    public override void OnEnable()
    {
        base.Movement();
        
        InvokeRepeating("ChanceToDeactivate", 0.5f, 0.5f);

    }

    // Update is called once per frame

    void FixedUpdate()
    {
    }

    public virtual void ChanceToDeactivate()
    {
        if (paused == false) { 
            if(Random.Range(0,10)<= 3)
            {
                gameObject.SetActive(false);
                CancelInvoke("ChanceToDeactivate");
            }
        }
    }

    public void PauseProj()
    {
        pauseVelocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        paused = true;
    }

    public void UnpauseProj()
    {
        GetComponent<Rigidbody2D>().velocity = pauseVelocity;
        paused = false;
    }
}
