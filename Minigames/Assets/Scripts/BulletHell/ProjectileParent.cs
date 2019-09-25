using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParent : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Generic Variables")]
    public Rigidbody2D currentProj;
    public PC_BulletHell P1Cont; //could maybe turn this into a single check when it hits something?Though needs to know firingPlayer so it doesn't injure self.
    public PC_BulletHell P2Cont;
    public GameObject firedFrom;
    public bool paused;
    public Vector3 pauseVelocity;
    [Header("Visual Variables")]
    public Color isColor;
    public Sprite assignSprite;
    public Sprite collidedSprite;//Not sure how it is planned to handle specific effects. Such as, is it necessary 
    [Header("Generic Stats")]
    public float KnockBack;
    public float KnockBackMag;
    public float Speed;
    public float firingRate;
    public int damageScore;
    [Header("Green Projectile")]
    public int growBy;
    public float growRate;
    [Header("Yellow Projectile")]
    public float frequencySine;
    public float base_magnitudeSine;
    public float magnitudeSine;
    public float rateSine;
    [Header("Red Projectile")]
    public float explode_Min;
    public float explode_Max;
    public float explode_Radius;


    #region Private Variables
    private Vector3 axisSine;
    private Vector3 posSine;
   


    #endregion




    // TO ADD: Make a generic function to take the general 'activation time' and turn it into an overhead display.

    virtual public void Start()
    {
        Initialize();
    }

    virtual public void Awake()
    {
        Initialize();
    }

    // Update is called once per frame
    virtual public void Update()
    {

    }

    virtual public void OnEnable()
    {
        //Initialize();


    }

    public virtual void OnTriggerEnter2D(Collider2D collideWith)
    {


        

         if (firedFrom != collideWith.gameObject)
        {
            if (collideWith.gameObject.tag == "Projectile")
            {
                //donothing
            }

           else if (collideWith.gameObject.tag == "Boundary")
            {   
                if (gameObject.tag == "Projectile")
                {
                    gameObject.SetActive(false);
                  
                } 
                /*
                else if ()
                {
                    Destroy(gameObject);
                }*/
            }
            else if (gameObject.tag == "ShooterPowerup")
            {
                gameObject.SetActive(false);
            }
            else if (collideWith.tag == "Player1" || collideWith.tag == "Player2")
            {
                gameObject.SetActive(false);
               

                P1Cont.BHell_Hit(damageScore);
                P2Cont.BHell_Hit(damageScore);


                collideWith.gameObject.transform.GetComponent<Rigidbody2D>().AddForce(transform.up * KnockBack, ForceMode2D.Impulse);
            }

        }

    }


    public virtual void Movement()
    {
        currentProj.velocity = transform.up * Speed;

    }

    public virtual void Initialize()
    {
        P1Cont = GameObject.FindGameObjectWithTag("Player1").GetComponent<PC_BulletHell>();
        P2Cont = GameObject.FindGameObjectWithTag("Player2").GetComponent<PC_BulletHell>();
        currentProj = gameObject.GetComponent<Rigidbody2D>();
        gameObject.GetComponent<SpriteRenderer>().material.color = isColor;
        gameObject.GetComponent<SpriteRenderer>().sprite = assignSprite; //Changes visual sprite to set sprite in child.
    }

    public virtual void SineInitialize()
    {
        posSine = currentProj.transform.position;
        
        axisSine = currentProj.transform.right;
    }


    public virtual void SineMovement()
    {
        if (paused == false)
        {
            posSine += currentProj.transform.up * Time.deltaTime * Speed;
            currentProj.transform.position = posSine + axisSine * Mathf.Sin(Time.deltaTime * frequencySine) * magnitudeSine;
        }


    }

    public virtual void GrowReset()
    {
            currentProj.transform.localScale = new Vector3(0, 0, 0);
        
    }


    public IEnumerator GrowTime()
    {
      while(paused == true)
        {
            yield return null;
        }

        currentProj.transform.localScale = Vector3.Lerp(currentProj.transform.localScale, new Vector3(growBy, growBy, 0), Time.deltaTime * growRate);
        yield return new WaitForSeconds(0.5f);
    }
    
    public IEnumerator TempNormalMove()
    {

        while (paused == true)
        {
            yield return null;
        }
        magnitudeSine = Mathf.Lerp(magnitudeSine, base_magnitudeSine, Time.deltaTime * rateSine);

        yield return null;




    } 

    public virtual void Clear()
    {
        gameObject.SetActive(false);
        //Put visual effect on hit here.
    }



}

