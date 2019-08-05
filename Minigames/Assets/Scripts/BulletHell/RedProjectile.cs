using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedProjectile : ProjectileParent
{


    //Red Balloon Projectile class.

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
    }

    public override void OnEnable()
    {
        base.Movement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
