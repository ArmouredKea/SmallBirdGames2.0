using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {



    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {



    }


    //JoystickControls

    /*if (Input.touchCount > 0) {
        //Debug.Log("Touch Detected");
        for (int i = 0; i<Input.touchCount; i++) {
            Touch touch = Input.GetTouch(i);

            // Handle finger movements based on TouchPhase
            switch (touch.phase) {
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

                    direction = (Vector2) Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position) - startPos;
                    direction = (Vector2) Vector3.Normalize(direction);
Debug.Log("Moving " + direction);
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    isMoving = false;
                    Debug.Log("Ending " + (Vector2) Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position));

                    break;
            }
        }
    }*/





}