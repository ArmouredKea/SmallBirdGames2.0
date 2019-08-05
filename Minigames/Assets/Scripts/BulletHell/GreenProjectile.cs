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
        base.Update();
        StartCoroutine(GrowTime());


    }


}
