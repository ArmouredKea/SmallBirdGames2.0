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
  
}
