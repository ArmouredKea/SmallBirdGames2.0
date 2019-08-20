using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenProjectile : ProjectileParent
{
    // Start is called before the first frame update

    public override void OnEnable()
    {
        base.OnEnable();
        base.Movement();
        base.GrowReset();

    }

    // Update is called once per frame

    public override void Update()
    {
        if (paused == false)
        {
            base.Update();
            StartCoroutine(GrowTime());
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
