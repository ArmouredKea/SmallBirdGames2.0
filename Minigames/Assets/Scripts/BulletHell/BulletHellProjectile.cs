using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellProjectile : MonoBehaviour
{

    //   private BulletHellManage bHell_Manage;

    public GameObject Firing_Player;

    public float speed;
    private Rigidbody2D this_Proj;
    [SerializeField]
    private PlayerController P1Con;
    [SerializeField]
    private PlayerController P2Con;

    private bool HasHit;

    // Start is called before the first frame update
    void Start()
    {
        P1Con = GameObject.FindGameObjectWithTag("Player1").GetComponent(typeof(PlayerController)) as PlayerController;
        P2Con = GameObject.FindGameObjectWithTag("Player2").GetComponent(typeof(PlayerController)) as PlayerController;


    }

    private void OnEnable()
    {
        //this_Proj = transform.GetComponent<Rigidbody2D>();
        //this_Proj.AddForce(Firing_Player.transform.forward);
        this_Proj = gameObject.transform.GetComponent<Rigidbody2D>();
        this_Proj.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (Firing_Player != other.gameObject)
        {
            if (other.gameObject.tag == "Boundary")
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
            else if(HasHit == false)
            {
                gameObject.SetActive(false);
                P1Con.BHell_Hit();
               P2Con.BHell_Hit();
                HasHit = true;
            }

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(Firing_Player != other.gameObject)
        {
            HasHit = false;
        }
    }


}
