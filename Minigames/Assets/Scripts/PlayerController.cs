using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    //Player's forward/backward speed and rotation speed variables.
    public float speed = 7.0f;
    private float rotationSpeed = 100.0f;
    public bool boosted;

    private Vector2 currentPosition;
    float totalDistance = 0f;

    public JoystickController Controller;
    public int? LockedFingerID { get; set; }

    public float rotationSpeed2;
    public GameObject pickedUpObj;

    //controls axis
    private float vertMovement;
    private float horiMovement;
    private float pickUpC;
    private bool puAxisInUse;
    private bool oButtonPressed;

    //obj picked up bool
    public bool inRange;
    public bool objCarry;

    private Vector2 startPos;

    private bool bumperCars;
    private bool overcooked;
    private bool bHell_Check;

    public static int p1Score;
    public static int p2Score;

    #region BhellVariables
    //bullethell specific variables. Will be cleaned once Child/Parent system is working.
    public bool bHell_isShoot;
    public string bHell_PosData;
    private float bHell_rotationSpeed = 300.0f;
    [SerializeField]
    private BulletHellManage bHell_Manage;
    [SerializeField]
    private ProjectileParent Proj_Manage;

    private Transform Barrel;
    public GameObject Proj;
    public float Recieve_FiringRate;
    public float TillFire;
    #endregion

    // Use this for initialization
    void Start() {
        bumperCars = false;
        overcooked = false;
        bHell_Check = false;
        bHell_isShoot = false;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "BumperCarsMG") {
            currentPosition = gameObject.transform.position;
            bumperCars = true;
        } else if (scene.name == "OvercookedMG") {
            overcooked = true;
        } else if (scene.name == "BulletHell") {
            bHell_Check = true;
            BulletHellManage bHell_Manage = GetComponent(typeof(BulletHellManage)) as BulletHellManage;
            ProjectileParent Proj_Manage = GetComponent(typeof(ProjectileParent)) as ProjectileParent;
        }

        else if (scene.name == "CharacterSelect") {
            p1Score = 0;
            p2Score = 0;
        }
    }

    // Update is called once per frame
    void Update() {

        if (bumperCars) {
            //calculates distance travelled.
            float distance = Vector2.Distance(currentPosition, gameObject.transform.position);
            totalDistance += distance;
            currentPosition = gameObject.transform.position;

            //player boost.
            if (totalDistance >= 50f) {
                boosted = true;
                speed = 15.0f;
                gameObject.GetComponent<Rigidbody2D>().mass = 2;

                if (gameObject.tag == "Player1") {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                } else if (gameObject.tag == "Player2") {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
                }

                StartCoroutine(BoostDuration(5f));
            }
        }

    }

    void FixedUpdate() {
        if (bumperCars) {
            //Player forward/backward movement and rotation.
            if (gameObject.tag == "Player1") {
                GetComponent<Rigidbody2D>().AddForce(transform.up * Input.GetAxis("VerticalP1") * speed);
                transform.Rotate(0f, 0f, Input.GetAxis("HorizontalP1") * rotationSpeed * Time.deltaTime * -1);
            } else if (gameObject.tag == "Player2") {
                GetComponent<Rigidbody2D>().AddForce(transform.up * Input.GetAxis("VerticalP2") * speed);
                transform.Rotate(0f, 0f, Input.GetAxis("HorizontalP2") * rotationSpeed * Time.deltaTime * -1);
            } else {
                return;
            }
        } else if (overcooked) {
            Movement();
            if (objCarry) {
                pickedUpObj.GetComponent<ItemController>().LastHeldBy(gameObject);
                pickedUpObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, pickedUpObj.transform.position.z);
            }
        }
        else if (bHell_Check)
        {
            BHell_Main();
        }
    }

    //player boost duration.
    private IEnumerator BoostDuration(float waitTime) {
        yield return new WaitForSeconds(waitTime);

        if (gameObject.tag == "Player1") {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        } else if (gameObject.tag == "Player2") {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.6f, 0.2f, 1);
        }

        speed = 5.0f;
        gameObject.GetComponent<Rigidbody2D>().mass = 1;
        totalDistance = 0f;
        boosted = false;
    }

    private void OnEnable() {
        Controller.Players.Add(this);
    }
    private void OnDisable() {
        Controller.Players.Remove(this);
    }

    //Splitting Controls between both players to only have 1 script
    void Controls() {

            if (gameObject.name == "Player1")
            {
                vertMovement = Input.GetAxis("Vertical");
                horiMovement = Input.GetAxis("Horizontal");
                pickUpC = Input.GetAxis("PickUp");
            }
            if (gameObject.name == "Player2")
            {
                vertMovement = Input.GetAxis("Vertical1");
                horiMovement = Input.GetAxis("Horizontal1");
                pickUpC = Input.GetAxis("PickUp1");
            }

            //single action axes rather than on loop
            if (pickUpC != 0)
            {
                if (puAxisInUse == false)
                {
                    PickUpObj();
                    puAxisInUse = true;
                }
            }
            if (pickUpC == 0)
            {
                puAxisInUse = false;
            }
        


    }

    //Movement Function
    public void Movement() {

        Controls();

        float moveY = 0f;
        float moveX = 0f;

        moveY = vertMovement * speed;
        moveX = horiMovement * speed;

        moveX *= Time.deltaTime;
        moveY *= Time.deltaTime;

        transform.Translate(0, moveY, 0);
        transform.Translate(moveX, 0, 0);

    }


    //Referencing gameObject (PickUp) that you are near
    void OnTriggerStay2D(Collider2D other) {
        if (overcooked) {
            if (other.tag == "PickUp") {
                if (objCarry == false) {
                    inRange = true;
                    pickedUpObj = other.gameObject;
                }
            }
        }
    }

    //Resetting on drop and collider exit
    void OnTriggerExit2D(Collider2D other) {
        if (overcooked) {
            if (other.tag == "PickUp") {
                if (objCarry == false) {
                    inRange = false;
                    pickedUpObj = null;
                }
            }
        }
    }

    //To Pick up and Drop Objects
    public void PickUpObj() {
        if (pickUpC != 0 && inRange && objCarry == false) {
            objCarry = true;
        } else if (pickUpC != 0 && objCarry == true) {
            objCarry = false;
        }
    }
    public void PickUpObj2() {
        if (inRange && objCarry == false) {
            objCarry = true;
        } else if (objCarry == true) {
            objCarry = false;
        }
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
        if(bHell_Manage.FixedSwap == true )
        {
            bHell_Manage.BHell_Determine_Position();
            bHell_Manage.FixedSwap = false;
        }
    }



    public void BHell_Control()
    {
        if(bHell_isShoot == true)
        {
            
            transform.Rotate(0f, 0f, Input.GetAxis(bHell_PosData) * bHell_rotationSpeed * Time.deltaTime * -1);
            transform.position = bHell_Manage.GunnerPos.transform.position;
           
           
            BHell_Fire();
            
          
        }
        else
        {
            Movement();
        }
    }

    public void BHell_Fire()
    {
        


        GameObject pooledBullet = ObjectPool.pool_Instance.GetPooledObject();
        // bHell_Bullet.GetComponent<BulletHellProjectile>().Firing_Player = this.gameObject;
        pooledBullet.GetComponent<ProjectileParent>().firedFrom = this.gameObject;
        if (pooledBullet != null && Time.time > TillFire)
        {
            TillFire = Time.time + Recieve_FiringRate;
            pooledBullet.transform.position = this.gameObject.transform.position;
            pooledBullet.transform.rotation = this.gameObject.transform.rotation;
            pooledBullet.SetActive(true);
           
        } 
       
       // Instantiate(Proj, this.gameObject.transform.position, this.gameObject.transform.rotation );
    }

    public void BHell_Hit()
    {
        if(gameObject.tag == "Player1" && bHell_isShoot == false)
        { 
            bHell_Manage.p1TimesHit++;
           
        }
        if (gameObject.tag == "Player2" && bHell_isShoot == false)
        {
            bHell_Manage.p2TimesHit++;
        }
    }
    #endregion
}
