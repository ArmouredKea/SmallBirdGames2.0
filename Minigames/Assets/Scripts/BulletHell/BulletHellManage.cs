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
    public ProjectileParent ProjScript;
    [SerializeField]
    private PC_BulletHell P1;

    [SerializeField]
    private PC_BulletHell P2;
    //public GameObject projectile;

    public int p1TimesHit;
    public int p2TimesHit;

    [SerializeField]
    private GameObject P1Spawn;
    [SerializeField]
    private GameObject P2Spawn;


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
        //bHell specific initialization for code sanitiation. Need to refactor how 
        firingPlayer = Random.Range(1, 3); //Decide starting P randomly. R.R's MAX is not inclusive, it is exclusive. So it will only ever generate below 3, not 3.
        BHell_Determine_Mode();                                   //Send P to shooting location, if shooter.
       
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

    public void Bhell_Swap()
    {
        ObjectPool.pool_Instance.StopAll();
        BHell_Determine_Mode();

        if (firingPlayer == 2)
        {
            P1.bHell_isShoot = true;
            P2.bHell_isShoot = false;
            P1.ShieldDestroy();
            firingPlayer = 1;
            P2.gameObject.transform.position = P2Spawn.transform.position;
            P2.gameObject.transform.rotation = P2Spawn.transform.rotation;
            Debug.Log("p1 should be shooting");
        }

         else if(firingPlayer == 1)
        {
            P2.bHell_isShoot = true;
            P1.bHell_isShoot = false;
            P2.ShieldDestroy();
            firingPlayer = 2;
            P1.gameObject.transform.position = P1Spawn.transform.position;
            P1.gameObject.transform.rotation = P1Spawn.transform.rotation;
            Debug.Log("p2 should be shooting");
        }
    }
    public void BHell_Determine_Mode()
    {
        if (FixedSwap == true)
        {
           BHell_Determine_Position();
           FixedSwap = false;
        }
        if (TimedSwap == true)
        {
            BHell_Determine_Position();
        }
    }

}
