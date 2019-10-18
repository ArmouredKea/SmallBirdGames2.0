using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandInScript : MonoBehaviour
{
    public GameObject audioManager;

    public int handInID;
    public GameObject lid;
    public GameObject balloon;
    public GameObject tick;
    public GameObject cross;
    public GameObject plusOne;
    public Vector3 lidStartV;
    public Vector3 lidEndV;
    public bool closed;
    public bool correctHandIn;
    public bool closing;
    public int orderID;
    public float moveTime = 0;
    public bool openLid;


    private GameController gameControllerScript;

    void Start() {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        gameControllerScript = gameObject.transform.parent.gameObject.GetComponent<GameController>();
        lidStartV = lid.transform.position;
        lidEndV = new Vector3(lidStartV.x, (lidStartV.y - 0.48f), lidStartV.z);
    }

    void Update() {
        if (openLid) {
            closing = false;
            closed = false;
        }
        HandleLid();
    }

    void HandleLid() {
      //Opens Lid of box
      if (openLid) {
        if (lid.transform.position != lidStartV) {
            moveTime += Time.deltaTime;
            lid.transform.position = Vector3.Lerp(lidEndV, lidStartV, moveTime/0.6f);
        }
      }
      //Close lid of box
      if (closing) {
          moveTime += Time.deltaTime;
          lid.transform.position = Vector3.Lerp(lidStartV, lidEndV, moveTime/0.6f);
          gameControllerScript.allClosed = false;
          if (lid.transform.position == lidEndV) {
            gameControllerScript.ordersComplete += 1;
            closing = false;
            closed = true;
          }
      }
      //checks if all boxs is closed
      if (closed) {
        moveTime = 0;
        if (gameControllerScript.ordersComplete == 4) {
          gameControllerScript.allClosed = true;
        }
      }
      //checks if lid is closed and resets variabls
      if (lid.transform.position == lidStartV) {
        moveTime = 0;
        openLid = false;
        balloon.SetActive(true);
        correctHandIn = false;
      }
      if (openLid && correctHandIn) {
            plusOne.SetActive(true);
      } else {
            plusOne.SetActive(false);
      }
    }

    public void HandleHandIn (int balloonID) {
            //Debug.Log("Hand in ID" + balloonID);
            //Checks if balloon exists and balloon has a colour
            if (gameControllerScript.orderList[handInID] != 0 && balloonID != 0 || gameControllerScript.frenzyActive) {
                Debug.Log("Made it to point 1");
                    //checks if box is closed
                    if (closed == false && balloonID != 0) {
                      if (closing == false && balloonID != 0) {
                          //checks if in frenzy then runs frenzy function
                          if (gameControllerScript.frenzyActive) {
                            FrenzyMode(handInID);
                          }
                          correctHandIn = false;
                          //checks if balloonID is the same as the BoxID then sets all correct hand in variables
                          if (balloonID == orderID) {
                              Debug.Log("Made it to point 2");
                              correctHandIn = true;
                              balloon.SetActive(false);
                              tick.SetActive(true);
                              audioManager.GetComponent<AudioManagerScript>().PlayAudio("Order");
                              gameControllerScript.orderList[handInID] = 0;
                              gameControllerScript.tempPoints += 1;
                          } else {
                              //runs logic on incorrect hand in.=
                              gameControllerScript.orderList[handInID] = 0;
                              correctHandIn = false;
                              balloon.SetActive(false);
                              cross.SetActive(true);
                          }
                          closing = true;
                      }
                        closing = true;
                    }
          }
    }

    //Frenzy Buff function
    //Closes corresponding players hand in box while in frenzy mode
    void FrenzyMode(int boxID) {
      GameObject temp;
        if (gameControllerScript.otherPlayerGC.GetComponent<GameController>().handInDic.TryGetValue(boxID, out temp)) {
          if (temp.GetComponent<HandInScript>().closing || temp.GetComponent<HandInScript>().closed) {
            return;
          } else {
            temp.GetComponent<HandInScript>().closing = true;
            temp.GetComponent<HandInScript>().balloon.SetActive(false);
            temp.GetComponent<HandInScript>().correctHandIn = false;

          }
        }
    }
}
