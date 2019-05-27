using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoystickController : MonoBehaviour {

    public GameObject player;
    public float speed = 5.0f;
    public bool touched = false;
    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 initialPoint;
    public Transform joystickOuter;
    public Transform joystickInner;

    public List<PlayerController> Players = new List<PlayerController>();

    private bool bumperCars;
    private bool overcooked;

    // Use this for initialization
    void Start () {
        Input.multiTouchEnabled = true;
        pointA = gameObject.transform.position;
        initialPoint = Camera.main.ScreenToWorldPoint(new Vector3(pointA.x, pointA.y, Camera.main.transform.position.z));

        bumperCars = false;
        overcooked = false;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "BumperCarsMG") {
            bumperCars = true;
            Debug.Log("BumperCars!");
        } else if (scene.name == "OvercookedMG") {
            overcooked = true;
            Debug.Log("Overcooked!");
        }
    }

	// Update is called once per frame
	void Update () {

        //multitouch stuff
        for (int i = 0; i < Input.touchCount; i++) {
            Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            foreach (var player in Players) {
                if (player.LockedFingerID == null) {
                    if (Input.GetTouch(i).phase == TouchPhase.Began && joystickInner.GetComponent<Collider2D>().OverlapPoint(touchWorldPos)) {
                        player.LockedFingerID = Input.GetTouch(i).fingerId;
                    }
                } else if (player.LockedFingerID == Input.GetTouch(i).fingerId) {
                    touched = true;
                    pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 1));
                    //player.MoveToPosition(touchWorldPos);
                    if (Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled) {
                        touched = false;
                        joystickInner.transform.position = pointA;
                        player.LockedFingerID = null;
                    }
                }
            }
        }

        if (bumperCars) {
            if (player.GetComponent<PlayerController>().boosted == true) {
                speed = 15f;
            } else {
                speed = 5f;
            }
        }

    }

    void FixedUpdate() {

        //if touched or clicked, use joystick
        if (touched) {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 0.5f);
            MoveCharacter(direction);
            joystickInner.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }

    }

    //move character...
    void MoveCharacter(Vector2 direction) {
        if (bumperCars) {
            player.GetComponent<Rigidbody2D>().AddForce(direction * speed * 2);
        } else if (overcooked) {
            player.GetComponent<Transform>().Translate(direction * speed * Time.deltaTime, Space.World);
            //player.GetComponent<Rigidbody2D>().AddForce(direction * speed * 2);
        }
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0, 0, angle * -1);
    }
}
