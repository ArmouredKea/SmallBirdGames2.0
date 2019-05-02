using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{

  public float speed;
  public float rotationSpeed;
  public GameObject pickedUpObj;

  //controls axis
  private float vertMovement;
  private float horiMovement;
  private float pickUpC;
  private bool puAxisInUse;

  //obj picked up bool
  public bool inRange;
  public bool objCarry;


  //JoystickControls Variables
  public int joystickRadius = 2;
  public float threshold = 0.1f;
  private Vector2 startPos;
  private Vector2 direction;
  private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      Movement();

      if (objCarry)
      {
        pickedUpObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, pickedUpObj.transform.position.z);
      }

    }


//Splitting Controls between both players to only have 1 script
    void Controls() {

      if (gameObject.name == "Player1")
      {
        vertMovement = Input.GetAxis("Vertical1");
        horiMovement = Input.GetAxis("Horizontal1");
        pickUpC = Input.GetAxis("PickUp1");
      }
      if (gameObject.name == "Player2")
      {
        vertMovement = Input.GetAxis("Vertical");
        horiMovement = Input.GetAxis("Horizontal");
        pickUpC = Input.GetAxis("PickUp");
      }

      //single action axes rather than on loop
      if (pickUpC != 0)
      {
        if (puAxisInUse == false)
        {
          PickUpObj();
          puAxisInUse = true;
        }
      }
      if (pickUpC == 0)
      {
        puAxisInUse = false;
      }

      //JoystickControls
      if (Input.touchCount > 0)
      {
        //Debug.Log("Touch Detected");
        for (int i = 0; i < Input.touchCount; i++)
        {
          Touch touch = Input.GetTouch(i);

          // Handle finger movements based on TouchPhase
          switch (touch.phase)
          {
              //When a touch has first been detected, change the message and record the starting position
              case TouchPhase.Began:
                  // Record initial touch position.
                  // if (direction.x >= threshold || direction.y >= threshold)
                  // {
                    isMoving = true;
                  // }
                  startPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                  Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                  Debug.Log("Begun " + startPos);
                  break;

              //Determine if the touch is a moving touch
              case TouchPhase.Moved:
                  // Determine direction by comparing the current touch position with the initial one

                  direction = (Vector2)Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position) - startPos;
                  direction = (Vector2)Vector3.Normalize(direction);
                  Debug.Log("Moving " + direction);
                  break;

              case TouchPhase.Ended:
                  // Report that the touch has ended when it ends
                  isMoving = false;
                  Debug.Log("Ending " + (Vector2)Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position));

                  break;
          }
        }
      }

    }

//Movement Function
    void Movement()
    {

      Controls();

      float moveY = 0f;
      float moveX = 0f;

      moveY = vertMovement * speed;
      moveX = horiMovement  * rotationSpeed;

      moveX *= Time.deltaTime;
      moveY *= Time.deltaTime;

      transform.Translate(0, moveY, 0);
      transform.Translate(moveX, 0, 0);
      if (isMoving)
      {
        transform.Translate((direction * speed * Time.deltaTime));
      }

    }


//Referencing gameObject (PickUp) that you are near
    void OnTriggerStay2D(Collider2D other)
    {
      if (other.tag == "PickUp" || other.tag == "PickUp1")
      {
        if (objCarry == false)
        {
          inRange = true;
          pickedUpObj = other.gameObject;
        }
      }
    }

//Resetting on drop and collider exit
    void OnTriggerExit2D(Collider2D other)
    {
      if (other.tag == "PickUp" || other.tag == "PickUp1")
      {
        if (objCarry == false)
        {
          inRange = false;
          pickedUpObj = null;
        }
      }
    }

//To Pick up and Drop Objects
    void PickUpObj()
    {
      if (pickUpC != 0 && inRange && objCarry == false)
      {
        objCarry = true;
      }
      else if (pickUpC != 0 && objCarry == true)
      {
        objCarry = false;
      }
    }
}
