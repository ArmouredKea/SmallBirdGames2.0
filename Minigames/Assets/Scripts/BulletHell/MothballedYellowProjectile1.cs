using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothballedYellowProjectile : ProjectileParent
{
    private float savedSine;
    private float savedMag;
    private float savedMagBase;
    private float savedFreq;
    private float savedSpeed;

    private Vector3 savePos;
    private Vector3 saveAxis;
    // Start is called before the first frame update




        /// <summary>
        /// Rework entire Yellow Projectile
        /// Figure out what kind of projectile is worth making
        /// Split? Use Red random stop, but instead have the projectile create child projectiles at random rotations. aka transform.forward
        /// Decrease speed for awhile when hit by yellow?
        /// </summary>
    public override void Start()
    {
        base.Initialize();
        
    }

    public override void OnEnable()
    {
        base.Initialize();
        base.SineInitialize();
        magnitudeSine = 0;
    }


    public override void Awake()
    {
       
       
        

    }
    // Update is called once per frame
    public override void Update()
    {
       

    }

    private void FixedUpdate()
    {
        base.SineMovement();
        StartCoroutine(TempNormalMove());

        if (paused == true)
        {
           
            Debug.Log("STOP");
        }

    }

    public void PauseProj()
    {
        pauseVelocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        paused = true;
        savedMag = magnitudeSine;
        savedSine = rateSine;
        savedFreq = frequencySine;
        savedMagBase = base_magnitudeSine;
        savedSpeed = Speed;

      

        while (paused == true)
        {
            rateSine = 0;
            frequencySine = 0;
            magnitudeSine = 0;
            base_magnitudeSine = 0;
            Speed = 0;
            break;
        }
        
    }

    public void UnpauseProj()
    {
        GetComponent<Rigidbody2D>().velocity = pauseVelocity;
        paused = false;

        rateSine = savedSine;
        frequencySine = savedFreq;
        //magnitudeSine = savedMag;
        base_magnitudeSine = savedMagBase;
        Speed = 5;
    }
}
