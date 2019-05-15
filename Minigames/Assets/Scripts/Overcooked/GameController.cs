using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject player;
    public GameObject spawn;

    //needed an item that was null
    private GameObject nullItem;

    private PlayerController playerScript;
    public ItemScript itemScript;

    public int points;

    List<GameObject> pickUps = new List<GameObject>();
    public List<GameObject> orderList = new List<GameObject>();
    List<GameObject> orderVisuals = new List<GameObject>();
    public int orderLength;
    public int ordered;

    public bool gameEnd;

    public GameObject orderTiles;
    public GameObject orderSpriteOne;
    public GameObject orderSpriteTwo;
    public GameObject orderSpriteThree;
    public GameObject orderSpriteFour;

    //Timer Variable
    private float endTimer = 60f;

    // Start is called before the first frame update
    void Start() {

        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        OrderList();
        orderLength = 4;
        ListPickUps();
        playerScript = player.GetComponent<PlayerController>();
        OrderUp();

    }

    // Update is called once per frame
    void Update() {

        GameTimer();
        if (ordered >= orderLength) {
            ordered = 0;
            points++;
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

        //setting the visuals on the floor in relation to the order
        for (int j = 0; j <= 3; j++) {
            GameObject orderSprite;
            if (orderList[j].name == "DrinkSpawnP1G" || orderList[j].name == "DrinkSpawnP2G") {
                orderSprite = Instantiate(orderSpriteOne, orderVisuals[j].gameObject.transform.position, Quaternion.identity);
                orderSprite.transform.parent = orderVisuals[j].gameObject.transform;
                orderSprite.transform.rotation = orderVisuals[j].gameObject.transform.rotation;
                orderSprite.transform.localScale = new Vector3(1, 1, 1);
            } else if (orderList[j].name == "DrinkSpawnP1R" || orderList[j].name == "DrinkSpawnP2R") {
                orderSprite = Instantiate(orderSpriteTwo, orderVisuals[j].gameObject.transform.position, Quaternion.identity);
                orderSprite.transform.parent = orderVisuals[j].gameObject.transform;
                orderSprite.transform.rotation = orderVisuals[j].gameObject.transform.rotation;
                orderSprite.transform.localScale = new Vector3(1, 1, 1);
            } else if (orderList[j].name == "DrinkSpawnP1W" || orderList[j].name == "DrinkSpawnP2W") {
                orderSprite = Instantiate(orderSpriteThree, orderVisuals[j].gameObject.transform.position, Quaternion.identity);
                orderSprite.transform.parent = orderVisuals[j].gameObject.transform;
                orderSprite.transform.rotation = orderVisuals[j].gameObject.transform.rotation;
                orderSprite.transform.localScale = new Vector3(1, 1, 1);
            } else if (orderList[j].name == "DrinkSpawnP1Y" || orderList[j].name == "DrinkSpawnP2Y") {
                orderSprite = Instantiate(orderSpriteFour, orderVisuals[j].gameObject.transform.position, Quaternion.identity);
                orderSprite.transform.parent = orderVisuals[j].gameObject.transform;
                orderSprite.transform.rotation = orderVisuals[j].gameObject.transform.rotation;
                orderSprite.transform.localScale = new Vector3(1, 1, 1);
            }

        }

    }

    //Handles the hand in funcion for both player and
    //score, and removes an item from the list of hand ins on hand in.
    void OnTriggerStay2D(Collider2D other) {

        if (other.tag == "PickUp" || other.tag == "PickUp1") {
            if (playerScript.objCarry == false) {

                for (int i = 0; i < orderList.Count; i++) {
                    if (orderList[i] != null) {
                        if (other.name == "DrinkP1G(Clone)" && orderList[i].name == "DrinkSpawnP1G" || other.name == "DrinkP2G(Clone)" && orderList[i].name == "DrinkSpawnP2G") {
                            foreach (Transform child in orderVisuals[i].transform) {
                                Destroy(child.gameObject);
                                orderList[i] = nullItem;
                                ordered += 1;
                                Destroy(other.gameObject);
                                if (playerScript.pickedUpObj == other.gameObject) {
                                    playerScript.pickedUpObj = null;
                                    playerScript.inRange = false;
                                }
                            }
                            break;
                        } else if (other.name == "DrinkP1R(Clone)" && orderList[i].name == "DrinkSpawnP1R" || other.name == "DrinkP2R(Clone)" && orderList[i].name == "DrinkSpawnP2R") {
                            foreach (Transform child in orderVisuals[i].transform) {
                                Destroy(child.gameObject);
                                orderList[i] = nullItem;
                                ordered += 1;
                                Destroy(other.gameObject);
                                if (playerScript.pickedUpObj == other.gameObject) {
                                    playerScript.pickedUpObj = null;
                                    playerScript.inRange = false;
                                }
                            }
                            break;
                        } else if (other.name == "DrinkP1W(Clone)" && orderList[i].name == "DrinkSpawnP1W" || other.name == "DrinkP2W(Clone)" && orderList[i].name == "DrinkSpawnP2W") {
                            foreach (Transform child in orderVisuals[i].transform) {
                                Destroy(child.gameObject);
                                orderList[i] = nullItem;
                                ordered += 1;
                                Destroy(other.gameObject);
                                if (playerScript.pickedUpObj == other.gameObject) {
                                    playerScript.pickedUpObj = null;
                                    playerScript.inRange = false;
                                }
                            }
                            break;
                        } else if (other.name == "DrinkP1Y(Clone)" && orderList[i].name == "DrinkSpawnP1Y" || other.name == "DrinkP2Y(Clone)" && orderList[i].name == "DrinkSpawnP2Y") {
                            foreach (Transform child in orderVisuals[i].transform) {
                                Destroy(child.gameObject);
                                orderList[i] = nullItem;
                                ordered += 1;
                                Destroy(other.gameObject);
                                if (playerScript.pickedUpObj == other.gameObject) {
                                    playerScript.pickedUpObj = null;
                                    playerScript.inRange = false;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
    }

    //Listing all possible pick ups
    void ListPickUps() {

        if (player.name == "Player1") {
            foreach (GameObject pUP in GameObject.FindGameObjectsWithTag("SPP1")) {
                pickUps.Add(pUP);
            }
        } else if (player.name == "Player2") {
            foreach (GameObject pUP in GameObject.FindGameObjectsWithTag("SPP2")) {
                pickUps.Add(pUP);
            }
        }

    }

    //adding the order visual tiles to a list
    void OrderList() {

        foreach (Transform child in orderTiles.transform) {
            orderVisuals.Add(child.gameObject);
        }

    }

    //Timer
    void GameTimer() {

        endTimer -= Time.deltaTime;
        if (endTimer <= 0) {
            gameEnd = true;
        }

    }

}
