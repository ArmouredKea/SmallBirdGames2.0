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

    public bool paused;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        speed = 7f;
        rotationSpeed = 100.0f;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
    }

    protected override void FixedUpdate() {
        if (!paused) {
            base.FixedUpdate();
            Movement();
            if (objCarry) {
                pickedUpObj.GetComponent<ItemController>().LastHeldBy(gameObject);
                pickedUpObj.GetComponent<ItemController>().held = true;
                pickedUpObj.GetComponent<ItemController>().overfill = false;
                pickedUpObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, pickedUpObj.transform.position.z);
            }
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

        if (gameObject.name == "Player1") {
            vertMovement = Input.GetAxis("Vertical");
            horiMovement = Input.GetAxis("Horizontal");
            pickUpC = Input.GetAxis("PickUp");
        }
        if (gameObject.name == "Player2") {
            vertMovement = Input.GetAxis("Vertical1");
            horiMovement = Input.GetAxis("Horizontal1");
            pickUpC = Input.GetAxis("PickUp1");
        }

        //single action axes rather than on loop
        if (pickUpC != 0) {
            if (puAxisInUse == false) {
                PickUpObj();
                puAxisInUse = true;
            }
        }
        if (pickUpC == 0) {
            puAxisInUse = false;
        }

    }

    //To Pick up and Drop Objects
    public void PickUpObj() {
        if (pickUpC != 0 && inRange && objCarry == false && pickedUpObj.GetComponent<ItemController>().filling == false) {
            objCarry = true;
        } else if (pickUpC != 0 && objCarry == true) {
            pickedUpObj.GetComponent<ItemController>().held = false;
            objCarry = false;
        }
    }
    public void PickUpObj2() {
        if (inRange && objCarry == false) {
            objCarry = true;

        } else if (objCarry == true) {
            pickedUpObj.GetComponent<ItemController>().held = false;
            objCarry = false;
        }
    }

    //Referencing gameObject (PickUp) that you are near
    void OnTriggerStay2D(Collider2D other) {

        if (other.tag == "PickUp") {
            if (objCarry == false) {
                inRange = true;
                pickedUpObj = other.gameObject;
            }
        }

    }

    //Resetting on drop and collider exit
    void OnTriggerExit2D(Collider2D other) {

        if (other.tag == "PickUp") {
            if (objCarry == false) {
                inRange = false;
                pickedUpObj = null;
            }
        }

    }
}
