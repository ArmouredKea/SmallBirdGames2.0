using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_BulletHell : PlayerController
{
  public Vector2 currentPosition;
  public float totalDistance;
  public bool boosted;

    public bool bHell_isShoot;
    public string bHell_PosData;
    private float bHell_rotationSpeed = 300.0f;
    [SerializeField]
    private BulletHellManage bHell_Manage;
    [SerializeField]
    private ProjectileParent Proj_Manage;

    public float Recieve_FiringRate;
    public float TillFire;
    private int ProjMode;
    private float nuTime = 2;

    public float Blue_FiringRate;
    public float Red_FiringRate;
    public float Yellow_FiringRate;
    public float Green_FiringRate;
    public float White_FiringRate;

    private float Runner_vertMovement;
    private float Runner_horiMovement;
    public float baseSpeed;
    public bool Shielded;
    [SerializeField]
    private Transform shieldAppearance;

    [SerializeField]
    private Transform AimingLaser;

    public Vector3 pauseVelocity;

    public float moistMeter;
    public Color moistTinting;
    public float moistMax;
    public Color moistMin;
    public float moistRate;

    public bool ControlRemoved;

    // Start is called before the first frame update
    protected override void Start() {
      base.Start();
      speed = 7f;
        baseSpeed = speed;
      rotationSpeed = 100.0f;
      totalDistance = 0f;
      currentPosition = gameObject.transform.position;
        Shielded = false;
        bHell_isShoot = false;
        BulletHellManage bHell_Manage = GetComponent(typeof(BulletHellManage)) as BulletHellManage;
        ProjectileParent Proj_Manage = GetComponent(typeof(ProjectileParent)) as ProjectileParent;

        moistTinting = GetComponent<SpriteRenderer>().material.color;



    }

  // Update is called once per frame
  protected override void Update() {
      base.Update();
      if (!touched && !paused) {
          animator.SetBool("Moving", false);
          GetComponent<Animator>().speed = 0;
      } else {
          animator.SetBool("Moving", true);
          GetComponent<Animator>().speed = 1;
      }
  }

  protected override void FixedUpdate() {
      base.FixedUpdate();
      BHell_Main();
  }

  protected override void MoveCharacter(Vector2 direction) {
        base.MoveCharacter(direction);
         gameObject.GetComponent<Transform>().Translate(direction * speed * Time.deltaTime, Space.World);

  }



  //player boost duration.
  private IEnumerator BoostDuration(float waitTime) {
      yield return new WaitForSeconds(waitTime);

      if (gameObject.tag == "Player1") {
          gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
      } else if (gameObject.tag == "Player2") {
          gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.6f, 0.2f, 1);
      }

      speed = 10f;
      //gameObject.GetComponent<Rigidbody2D>().mass = 1;
      totalDistance = 0f;
      boosted = false;
  }

    public void BHell_Main()
    {
        BHell_Control();

        bHell_Manage.BHell_Determine_Mode();
    }

    public void BHell_Fire()
    {
       nuTime = Time.time;
        GameObject pooledBullet = ObjectPool.pool_Instance.GetPooledObject();

        BHell_FireMode();
        if (pooledBullet != null && nuTime > TillFire)
        {
            TillFire = Time.time + Recieve_FiringRate;
            pooledBullet.transform.position = this.gameObject.transform.position;
            pooledBullet.transform.rotation = this.gameObject.transform.rotation;
            pooledBullet.SetActive(true);
            pooledBullet.GetComponent<ProjectileParent>().firedFrom = this.gameObject;//Figure out a better way to do this after Feature phase.
        }

    }
    public void BHell_Hit(int shotvalue)
    {
       if(Shielded == true)
        {
            ShieldDestroy();

        }

        else {
            moistMeter = shotvalue * moistRate;
            if (gameObject.tag == "Player1" && bHell_isShoot == false)
            {
                bHell_Manage.p1TimesHit += shotvalue;
                
                ApplyMoisture();



            }
            if (gameObject.tag == "Player2" && bHell_isShoot == false)
            {
                bHell_Manage.p2TimesHit += shotvalue;
                ApplyMoisture();

            }
        }
    }

    void ApplyMoisture()
    {



        Debug.Log(moistMeter);
        Debug.Log(gameObject.GetComponent<SpriteRenderer>().material.color);
        moistTinting.g -= moistMeter;
        moistTinting.r -= moistMeter;
        moistTinting.b += moistMeter;

        moistTinting.g = Mathf.Clamp(moistTinting.g, moistMin.g, 1);
        moistTinting.r = Mathf.Clamp(moistTinting.r, moistMin.r, 1);
        moistTinting.b = Mathf.Clamp(moistTinting.b, moistMin.b, 1);

        this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(moistTinting.r, moistTinting.g, moistTinting.b);

    }

    public void BHell_FireMode()
    {

        if (ObjectPool.pool_Instance.pool_RedProjTime == true)
        {
            Recieve_FiringRate = Red_FiringRate;
        }
        else if (ObjectPool.pool_Instance.pool_YellowProjTime == true)
        {
            Recieve_FiringRate = Yellow_FiringRate;
        }
        else if (ObjectPool.pool_Instance.pool_GreenProjTime == true)
        {
            Recieve_FiringRate = Green_FiringRate;
        }
        else if (ObjectPool.pool_Instance.pool_WhiteProjTime == true)
        {
            Recieve_FiringRate = White_FiringRate;
        }
        else
        {
            Recieve_FiringRate = Blue_FiringRate;
        }
    }

    public void BHell_Control()
    {
         if(ControlRemoved == false)
        {  
             if (bHell_isShoot == true && paused == false)
                {
            animator.SetBool("Tank", true);
            transform.Rotate(0f, 0f, Input.GetAxis(bHell_PosData) * bHell_rotationSpeed * Time.deltaTime * -1);
            //transform.position = bHell_Manage.GunnerPos.transform.position;


            BHell_Fire();



             }
              else if (paused == false)
                {
            animator.SetBool("Tank", false);
            Movement();
                }
        }
    }



    public void Movement()
    {
        if (ControlRemoved == false)
        {
            Controls();

            float moveY = 0f;
            float moveX = 0f;

            moveY = Runner_vertMovement * speed;
            moveX = Runner_horiMovement * speed;

            moveX *= Time.deltaTime;
            moveY *= Time.deltaTime;

            transform.Translate(0, moveY, 0);
            transform.Translate(moveX, 0, 0);
        }

    }

    void Controls()
    {
        if (ControlRemoved == false)
        {
            if (gameObject.tag == "Player1")
            {
                Runner_vertMovement = Input.GetAxis("Vertical");
                Runner_horiMovement = Input.GetAxis("Horizontal");

            }
            if (gameObject.tag == "Player2")
            {
                Runner_vertMovement = Input.GetAxis("Vertical1");
                Runner_horiMovement = Input.GetAxis("Horizontal1");

            }
        }
    }

    public void ShieldCreation()
    {
        shieldAppearance = transform.GetChild(1);

        shieldAppearance.gameObject.SetActive(true);
        Shielded = true;

        //Add other animation such as appear over time, or growing in size when powerup collected.
    }

   public void ShieldDestroy()
    {
        shieldAppearance.gameObject.SetActive(false);
        Shielded = false;
    }

    public void AimingCreation()
    {
        AimingLaser = transform.GetChild(2);
        AimingLaser.gameObject.SetActive(true);
    }
    public void AimingDestroy()
    {
        AimingLaser.gameObject.SetActive(false);
    }

    public void PauseCharacter()
    {
        //pauseForce = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        paused = true;
        pauseVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void UnpauseCharacter()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = pauseVelocity;
        paused = false;
    }



}
