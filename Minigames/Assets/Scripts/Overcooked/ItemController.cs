using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : PickUpParent
{

    //public AudioSource audiotestI;

    //public bool paused;

    //public bool lastPlayer1;
    //public bool lastPlayer2;
    //public GameObject lastPlayerObj;

  //  public bool held = false;
    //public bool filling = false;
    //public bool overfilling = false;

  //  public int pointValue;
    //public GameObject balloonSprite;

    //public Vector4 startColor;
/*
    private void Awake() {
      startColor = gameObject.GetComponentInChildren<SpriteRenderer>().color;
    }

    //Sets balloons last held player
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
 */
    public bool dInRange;
    public bool dispensing;
    public int dispenseTime;
    public bool filled;
    public bool canD;

    public bool handInInRange;

    public GameObject currentDispenser;
 /*
    void OnTriggerEnter2D(Collider2D other) {
      //checks if a despenser is in range
      if (other.tag == "Dispenser") {
        currentDispenser = other.gameObject;
        dispenseTime = other.gameObject.GetComponent<Dispenser>().dispenseTime;
        dInRange = true;
      }
      //checks if the handin pint is in range
      if (other.tag == "Finish") {
        Debug.Log(other.tag);
        handInInRange = true;
      }

    }

    void Update() {
        if (dInRange) {

          //checks if the balloon is able to be filled in the dispenser
          if (currentDispenser.GetComponent<Dispenser>().dispensingP1 == true && lastPlayer1 ||
              currentDispenser.GetComponent<Dispenser>().dispensingP2 == true && lastPlayer2 ||
              filled) {
            canD = false;
          } else {
            canD = true;
          }

          //another check to see if the balloon is already filled and to see if it is being held
          if (held == false && filled != true && canD) {
            filling = true;
            dispensing = true;
            if (lastPlayer1) {
              currentDispenser.GetComponent<Dispenser>().dispensingP1 = true;
            } else {
              currentDispenser.GetComponent<Dispenser>().dispensingP2 = true;
            }
            StartCoroutine(FillingBalloon(currentDispenser));

            //checks if the balloon is dropped within the dispenser bounds while another balloon is being dispensed and destroys it if it has
          } else if (held == false && canD == false && lastPlayerObj != null && dispensing == false) {
            Debug.Log("if it reaches this something iswrong");
            Destroy(gameObject);

            //checks if the balloon is picked up while being filled
          } else if (held) {
              dispensing = false;
            if (currentDispenser.GetComponent<Dispenser>().dispensingP1 && this.filled) {
              currentDispenser.GetComponent<Dispenser>().dispensingP1 = false;
            } else if (currentDispenser.GetComponent<Dispenser>().dispensingP2 && this.filled) {
              currentDispenser.GetComponent<Dispenser>().dispensingP2 = false;
            }
          }

            //checks if the balloon is dropped and destroys it if it has
        } else if (held == false && lastPlayerObj != null && canD == false && handInInRange == false) {
          Debug.Log("if it reaches this something iswrong2.0");
          Destroy(gameObject);
        }
      }

    //handles "filling" the balloon
    IEnumerator FillingBalloon (GameObject other) {
        //insert audio code here
        balloonName = other.gameObject.GetComponent<Dispenser>().dBalloonName;
        pointValue = other.gameObject.GetComponent<Dispenser>().points;
        float l = 0;
        while (l < dispenseTime) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                //psuedo filling animation
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
        while (l < 3.5f && dispensing) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                //changes size of the balloon when overfilling
                gameObject.transform.localScale += new Vector3 (l/300, l/300, l/300);
                yield return null;
            }
        }
        //checks at the end of the time limit if the balloon has been picked up or not then explodes if not
        if (dispensing) {
            //audiotestI.Play(0);
            if (currentDispenser.GetComponent<Dispenser>().dispensingP1) {
              currentDispenser.GetComponent<Dispenser>().dispensingP1 = false;
              dispensing = false;
            } else {
              currentDispenser.GetComponent<Dispenser>().dispensingP2 = false;
              dispensing = false;
            }
            Destroy(gameObject);

        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Dispenser") {
            dispensing = false;
            dInRange = false;
            currentDispenser = null;
        }
        if (other.tag == "Finish") {
          handInInRange = false;
        }
    }

    */
}
