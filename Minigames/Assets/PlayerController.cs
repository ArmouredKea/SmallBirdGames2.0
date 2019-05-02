using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Player's forward/backward speed and rotation speed variables.
    public float speed = 5.0f;
    private float rotationSpeed = 100.0f;

    private Vector2 currentPosition;
    float totalDistance = 0f;

    public JoystickController Controller;
    public int? LockedFingerID { get; set; }

    // Use this for initialization
    void Start () {
        currentPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //calculates distance travelled.
        float distance = Vector2.Distance(currentPosition, gameObject.transform.position);        
        totalDistance += distance;
        currentPosition = gameObject.transform.position;
        
        //player boost.
        if (totalDistance >= 50f) {
            speed = 15.0f;
            gameObject.GetComponent<Rigidbody2D>().mass = 2;

            if (gameObject.tag == "Player1") {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
            } else if (gameObject.tag == "Player2") {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
            }

            StartCoroutine(BoostDuration(5f));
        }
    }

    void FixedUpdate()
    {
        //transform.Translate(0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
        //Vector2 movement = new Vector2(0, Input.GetAxis("Vertical"));
        //GetComponent<Rigidbody2D>().freezeRotation = true;
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, Input.GetAxis("Vertical") * speed);

        //Player forward/backward movement and rotation.
        if (gameObject.tag == "Player1") {
            GetComponent<Rigidbody2D>().AddForce(transform.up * Input.GetAxis("VerticalP1") * speed);
            transform.Rotate(0f, 0f, Input.GetAxis("HorizontalP1") * rotationSpeed * Time.deltaTime * -1);
        } else if (gameObject.tag == "Player2") {
            GetComponent<Rigidbody2D>().AddForce(transform.up * Input.GetAxis("VerticalP2") * speed);
            transform.Rotate(0f, 0f, Input.GetAxis("HorizontalP2") * rotationSpeed * Time.deltaTime * -1);
        } else {
            return;
        }

    }

    //player boost duration.
    private IEnumerator BoostDuration(float waitTime) {
        yield return new WaitForSeconds(waitTime);

        if (gameObject.tag == "Player1") {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else if (gameObject.tag == "Player2") {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.6f, 0.2f, 1);
        }

        speed = 5.0f;
        gameObject.GetComponent<Rigidbody2D>().mass = 1;
        totalDistance = 0f;
    }

    private void OnEnable() {
        Controller.Players.Add(this);
    }
    private void OnDisable() {
        Controller.Players.Remove(this);
    }
}
