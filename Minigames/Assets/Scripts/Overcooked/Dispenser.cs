using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public GameObject dispensedB;
    public int dispenseTime;
    public bool dispensingP1;
    public bool dispensingP2;

    private GameObject tempLastHeld;

    public Color dColor;
    public string dBalloonName;
    public int points;
    /*public bool paused;

    void Update() {

    }

    //calling colour change spritesheet.
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "DrinkEmpty(Clone)" && dispensingP1 == false) {
            if (other.gameObject.GetComponent<ItemController>().held == false && other.gameObject.GetComponent<ItemController>().lastPlayer1 == true) {
                dispensingP1 = true;
                other.gameObject.GetComponent<ItemController>().filling = true;
                StartCoroutine(FillingBalloon(other.gameObject, true, false));
            }
      }
        if (other.gameObject.name == "DrinkEmpty(Clone)" && dispensingP2 == false)
        {
            if (other.gameObject.GetComponent<ItemController>().held == false && other.gameObject.GetComponent<ItemController>().lastPlayer2 == true)
            {
                dispensingP2 = true;
                other.gameObject.GetComponent<ItemController>().filling = true;
                StartCoroutine(FillingBalloon(other.gameObject, false, true));
            }
        }
    }

    //handles "filling" the balloon
    IEnumerator FillingBalloon (GameObject other, bool p1, bool p2) {
        tempLastHeld = other.gameObject.GetComponent<ItemController>().lastPlayerObj;
        Destroy(other.gameObject);
        float l = 0;
        while (l < dispenseTime) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                yield return null;
            }
        }
        other = Instantiate(dispensedB, this.gameObject.transform.position, Quaternion.identity);
        other.gameObject.GetComponent<ItemController>().overfill = true;
        other.gameObject.GetComponent<ItemController>().lastPlayerObj = tempLastHeld;
        StartCoroutine(Overfill(other.gameObject, p1, p2));
    }

    //checks if the balloon is being overfilled, and then makes it explode
    IEnumerator Overfill (GameObject other, bool p1, bool p2) {
        float l = 0;
        while (l < 2.5f) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                yield return null;
            }
        }
        if (other.gameObject != null && other.gameObject.GetComponent<ItemController>().overfill) {
            Destroy(other.gameObject);
            if (p1) {
                dispensingP1 = false;
            } else {
                dispensingP2 = false;
            }
        } else {
            other = null;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "PickUp" && other.gameObject.name != "DrinkEmpty(Clone)" && dispensingP1 == true) {
            dispensingP1 = false;
        }
        if (other.gameObject.tag == "PickUp" && other.gameObject.name != "DrinkEmpty(Clone)" && dispensingP2 == true)
        {
            dispensingP2 = false;
        }
    }
}
