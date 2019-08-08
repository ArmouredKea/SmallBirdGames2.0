using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public GameObject dispensedB;
    public int dispenseTime;
    public bool dispensing;

    public Color dColor;

    private void Update()
    {
    }

    //calling colour change spritesheet.
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "DrinkEmpty(Clone)" && dispensing == false) {
            if (other.gameObject.GetComponent<ItemController>().held == false) {
                dispensing = true;
                other.gameObject.GetComponent<ItemController>().filling = true;
                StartCoroutine(FillingBalloon(other.gameObject));
               //other.gameObject.GetComponentInChildren<SpriteRenderer>().color = dColor;
            }
      }
    }

    //handles "filling" the balloon
    IEnumerator FillingBalloon (GameObject other) {
        Destroy(other.gameObject);
        yield return new WaitForSeconds(dispenseTime);
        other = Instantiate(dispensedB, this.gameObject.transform.position, Quaternion.identity);
        other.gameObject.GetComponent<ItemController>().overfill = true;
        StartCoroutine(Overfill(other.gameObject));
    }

    //checks if the balloon is being overfilled, and then makes it explode
    IEnumerator Overfill (GameObject other) {
        yield return new WaitForSeconds(2.5f);
        if (other.gameObject.GetComponent<ItemController>().overfill) {
            Destroy(other.gameObject);
            dispensing = false;
        } else {
            other = null;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "PickUp" && other.gameObject.name != "DrinkEmpty(Clone)" && dispensing == true) {
            dispensing = false;
        }
    }
}
