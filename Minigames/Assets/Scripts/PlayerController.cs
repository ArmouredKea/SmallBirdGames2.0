using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public float rotationSpeed;    
    
    public bool touched;
    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 initialPoint;
    public Transform joystickOuter;
    public Transform joystickInner;

    public List<PlayerController> Players = new List<PlayerController>();
    public PlayerController Controller;
    public int? LockedFingerID { get; set; }   

    private Vector2 startPos;

    public static int p1Score;
    public static int p2Score;

    // Start is called before the first frame update
    void Start() {
        Input.multiTouchEnabled = true;
        pointA = gameObject.transform.position;
        initialPoint = Camera.main.ScreenToWorldPoint(new Vector3(pointA.x, pointA.y, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update() {
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
    public virtual void MoveCharacter(Vector2 direction) {        
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle * -1);
    }

    public void OnEnable() {
        Controller.Players.Add(this);
    }
    public void OnDisable() {
        Controller.Players.Remove(this);
    }
}
