using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC_Overcooked : PlayerController {

    public GameObject pickedUpObj;
    public string pName;

    public GameObject frenzyI;

    public GameObject audioManager;

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
    public bool handInPlease;
    public float castTime;
    public float hCastTime;
    private float endCastTime = 0.5f;

    public int balloonEnumInt;
    public Image pickUpImg;

    public bool frenzy;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        speed = 6f;
        rotationSpeed = 100.0f;
        baseSpeedOC = speed;
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
        //pick up cast time timer and logic
        if (inRange && objCarry == false) {
          castTime += Time.deltaTime;
          pickUpImg.fillAmount = (castTime/endCastTime);
          if (castTime >= endCastTime) {
              audioManager.GetComponent<AudioManagerScript>().PlayAudio("Whoosh");
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
        }
    }

    //Referencing gameObject (PickUp) that you are near
    void OnTriggerEnter2D(Collider2D other) {

        //checks if you are near a crate and starts pick up timer
        if (other.gameObject.tag == "Crate") {
            if (objCarry == false) {
                inRange = true;
                castTime = 0f;
                pickUpImg.color = other.gameObject.GetComponent<Dispenser>().dColor;
                balloonEnumInt = other.gameObject.GetComponent<Dispenser>().dBalloonEnumInt;
            }
        }
    }

    //checks if you exit a crate area
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
        //checks if you collide with a bin and "throws away" the balloon if you are holding one
        if (other.gameObject.tag == "Bin") {
            handInPlease = true;
            if (objCarry) {
                objCarry = false;
                pickUpImg.fillAmount = 0;
                balloonEnumInt = 0;
                audioManager.GetComponent<AudioManagerScript>().PlayAudio("Whoosh");
            }
        }
        //checks if you collide with a hand in and starts the logic for handing in the object
        if (other.gameObject.tag == "HandIn" && other.gameObject.transform.parent.GetComponent<GameController>().player == this.gameObject) {
            //checks if box is closed or closing
            if (other.gameObject.GetComponent<HandInScript>().closed == false) {
                if (other.gameObject.GetComponent<HandInScript>().closing == false) {
                    //checks if you are carrying a balloon
                    if (objCarry) {
                        other.gameObject.GetComponent<HandInScript>().HandleHandIn(balloonEnumInt);
                        Debug.Log("it wasnt closed or closing apparently");
                        objCarry = false;
                        pickUpImg.fillAmount = 0;
                        balloonEnumInt = 0;
                        audioManager.GetComponent<AudioManagerScript>().PlayAudio("Whoosh");
                        audioManager.GetComponent<AudioManagerScript>().PlayAudio("Crate2");
                    }
                }
            }
        }
    }
}
