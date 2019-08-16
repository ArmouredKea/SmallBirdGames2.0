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
    public Vector2 direction;
    public Animator animator;

    public List<PlayerController> Players = new List<PlayerController>();
    //public PlayerController Controller;
    public int? LockedFingerID { get; set; }

    private Vector2 startPos;

    public static int p1Score;
    public static int p2Score;

    public bool paused;
    public float angle;

    // Start is called before the first frame update
    protected virtual void Start() {
        Input.multiTouchEnabled = true;
        pointA = joystickInner.transform.position;
        initialPoint = Camera.main.ScreenToWorldPoint(new Vector3(pointA.x, pointA.y, Camera.main.transform.position.z));
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update() {
        //multitouch stuff
        if (paused == false) {
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
        } else if (paused) {
            touched = false;
            joystickInner.transform.position = pointA;
        }
    }

    protected virtual void FixedUpdate() {
        //if touched or clicked, use joystick
        Vector2 offset = pointB - pointA;
        direction = Vector2.ClampMagnitude(offset, 0.5f);
        if (touched) {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            MoveCharacter(direction);
            joystickInner.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }
    }

    //move character...
    protected virtual void MoveCharacter(Vector2 direction) {        
        angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle * -1);
    }

    protected virtual void OnEnable() {
        Players.Add(this);
    }
    protected virtual void OnDisable() {
        Players.Remove(this);
    }
}
