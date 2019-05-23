﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public bool lastPlayer1;
    public bool lastPlayer2;

    public void LastHeldBy (GameObject other) {

      if (other.gameObject.name == "Player1") {
        lastPlayer2 = false;
        lastPlayer1 = true;
      } else if (other.gameObject.name == "Player2") {
        lastPlayer1 = false;
        lastPlayer2 = true;
      }

    }
}