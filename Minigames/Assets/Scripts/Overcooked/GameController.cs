using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject player;
    //public GameObject spawn;

    public AudioSource audiotest;

    public GameObject timerBar;

    //needed an item that was null
    private GameObject nullItem;

    private PC_Overcooked playerScript;
    //public ItemScript itemScript;

    public int points;

    List<GameObject> pickUps = new List<GameObject>();
    public List<GameObject> orderList = new List<GameObject>();
    List<GameObject> orderVisuals = new List<GameObject>();
    public int orderLength;
    public int ordered;

    public bool gameEnd;
    public bool paused;

    public GameObject orderTiles;

    //Timer Variable
    private float endTimer = 60f;

    // Start is called before the first frame update
    void Start() {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;

        if (gameObject.name == "HandInP1") {
          player = GameObject.FindGameObjectWithTag("Player1");
        }
        else if (gameObject.name == "HandInP2") {
          player = GameObject.FindGameObjectWithTag("Player2");
        }
        playerScript = player.GetComponent<PC_Overcooked>();
        OrderList();
        orderLength = 4;
        ListPickUps();
        OrderUp();
    }

    // Update is called once per frame
    void Update() {
        if (!paused) {
            GameTimer();
        }

        if (orderList.Count <= (orderLength - 1)) {
            OrderUp();
        }
    }

    void OrderUp() {
        while (orderList.Count < orderLength) {

            int rI = Random.Range(0, pickUps.Count);
            orderList.Add(pickUps[rI]);
            audiotest.Play(0);
        }
        Debug.Log(orderList.Count);

        //setting the visuals on the floor in relation to the order
        for (int j = 0; j <= 3; j++) {
            GameObject orderSprite;
            orderSprite = Instantiate(orderList[j].GetComponent<ItemController>().balloonSprite, orderVisuals[j].gameObject.transform.position, Quaternion.identity);
            orderSprite.transform.parent = orderVisuals[j].gameObject.transform;
            orderSprite.transform.rotation = orderVisuals[j].gameObject.transform.rotation;
            orderSprite.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //to spawn only one item on each spawn location
    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "PickUp" && other.gameObject.GetComponent<ItemController>().balloonName != "") {
           if (other.gameObject.GetComponent<ItemController>().lastPlayer1 && gameObject.name == "HandInP1" || other.gameObject.GetComponent<ItemController>().lastPlayer2 && gameObject.name == "HandInP2") {
              if (playerScript.objCarry == false) {
                  HandleHandIn(other.gameObject, other.gameObject.GetComponent<ItemController>().pointValue);
              }
          }
        }
    }
    //handles the handin proccess, checking if the item is in the order
    void HandleHandIn(GameObject handInItem, int pIncrease)
    {
      Debug.Log("Hand in Obj" + handInItem.GetComponent<ItemController>().balloonName);
        for (int i = 0; i < orderList.Count; i++)
        {
          Debug.Log("balloon Name in Array" + orderList[i].GetComponent<ItemController>().balloonName);
            if (orderList[i] != null)
            {
                Debug.Log("Made it to point 1");
                if (handInItem.GetComponent<ItemController>().balloonName == orderList[i].GetComponent<ItemController>().balloonName)
                {
                    Debug.Log("Made it to point 2");
                        orderList.Remove(orderList[i]);
                        points += (pIncrease * 2);
                        Debug.Log("Ordered Points: " + points);

                    break;
                } else {
                    points += pIncrease;
                    Debug.Log("Non-Ordered Points: " + points);
                    break;
                }
            }
        }

        Destroy(handInItem.gameObject);
        audiotest.Play(0);
        if (playerScript.pickedUpObj == handInItem.gameObject)
        {
            playerScript.pickedUpObj = null;
            playerScript.inRange = false;
        }
    }
    //Listing all possible pick ups
    void ListPickUps() {
        if (player.tag == "Player1") {
            foreach (GameObject pUP in GameObject.FindGameObjectsWithTag("SPP2")) {
                pickUps.Add(pUP.GetComponent<SpawnFoderScript>().balloonType);
            }
        } else if (player.tag == "Player2") {
            foreach (GameObject pUP in GameObject.FindGameObjectsWithTag("SPP2")) {
                pickUps.Add(pUP.GetComponent<SpawnFoderScript>().balloonType);
            }
        }
    }

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
