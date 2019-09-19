using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC_Overcooked : PlayerController {

    public GameObject pickedUpObj;

    //controls axis
    public float vertMovement;
    public float horiMovement;
    public float pickUpC;
    public bool puAxisInUse;
    public bool oButtonPressed;

    public float baseSpeedOC;

    //obj picked up bool
    public bool inRange;
    public bool objCarry;
    public float castTime;
    private float endCastTime = 0.5f;

    public int balloonEnumInt;
    public Image pickUpImg;

    public bool frenzy;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        speed = 7.5f;
        rotationSpeed = 100.0f;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
        if (!touched && !paused) {
            animator.SetBool("Moving", false);
            GetComponent<Animator>().speed = 0;
            castTime = castTime;
        } else {
            animator.SetBool("Moving", true);
            GetComponent<Animator>().speed = 1;
        }
        if (inRange && objCarry == false) {
          castTime += Time.deltaTime;
          pickUpImg.fillAmount = (castTime/endCastTime);
          if (castTime >= endCastTime) {
              objCarry = true;
          }
        }

    }


    protected override void FixedUpdate() {
        if (!paused) {
            base.FixedUpdate();
            Movement();

        }
    }

    protected override void MoveCharacter(Vector2 direction) {
        base.MoveCharacter(direction);
        gameObject.GetComponent<Transform>().Translate(direction * speed * Time.deltaTime, Space.World);
    }

    //Movement Function
    public void Movement() {

        Controls();

        float moveY = 0f;
        float moveX = 0f;

        moveY = vertMovement * speed;
        moveX = horiMovement * speed;

        moveX *= Time.deltaTime;
        moveY *= Time.deltaTime;

        transform.Translate(0, moveY, 0);
        transform.Translate(moveX, 0, 0);

    }

    void Controls() {

        if (gameObject.tag == "Player1") {
            vertMovement = Input.GetAxis("Vertical");
            horiMovement = Input.GetAxis("Horizontal");
        }
        if (gameObject.tag == "Player2") {
            vertMovement = Input.GetAxis("Vertical1");
            horiMovement = Input.GetAxis("Horizontal1");
        }+7
    }

    //Referencing gameObject (PickUp) that you are near
    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Crate") {
            if (objCarry == false) {
                inRange = true;
                castTime = 0f;
                pickUpImg.color = other.gameObject.GetComponent<Dispenser>().dColor;
                balloonEnumInt = other.gameObject.GetComponent<Dispenser>().dBalloonEnumInt;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
      if (other.gameObject.tag == "Crate") {
        inRange = false;
        if (objCarry == false) {
          Debug.Log("Reset Fill Amount");
          pickUpImg.fillAmount = 0;
          balloonEnumInt = 0;
        }
      }

    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Bin") {
          objCarry = false;
          pickUpImg.fillAmount = 0;
          balloonEnumInt = 0;
        }
        if (other.gameObject.tag == "HandIn" && other.gameObject.transform.parent.GetComponent<GameController>().player == this.gameObject) {
            if (other.gameObject.GetComponent<HandInScript>().closed == false) {
                if (other.gameObject.GetComponent<HandInScript>().closing == false) {
                    other.gameObject.GetComponent<HandInScript>().HandleHandIn(balloonEnumInt);
                    Debug.Log("it wasnt closed or closing apparently");
                    objCarry = false;
                    pickUpImg.fillAmount = 0;
                    balloonEnumInt = 0;
                }
            }
        }
        if (other.gameObject.tag == "Player2" && frenzy || other.gameObject.tag == "Player1" && frenzy) {
          float angle;
          angle = Vector2.Angle(this.gameObject.transform.position, other.gameObject.transform.position);
          other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((Mathf.Sin(angle)),(Mathf.Cos(angle))) * 8, ForceMode2D.Impulse);
        }
    }
}
