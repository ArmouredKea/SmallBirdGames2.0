using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Overcooked : PlayerController {

    public GameObject pickedUpObj;

    //controls axis
    public float vertMovement;
    public float horiMovement;
    public float pickUpC;
    public bool puAxisInUse;
    public bool oButtonPressed;

    //obj picked up bool
    public bool inRange;
    public bool objCarry;

    public string balloonName;

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
        } else {
            animator.SetBool("Moving", true);
            GetComponent<Animator>().speed = 1;
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

        if (other.gameObject.tag == "Crate") {
            if (objCarry == false) {
                inRange = true;
                balloonName = other.gameObject.GetComponent<Dispenser>().dBalloonName;
                objCarry = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Bin") {
          objCarry = false;
          balloonName = "";
        }
    }
}
