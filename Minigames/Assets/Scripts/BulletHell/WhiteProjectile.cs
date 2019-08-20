using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteProjectile : ProjectileParent
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Initialize();
    }


    public override void OnEnable()
    {
        base.OnEnable();
        base.Movement();

    }

    // Update is called once per frame
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