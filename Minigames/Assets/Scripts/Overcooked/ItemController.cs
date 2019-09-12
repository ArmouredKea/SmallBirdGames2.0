using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : PickUpParent
{

    //public AudioSource audiotestI;

    public bool paused;

    public bool lastPlayer1;
    public bool lastPlayer2;
    public GameObject lastPlayerObj;

    public bool held = false;
    public bool filling = false;
    public bool overfilling = false;

    public int pointValue;
    public GameObject balloonSprite;

    public Vector4 startColor;

    private void Awake() {
      startColor = gameObject.GetComponentInChildren<SpriteRenderer>().color;
    }

    public void LastHeldBy (GameObject other) {
      if (other.gameObject.tag == "Player1") {
        lastPlayer2 = false;
        lastPlayer1 = true;
        lastPlayerObj = other;
      } else if (other.gameObject.tag == "Player2") {
        lastPlayer1 = false;
        lastPlayer2 = true;
        lastPlayerObj = other;

        }

    }

    public bool dInRange;
    public bool dispensing;
    public int dispenseTime;
    public bool filled;

    public GameObject currentDispenser;

    void OnTriggerEnter2D(Collider2D other) {
      if (other.tag == "Dispenser") {
        currentDispenser = other.gameObject;
        dispenseTime = other.gameObject.GetComponent<Dispenser>().dispenseTime;
        dInRange = true;
      }

    }

    void Update() {
        if (dInRange) {
          if (dispensing == false && held == false && filled != true) {
            dispensing = true;
            filling = true;
            StartCoroutine(FillingBalloon(currentDispenser));
          } else if (held) {
            dispensing = false;
          }
        }
      }

    //handles "filling" the balloon
    IEnumerator FillingBalloon (GameObject other) {
        //tempLastHeld = lastPlayerObj;
        //Destroy(other.gameObject);
        //audiotestI.Play(0);
        balloonName = other.gameObject.GetComponent<Dispenser>().dBalloonName;
        pointValue = other.gameObject.GetComponent<Dispenser>().points;
        float l = 0;
        while (l < dispenseTime) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                gameObject.GetComponentInChildren<SpriteRenderer>().color = Vector4.Lerp(gameObject.GetComponentInChildren<SpriteRenderer>().color, other.gameObject.GetComponent<Dispenser>().dColor, (l/dispenseTime));
                yield return null;
            }
        }
        filled = true;
        filling = false;
        //other = Instantiate(dispensedB, this.gameObject.transform.position, Quaternion.identity);
        //overfilling = true;
        //other.gameObject.GetComponent<ItemController>().lastPlayerObj = tempLastHeld;
        StartCoroutine(Overfill());
    }

    //checks if the balloon is being overfilled, and then makes it explode
    IEnumerator Overfill () {
        float l = 0;
        while (l < 2.5f && dispensing) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                gameObject.transform.localScale += new Vector3 (l/30, l/30, l/30);
                yield return null;
            }
        }
        if (dispensing) {
            //audiotestI.Play(0);
            Destroy(gameObject);
            dispensing = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Dispenser") {
            dispensing = false;
            dInRange = false;
            currentDispenser = null;
        }
    }
    /*public GameObject dispensedB;
    public int dispenseTime;
    public bool dispensing;
    public bool dispensingP2;

    private GameObject tempLastHeld;

    public Color dColor;
    public bool paused;

    //calling colour change spritesheet.
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "DrinkEmpty(Clone)" && dispensingP1 == false) {
            if (other.gameObject.GetComponent<ItemController>().held == false && other.gameObject.GetComponent<ItemController>().lastPlayer1 == true) {
                dispensingP1 = true;
                filling = true;
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
    } */
}
