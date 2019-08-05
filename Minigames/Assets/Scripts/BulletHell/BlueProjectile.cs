using System.Collections;
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
        
    }
    // Update is called once per frame
}
