using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletHellManage : MonoBehaviour
{
    
    public bool FixedSwap;
    public bool DeathSwap;
    public bool TimedSwap;
    public GameObject GunnerPos;
    public int firingPlayer;
    [SerializeField]
    private PlayerController P1;

    [SerializeField]
    private PlayerController P2;
    public GameObject projectile;

    public int p1life = 3;
    public int p2life = 3;


    // Start is called before the first frame update
    void Start()
    {
        BHell_Init();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BHell_Init()
    {
        //bHell specific initialization for code sanitiation.
        firingPlayer = Random.Range(1, 3); //Decide starting P randomly. R.R's MAX is not inclusive, it is exclusive. So it will only ever generate below 3, not 3.
                                           //Send P to shooting location, if shooter.
       
    }

    public void BHell_Determine_Position()
    {

        if (firingPlayer == 1 & P1.tag == "Player1")
        {
           P1.transform.position = GunnerPos.transform.position;
            P1.bHell_isShoot = true;
           P1.bHell_PosData = "HorizontalP1";
          
        }

        else if (firingPlayer == 2 & P2.tag == "Player2")
        {
            P2.gameObject.transform.position = GunnerPos.transform.position;
            P2.bHell_isShoot = true;
            P2.bHell_PosData = "HorizontalP2";
           
        }
    }
}
