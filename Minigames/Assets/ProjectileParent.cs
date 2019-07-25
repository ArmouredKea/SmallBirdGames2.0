using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParent : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D currentProj;

    public float Speed;
    public float firingRate;
    public float time_growMin;
    public float time_growMax;
    public float growBy;



    public PlayerController P1Cont;
    public PlayerController P2Cont;
    public GameObject firedFrom;
    public Color isColor;
    public Sprite assignSprite;


    void Start()
    {
       
    }

    virtual public void Awake()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
    }
    virtual public void OnEnable()
    {
        //Initialize();
        Movement();

    }

    public virtual void OnTriggerEnter2D(Collider2D collideWith)
    {
       

        if (firedFrom != collideWith.gameObject)
        {
            if (collideWith.gameObject.tag == "Boundary")
            {
                if (gameObject.tag == "Projectile")
                {
                    gameObject.SetActive(false);

                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                gameObject.SetActive(false);
                P1Cont.BHell_Hit();
                P2Cont.BHell_Hit();
                
            }

        }

    }


    void Movement()
    {
        currentProj.velocity = transform.up * Speed;

    }

    public virtual void Initialize()
    {
        P1Cont = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>();
        P2Cont = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
        currentProj = gameObject.GetComponent<Rigidbody2D>();
        gameObject.GetComponent<SpriteRenderer>().material.color = isColor;
        gameObject.GetComponent<SpriteRenderer>().sprite = assignSprite; //Changes visual sprite to set sprite in child.
        P1Cont.Recieve_FiringRate = firingRate;
        P2Cont.Recieve_FiringRate = firingRate;
    }

}

