using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowProjectile : ProjectileParent
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Initialize();

    }

    public override void OnEnable()
    {
     
        base.SineInitialize();
        base.magnitudeSine = 0;
    }


    public override void Awake()
    {
       
        base.Initialize();
        

    }
    // Update is called once per frame
    public override void Update()
    {
        base.SineMovement();
        StartCoroutine(TempNormalMove());


    }
}
