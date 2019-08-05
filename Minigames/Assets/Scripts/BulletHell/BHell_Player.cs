using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHell_Player : MonoBehaviour
{
    #region BhellVariables
    //bullethell specific variables. Will be cleaned once Child/Parent system is working.
    public bool bHell_isShoot;
    public string bHell_PosData;
    private float bHell_rotationSpeed = 300.0f;
    [SerializeField]
    private BulletHellManage bHell_Manage;
    [SerializeField]
    private ProjectileParent Proj_Manage;
    [SerializeField]
    private PlayerController GetPlayer;

    public float Recieve_FiringRate;
    public float TillFire;
    private int ProjMode;

    public float Blue_FiringRate;
    public float Red_FiringRate;
    public float Yellow_FiringRate;
    public float Green_FiringRate;
    public float White_FiringRate;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        bHell_isShoot = false;
        BulletHellManage bHell_Manage = GetComponent(typeof(BulletHellManage)) as BulletHellManage;
        ProjectileParent Proj_Manage = GetComponent(typeof(ProjectileParent)) as ProjectileParent;
        GetPlayer = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region BulletHell 
    //Bullet Hell Shooter code. Will be refactored once Parent/Child is complete.

    public void BHell_Main()
    {
        BHell_Determine_Mode();
        BHell_Control();
    }


    public void BHell_Determine_Mode()
    {
        if (bHell_Manage.FixedSwap == true)
        {
            bHell_Manage.BHell_Determine_Position();
            bHell_Manage.FixedSwap = false;
        }
        if (bHell_Manage.TimedSwap == true)
        {
            bHell_Manage.BHell_Determine_Position();
        }
    }




    public void BHell_Control()
    {
        if (bHell_isShoot == true)
        {

            transform.Rotate(0f, 0f, Input.GetAxis(bHell_PosData) * bHell_rotationSpeed * Time.deltaTime * -1);
            transform.position = bHell_Manage.GunnerPos.transform.position;


            BHell_Fire();



        }
        else
        {

            GetPlayer.Movement();
        }
    }

    public void BHell_Fire()
    {



        GameObject pooledBullet = ObjectPool.pool_Instance.GetPooledObject();

        BHell_FireMode();
        if (pooledBullet != null && Time.time > TillFire)
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
        if (gameObject.tag == "Player1" && bHell_isShoot == false)
        {
            bHell_Manage.p1TimesHit += shotvalue;

        }
        if (gameObject.tag == "Player2" && bHell_isShoot == false)
        {
            bHell_Manage.p2TimesHit += shotvalue;
        }
    }

    public void BHell_FireMode()
    {
        
        if(ObjectPool.pool_Instance.pool_RedProjTime == true)
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
    #endregion
}
