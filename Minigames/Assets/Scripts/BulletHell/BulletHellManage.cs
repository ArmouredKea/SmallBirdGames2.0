using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    private Vector3 P1SavedPosition;

    [SerializeField]
    private PC_BulletHell P2;

    private Vector3 P2SavedPosition;
    //public GameObject projectile;

    public float TimeToMove1;
    public float TimeToMove2;
    public float DistFloat;
    public float LerpRate;

    public int p1TimesHit;
    public int p2TimesHit;

    public Text p1HitDisplay;

    public Text p2HitDisplay;

    [SerializeField]
    private GameObject P1Spawn;

    public bool P1_isLerpHome;
    public bool P1_isLerpGun;

    public bool P2_isLerpHome;
    public bool P2_isLerpGun;
    private bool Swapping;
    public float minDistance;

    [SerializeField]
    private GameObject P2Spawn;

    [SerializeField]
    private GunnerPowerups gunnerPowerups;

    public float FadeTime;

    public int P1TempScore;
    public int P2TempScore;

    public Text P1hits;
    public Text P2hits;
    public Text P1Tag;
    public Text P2Tag;

    public Canvas P1feedback;
    public Canvas P2feedback;

    public GameObject Speechbubble;

    public GameObject P1_TutorialGun;
    public GameObject P2_TutorialGun;
    public GameObject P1_TutorialRun;
    public GameObject P2_TutorialRun;

    private string P1Character;
    private string P2Character;
    public bool paused;


    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PC_BulletHell>();
        P2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PC_BulletHell>();
        BHell_Init();

    }

    // Update is called once per frame
     void Update()
    {
        PositionChecker();
        ValueCheck();



    }

    public void BHell_Init()
    {
        //bHell specific initialization for code sanitiation. Need to refactor how
        firingPlayer = Random.Range(1, 3); //Decide starting P randomly. R.R's MAX is not inclusive, it is exclusive. So it will only ever generate below 3, not 3.

        BHell_Determine_Mode();


        DetectCharacter1(); //Assigns correct character portrait to speechbubble.
        DetectCharacter2();

        if (firingPlayer == 1)
        {
            P1_isLerpGun = true;
            P1_TutorialGun.SetActive(true);
            P2_TutorialRun.SetActive(true);

        }

        else if (firingPlayer == 2)
        {
            P2_isLerpGun = true;
            P2_TutorialGun.SetActive(true);
            P1_TutorialRun.SetActive(true);
        }



        //Send P to shooting location, if shooter.

    }

    public void BHell_Determine_Position()
    {

        if (firingPlayer == 1 & P1.tag == "Player1")
        {

            P1.bHell_isShoot = true;
            P1.bHell_PosData = "HorizontalP1";






        }

        else if (firingPlayer == 2 & P2.tag == "Player2")
        {


            P2.bHell_isShoot = true;
            P2.bHell_PosData = "HorizontalP2";


            //Work out a way to use the Time.delta properly here as well.



        }
    }

    public void Bhell_Swap()
    {
        //Need: A method of moving players over time between the gunner roles and their current position.
        //Get curr Player Position, Get Spawn Point Pos, Lerp between current pos and gunner.
        //Lerp gunner from center to inital spawn point.
        //How does this work with movement animation? Assign movement anim to the movement function of player.

        ObjectPool.pool_Instance.StopAll();
        BHell_Determine_Mode();
        //DetectCharacter1();
        //DetectCharacter2();
        gunnerPowerups.Deactivate();


        if (firingPlayer == 2)
        {

            Debug.Log("p2 move to spawn");

            P1.bHell_isShoot = true;
            P2.bHell_isShoot = false;
            P1.speed = P1.baseSpeed;




            P1.ShieldDestroy();
            firingPlayer = 1;
            P2_isLerpHome = true;
            P1_isLerpGun = true;
            P2.CorrectSpeed = true;


        }

        else if (firingPlayer == 1)
        {


            Debug.Log("p1 move to spawn");
            P2.bHell_isShoot = true;
            P1.bHell_isShoot = false;

            P2.speed = P2.baseSpeed;


            P2.ShieldDestroy();

            firingPlayer = 2;
            P1_isLerpHome = true;
            P2_isLerpGun = true;
            P2.CorrectSpeed = true;

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



    public void DetectCharacter1()
    {
        if (P1.gameObject.name == "P1_Bo")
        {
           P1Character = "Bo";
           // Instantiate(P1Tag, P1feedback.transform);
           // P1Tag.transform.position = P1feedback.transform.position;


          //  P1Tag.color = Color.blue; //Update for specific character colouring later on.
        }
        else if (P1.gameObject.name == "P1_Hiro")
        {
            P1Character = "Hiro";
           // Instantiate(P1Tag, P1feedback.transform);
        //    P1Tag.transform.position = P1feedback.transform.position;

          //  P1Tag.color = Color.black;
        }
        else if (P1.gameObject.name == "P1_Mika")
        {
            P1Character = "Mika";
          //  Instantiate(P1Tag, P1feedback.transform);
           // P1Tag.transform.position = P1feedback.transform.position;

           // P1Tag.color = Color.red;
        }

    }

    public void DetectCharacter2()
    {
        //P2 tags
        if (P2.gameObject.name == "P2_Bo")
        {
            P2Character = "Bo";
           // Instantiate(P2Tag, P2feedback.transform);
           // P2Tag.transform.position = P2feedback.transform.position;

          //  P2Tag.color = Color.yellow; //Update for specific character colouring later on.
        }
        else if (P2.gameObject.name == "P2_Hiro")
        {
            P2Character = "Hiro";
            //Instantiate(P2Tag, P2feedback.transform);
            //P2Tag.transform.position = P2feedback.transform.position;

            //P2Tag.color = Color.black;
        }
        else if (P2.gameObject.name == "P2_Mika")
        {
            P2Character = "Mika";
            //Instantiate(P2Tag, P2feedback.transform);
            //P2Tag.transform.position = P2feedback.transform.position;

            //P2Tag.color = Color.red;
        }
    }




    void ValueCheck()
    {

        //Checks to see if the value has changed since last hit. If so, send the player text box to the coroutine along with value.




        if(p1TimesHit > P1TempScore)
        {

            P1hits.text = p1TimesHit.ToString();



            Instantiate(P1hits, P1feedback.transform);
            P1hits.transform.rotation = P1hits.transform.rotation;
            P1TempScore = p1TimesHit;
        }


        else if (p2TimesHit > P2TempScore)
        {


            P2hits.text = p2TimesHit.ToString();

            

            Instantiate(P2hits, P2feedback.transform );

            P2hits.transform.rotation = P2hits.transform.rotation;
            P2TempScore = p2TimesHit;
        }
    }


    public void PositionChecker()
    {
      if(paused == false){

                      if (P1_isLerpHome == true)
                      {
                          P1.ControlRemoved = true;
                          P1_isLerpGun = false;
                          TimeToMove2 += Time.deltaTime;

                          if (Vector3.Distance(P1.transform.position, P1Spawn.transform.position) > minDistance)
                          {
                              P1.gameObject.transform.position = Vector3.Lerp(P1.gameObject.transform.position, P1Spawn.transform.position, Time.deltaTime * LerpRate);

                          }
                          else
                          {
                              P1.gameObject.transform.position = P1Spawn.transform.position;
                              P1.gameObject.transform.rotation = P1Spawn.transform.rotation;
                              P1.ControlRemoved = false;
                              P1_isLerpHome = false;
                              P1.speed = P1.baseSpeed;
                          }
                      }

                      else if (P1_isLerpGun == true)
                      {
                          P1.ControlRemoved = true;

                          TimeToMove1 += Time.deltaTime;

                          if (Vector3.Distance(P1.transform.position, GunnerPos.transform.position) > minDistance)
                          {
                              P1.gameObject.transform.position = Vector3.Lerp(P1.gameObject.transform.position, GunnerPos.transform.position, Time.deltaTime * LerpRate);
                          }
                          else
                          {
                              P1.gameObject.transform.position = GunnerPos.transform.position;
                              P1.gameObject.transform.rotation = GunnerPos.transform.rotation;
                              P1.ControlRemoved = false;
                              SpeechBubbleGenerator(P1feedback, P1Character);
                              P1_isLerpGun = false;
                          }
                      }


                      if (P2_isLerpHome == true)
                      {
                          P2.ControlRemoved = true;
                          P2_isLerpGun = false;
                          TimeToMove2 += Time.deltaTime;
                          if (Vector3.Distance(P2.transform.position, P2Spawn.transform.position) > minDistance)
                          {

                              P2.gameObject.transform.position = Vector3.Lerp(P2.gameObject.transform.position, P2Spawn.transform.position, Time.deltaTime * LerpRate);
                          }
                          else
                          {
                              P2.gameObject.transform.position = P2Spawn.transform.position;
                              P2.gameObject.transform.rotation = P2Spawn.transform.rotation;
                              P2.ControlRemoved = false;
                              P2.speed = P2.baseSpeed;
                              P2_isLerpHome = false;
                              //P2_isLerpGun = false;
                          }
              }



        else if (P2_isLerpGun == true)
        {
            P2.ControlRemoved = true;

            TimeToMove1 += Time.deltaTime;

            if (Vector3.Distance(P2.transform.position, GunnerPos.transform.position) > minDistance)
            {
                P2.gameObject.transform.position = Vector3.Lerp(P2.gameObject.transform.position, GunnerPos.transform.position, Time.deltaTime * LerpRate);
            }
            else
            {
                P2.gameObject.transform.position = GunnerPos.transform.position;
                P2.gameObject.transform.rotation = GunnerPos.transform.rotation;
                P2.ControlRemoved = false;


                  SpeechBubbleGenerator(P2feedback, P2Character);
                  P2_isLerpGun = false;
                  P2_isLerpHome = false;
            }
        }

      }

    }



    public void SpeechBubbleGenerator(Canvas pos, string character)
    {
        Speechbubble.GetComponent<MoveDamage>().ChangeSprite(character);
        Instantiate(Speechbubble, pos.transform);

    }
    //Make a value to hold the current player being moved
    //Make a value to hold the destination for said player
    //Change player and destimation via if statements in swapping



}
