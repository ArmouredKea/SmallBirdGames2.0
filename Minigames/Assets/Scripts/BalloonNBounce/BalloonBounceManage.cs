using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BalloonBounceManage : MonoBehaviour
{



    public ProjectileParent ProjScript;
    [SerializeField]
    private PC_BulletHell P1;
    private Vector3 P1SavedPosition;

    [SerializeField]
    private PC_BulletHell P2;

    private Vector3 P2SavedPosition;
    //public GameObject projectile;

    public int p1TimesHit;
    public int p2TimesHit;

    public Text p1HitDisplay;

    public Text p2HitDisplay;

    [SerializeField]
    private GameObject P1Spawn;

    [SerializeField]
    private GameObject P2Spawn;

    [SerializeField]
    private GunnerPowerups gunnerPowerups;

    [SerializeField]
    private RunnerPowerups runnerPowerups;

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
       
        ValueCheck();
      


    }

    

    public void BHell_Init()
    {

        //bHell specific initialization for code sanitiation. Need to refactor how







        //Send P to shooting location, if shooter.

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


   



    public void SpeechBubbleGenerator(Canvas pos, string character, int playerID)
    {
        Speechbubble.GetComponent<MoveDamage>().ChangeSprite(character, playerID);
        Instantiate(Speechbubble, pos.transform);

    }
    //Make a value to hold the current player being moved
    //Make a value to hold the destination for said player
    //Change player and destimation via if statements in swapping



}
