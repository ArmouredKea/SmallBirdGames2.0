﻿using System.Collections;
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

    public GameObject otherPlayerGC;

    public int tempPoints;
    public int points;

    //public GameObject baseBalloonObj;
    //holds an enum value as a key, holds a Vector4 for colour
    Dictionary <int, Vector4> balloonColorDic = new Dictionary<int, Vector4>();
    //holds an int as key for hand in, holds a GameObject as handin
    public Dictionary <int, GameObject> handInDic = new Dictionary <int, GameObject>();

    public GameObject handIn1;
    public GameObject handIn2;
    public GameObject handIn3;
    public GameObject handIn4;

    //List<GameObject> pickUps = new List<GameObject>();
    public List<int> orderList = new List<int>();
    //public List<GameObject> orderVisuals = new List<GameObject>();
    public int orderLength;
    public int ordered;
    public int ordersComplete;

    public bool gameEnd;
    public bool paused;
    public bool correctHandIn;

    public bool allClosed;
    public bool frenzyActive;
    private float frenzyTime = 15f;
    public GameObject thisFrenzyCanvas;


    //public GameObject orderTiles;

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

        handInDic.Add(0, handIn1);
        handInDic.Add(1, handIn2);
        handInDic.Add(2, handIn3);
        handInDic.Add(3, handIn4);

        playerScript = player.GetComponent<PC_Overcooked>();
        //OrderList();
        orderLength = 3;
        //ListPickUps();
        OrderUp();
    }

    // Update is called once per frame
    void Update() {
        if (!paused && player.tag == "player1") {
            GameTimer();
        }

        if (frenzyActive) {
          frenzyTime -= Time.deltaTime;
        }
        if (frenzyTime <= 0) {
          frenzyActive = false;
          thisFrenzyCanvas.SetActive(false);
          player.GetComponent<PC_Overcooked>().speed = player.GetComponent<PC_Overcooked>().baseSpeedOC;
          player.GetComponent<PC_Overcooked>().frenzy = false;
        }

        if (ordersComplete == 4) {
          if (tempPoints == 4 && frenzyActive == false) {
            frenzyActive = true;
            thisFrenzyCanvas.SetActive(true);
            frenzyTime = 15f;
            player.GetComponent<PC_Overcooked>().speed = 10;
            player.GetComponent<PC_Overcooked>().frenzy = true;
          } else if (tempPoints <= 3) {
            frenzyActive = false;
            thisFrenzyCanvas.SetActive(false);
            player.GetComponent<PC_Overcooked>().speed = player.GetComponent<PC_Overcooked>().baseSpeedOC;
            player.GetComponent<PC_Overcooked>().frenzy = false;
          }
          points += tempPoints;
          tempPoints = 0;
          Debug.Log("Points : " + points + " : " + player.name);
            if (allClosed) {
                OrderUp();
            }
        }
    }

    void OrderUp() {
        int rI;
        Vector4 temp;
        GameObject tempGO;
        ordersComplete = 0;
        Debug.Log(ordersComplete);
        //setting the visuals on the Boxes in relation to the order
        for (int j = 0; j <= orderLength; j++) {
            rI = Random.Range(1, 4);
            if (orderList[j] == 0) {
              orderList[j] = rI;
            } else {
              orderList.Add(rI);
            }
            if (handInDic.TryGetValue(j, out tempGO)) {
              if (balloonColorDic.TryGetValue(rI, out temp)) {
              tempGO.GetComponent<HandInScript>().balloon.GetComponent<Image>().color = temp;
              tempGO.GetComponent<HandInScript>().balloon.SetActive(true);
              tempGO.GetComponent<HandInScript>().tick.SetActive(false);
              tempGO.GetComponent<HandInScript>().cross.SetActive(false);
              tempGO.GetComponent<HandInScript>().closed = false;
              tempGO.GetComponent<HandInScript>().openLid = true;
            }
                tempGO.GetComponent<HandInScript>().orderID = rI;
            }
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
