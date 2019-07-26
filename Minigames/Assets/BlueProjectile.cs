using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueProjectile : ProjectileParent
{
    // Start is called before the first frame update
    void Start()
    {
        
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
