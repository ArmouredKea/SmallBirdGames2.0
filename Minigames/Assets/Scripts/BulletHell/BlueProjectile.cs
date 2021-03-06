﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueProjectile : ProjectileParent
{
    // Start is called before the first frame update

    public override void Start()
    {
        base.Start(); base.Initialize();
        //Make firing speed modes instead.?!
    }

    public override void OnEnable()
    {
        base.Movement();
        base.OnEnable();
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
