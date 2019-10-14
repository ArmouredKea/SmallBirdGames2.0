using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowProjectile : ProjectileParent
{

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
        base.Movement();

        InvokeRepeating("ChanceToSplit", 0.5f, 0.5f);
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

    }

    public void UnpauseProj()
    {
        GetComponent<Rigidbody2D>().velocity = pauseVelocity;
        paused = false;


    }

    public virtual void ChanceToSplit()
    {
        if (paused == false)
        {
            if (Random.Range(0, 10) <= 9)
            {
                //gameObject.SetActive(false);
                Split();
                CancelInvoke("ChanceToSplit");
            }
        }
    }


    public void Split()
    {
        if(ObjectPool.pool_Instance.pool_YellowProjTime == true) {
        GameObject YellowSplit1 = ObjectPool.pool_Instance.GetPooledObject();


            if(YellowSplit1 != null) {
            YellowSplit1.transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * transform.rotation;
            YellowSplit1.transform.position = gameObject.transform.position;
            YellowSplit1.SetActive(true);
            YellowSplit1.GetComponent<YellowProjectile>().firedFrom = firedFrom;
            gameObject.transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * transform.rotation;
            }
            //this.gameObject.transform.Rotate(0.0, 0.0, Random.Range(0.0, 360.0));
        }


    }
        }
