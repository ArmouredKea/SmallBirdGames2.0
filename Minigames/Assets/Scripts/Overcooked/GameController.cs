using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject player;
    //public GameObject spawn;

    //needed an item that was null
    private GameObject nullItem;

    private PC_Overcooked playerScript;
    public ItemScript itemScript;

    public int points;

    List<GameObject> pickUps = new List<GameObject>();
    public List<GameObject> orderList = new List<GameObject>();
    List<GameObject> orderVisuals = new List<GameObject>();
    public int orderLength;
    public int ordered;

    public bool gameEnd;

    public GameObject orderTiles;

    //Timer Variable
    private float endTimer = 60f;

    // Start is called before the first frame update
    void Start() {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        OrderList();
        orderLength = 4;
        ListPickUps();
        playerScript = player.GetComponent<PC_Overcooked>();
        OrderUp();
    }

    // Update is called once per frame
    void Update() {
        GameTimer();
        if (ordered >= orderLength) {
            ordered = 0;
            
            for (int p = orderLength - 1; p >= 0; p--) {
                orderList.Remove(orderList[p]);
            }
        }

        if (orderList.Count <= 0) {
            OrderUp();
        }
    }

    void OrderUp() {
        for (int i = 1; i <= orderLength; i++) {

            int rI = Random.Range(0, pickUps.Count);
            orderList.Add(pickUps[rI]);
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
        if (other.tag == "PickUp" && other.name != "DrinkEmpty(Clone)") {
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
        for (int i = 0; i < orderList.Count; i++)
        {
            if (orderList[i] != null)
            {
                Debug.Log("Made it to point 1");
                if (handInItem.GetComponent<ItemController>().balloonName == orderList[i].GetComponent<ItemController>().balloonName)
                {
                    Debug.Log("Made it to point 2");
                    foreach (Transform child in orderVisuals[i].transform)
                    {
                        Debug.Log("Made it to point 3");
                        Destroy(child.gameObject);
                        orderList[i] = nullItem;
                        ordered += 1;
                        
                    }
                    break;
                }
            }
        }
        points += pIncrease;
        Debug.Log(points);
        Destroy(handInItem.gameObject);
        if (playerScript.pickedUpObj == handInItem.gameObject)
        {
            playerScript.pickedUpObj = null;
            playerScript.inRange = false;
        }
    }
    //Listing all possible pick ups
    void ListPickUps() {
        if (player.name == "Player1") {
            foreach (GameObject pUP in GameObject.FindGameObjectsWithTag("SPP2")) {
                pickUps.Add(pUP.GetComponent<SpawnFoderScript>().balloonType);
            }
        } else if (player.name == "Player2") {
            foreach (GameObject pUP in GameObject.FindGameObjectsWithTag("SPP2")) {
                pickUps.Add(pUP.GetComponent<SpawnFoderScript>().balloonType);
            }
        }
        //Debug.Log(pickUps.Count);
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
    }
}
