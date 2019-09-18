using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject player;
    //public GameObject spawn;

    public GameObject timerBar;

    //needed an item that was null
    private GameObject nullItem;

    private PC_Overcooked playerScript;
    //public ItemScript itemScript;

    public int points;

    public GameObject baseBalloonObj;
    //holds an enum value as a key, holds a Vector4 for colour
    Dictionary <int, Vector4> balloonColorDic = new Dictionary<int, Vector4>();
    //holds an int as key for hand in, holds a GameObject as handin
    Dictionary <int, GameObject> handInDic = new Dictionary <int, GameObject>();

    public GameObject handIn1;
    public GameObject lid1;
    public bool lid1Closed;

    public GameObject handIn2;
    public GameObject lid2;
    public bool lid2Closed;

    public GameObject handIn3;
    public GameObject lid3;
    public bool lid3Closed;

    public GameObject handIn4;
    public GameObject lid4;
    public bool lid4Closed;

    //List<GameObject> pickUps = new List<GameObject>();
    public List<int> orderList = new List<int>();
    public List<GameObject> orderVisuals = new List<GameObject>();
    public int orderLength;
    public int ordered;

    public bool gameEnd;
    public bool paused;
    public bool correctHandIn;

    public GameObject orderTiles;

    //Timer Variable
    private float endTimer = 60f;

    public GameObject txtObject;

    // Start is called before the first frame update
    void Start() {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        txtObject.GetComponent<Text>().text = ("Points : " + points);
        if (gameObject.name == "HandInP1") {
          player = GameObject.FindGameObjectWithTag("Player1");
        }
        else if (gameObject.name == "HandInP2") {
          player = GameObject.FindGameObjectWithTag("Player2");
        }

        balloonColorDic.Add(1, new Vector4(255, 0, 0, 255));
        balloonColorDic.Add(2, new Vector4(0, 255, 0, 255));
        balloonColorDic.Add(3, new Vector4(0, 188, 255, 255));

        handInDic.Add(1, handIn1);
        handInDic.Add(2, handIn2);
        handInDic.Add(3, handIn3);
        handInDic.Add(4, handIn4);

        playerScript = player.GetComponent<PC_Overcooked>();
        OrderList();
        orderLength = 3;
        //ListPickUps();
        OrderUp();
    }

    // Update is called once per frame
    void Update() {
        if (!paused) {
            GameTimer();
        }

        if (orderList.Count <= 0) {
            OrderUp();
        }
    }

    void OrderUp() {
        int rI;
        Vector4 temp;
        /*while (orderList.Count < orderLength) {

            rI = Random.Range(0, 3);
            //orderList.Add(pickUps[rI]);
        } */

        //setting the visuals on the floor in relation to the order
        for (int j = 0; j <= orderLength; j++) {
            GameObject orderSprite;
            orderSprite = Instantiate(/*orderList[j].GetComponent<ItemController>().balloonSprite*/baseBalloonObj, orderVisuals[j].gameObject.transform.position, Quaternion.identity);
            orderSprite.transform.parent = orderVisuals[j].gameObject.transform;
            orderSprite.transform.rotation = orderVisuals[j].gameObject.transform.rotation;
            orderSprite.transform.localScale = new Vector3(0.6f, 0.6f, 1);

            rI = Random.Range(1, 4);
            orderList.Add(rI);
            if(balloonColorDic.TryGetValue(rI, out temp)) {
            orderSprite.GetComponent<SpriteRenderer>().color = temp;
          }
        }
    }

    //to spawn only one item on each spawn location
    /*
    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "PickUp" && other.gameObject.GetComponent<ItemController>().balloonName != "") {
           if (other.gameObject.GetComponent<ItemController>().lastPlayer1 && gameObject.name == "HandInP1" || other.gameObject.GetComponent<ItemController>().lastPlayer2 && gameObject.name == "HandInP2") {
              if (playerScript.objCarry == false) {
                  HandleHandIn(other.gameObject, other.gameObject.GetComponent<ItemController>().pointValue);
              }
          }
        }
    }
    */

    //handles the handin proccess, checking if the item is in the order
    public void HandleHandIn(int balloonID)
    {
      Debug.Log("Hand in ID" + balloonID);
        for (int i = 0; i < orderList.Count; i++)
        {

            if (orderList[i] != 0)
            {
                Debug.Log("Made it to point 1");

                if (balloonID == orderList[i])
                {
                    Debug.Log("Made it to point 2");
                    correctHandIn = true;
                    break;
                    orderList[i] = 0;
                } else {
                    orderList[i] = 0;
                    correctHandIn = false;
                }
                //close the lid[i]

            }
        }

          Debug.Log("Non-Ordered Points: " + points);

        txtObject.GetComponent<Text>().text = ("Points : " + points);
    }
    //Listing all possible pick ups
    /*void ListPickUps() {
        if (player.tag == "Player1") {
            foreach (GameObject pUP in GameObject.FindGameObjectsWithTag("SPP2")) {
                pickUps.Add(pUP.GetComponent<SpawnFoderScript>().balloonType);
            }
        } else if (player.tag == "Player2") {
            foreach (GameObject pUP in GameObject.FindGameObjectsWithTag("SPP2")) {
                pickUps.Add(pUP.GetComponent<SpawnFoderScript>().balloonType);
            }
        }
    } */

    //adding the order visual tiles to a list
    void OrderList() {
        foreach (Transform child in orderTiles.transform) {
            orderVisuals.Add(child.gameObject);
        }
    }

    void GameTimer() {
        endTimer -= Time.deltaTime;
        if (endTimer <= 0) {
            gameEnd = true;
            Debug.Log("Game Finished");
        }
        if (timerBar != null) {
          timerBar.GetComponentInChildren<Image>().fillAmount = (endTimer / 60);
        }
    }
}
