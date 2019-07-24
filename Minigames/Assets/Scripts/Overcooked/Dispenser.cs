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
        Instantiate(dispensedB, this.gameObject.transform.position, Quaternion.identity);
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "PickUp" && other.gameObject.name != "DrinkEmpty(Clone)" && dispensing == true) {
            dispensing = false;
        }
    }

}
