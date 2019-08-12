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
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region BulletHell 
    //Bullet Hell Shooter code. Will be refactored once Parent/Child is complete.




  








  


    #endregion
}
