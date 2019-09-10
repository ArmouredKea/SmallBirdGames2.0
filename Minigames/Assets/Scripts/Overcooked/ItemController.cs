using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : PickUpParent
{
    public bool lastPlayer1;
    public bool lastPlayer2;
    public GameObject lastPlayerObj;

    public bool held = false;
    public bool filling = false;
    public bool overfill = false;

    public int pointValue;
    public GameObject balloonSprite;

    public void Update() {

    }

    public void LastHeldBy (GameObject other) {
      if (other.gameObject.name == "Player1") {
        lastPlayer2 = false;
        lastPlayer1 = true;
        lastPlayerObj = other;
      } else if (other.gameObject.name == "Player2") {
        lastPlayer1 = false;
        lastPlayer2 = true;
        lastPlayerObj = other;

        }

    }
}
