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
        Debug.Log(other);
        if (other.gameObject.name == "DrinkEmpty(Clone)" && dispensing == false) {
            if (other.gameObject.GetComponent<ItemController>().held == false) {
                dispensing = true;
                other.gameObject.GetComponent<ItemController>().filling = true;
                StartCoroutine(FillingBalloon(other.gameObject));
               //other.gameObject.GetComponentInChildren<SpriteRenderer>().color = dColor;
            }
      }
    }

    IEnumerator FillingBalloon (GameObject other) {
        Destroy(other.gameObject);
        yield return new WaitForSeconds(dispenseTime);
        other = Instantiate(dispensedB, this.gameObject.transform.position, Quaternion.identity);
        other.gameObject.GetComponent<ItemController>().overfill = true;
        StartCoroutine(Overfill(other.gameObject));
        /*for (int i = 0; i <= 4; i++) {
            Debug.Log("0.5s Passed");
            if (other.gameObject.GetComponent<ItemController>().overfill == false) {
                Debug.Log("Break");
                break;
            } else {
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (other.gameObject.GetComponent<ItemController>().overfill) {
            ExplodeBalloon(other);
        }*/
    }

    IEnumerator Overfill (GameObject other) {
        yield return new WaitForSeconds(2.5f);
        if (other.gameObject.GetComponent<ItemController>().overfill) {
            Destroy(other.gameObject);
            dispensing = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "PickUp" && other.gameObject.name != "DrinkEmpty(Clone)" && dispensing == true) {
            dispensing = false;
        }
    }

    private void ExplodeBalloon(GameObject other) {
        Destroy(other.gameObject);
        dispensing = false;
    }

}
