using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagScript : MonoBehaviour
{

    public bool tagged = false;
    public bool it = false;
    public GameObject tagIcon;
    public GameObject pointLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (it) {
            tagIcon.SetActive(true);
            pointLight.GetComponent<Light>().spotAngle = 60;
        } else if (it == false) {
            tagIcon.SetActive(false);
            pointLight.GetComponent<Light>().spotAngle = 40;
        }

        if (tagged) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision) {

        if ((collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2") && it == false) {
            tagged = true;
            it = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<PlayerController>().speed = 0;
            if (gameObject.name == "Player1") {
                GameObject.Find("LeftIJ").GetComponent<JoystickController>().speed = 0;
            } else if (gameObject.name == "Player2") {
                GameObject.Find("RightIJ").GetComponent<JoystickController>().speed = 0;
            }
                StartCoroutine(TagDelay(2f));
        } else if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") && it == true) {
            it = false;
        }

    }

    private IEnumerator TagDelay(float waitTime) {

        yield return new WaitForSeconds(waitTime);
        tagged = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<PlayerController>().speed = 7;
        GameObject.Find("LeftIJ").GetComponent<JoystickController>().speed = 7;
        GameObject.Find("RightIJ").GetComponent<JoystickController>().speed = 7;

    }
}
