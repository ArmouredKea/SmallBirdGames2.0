using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_BumperCars : PlayerController {

    public Vector2 currentPosition;
    public float totalDistance;
    public bool boosted;

    public Vector3 pauseVelocity;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        speed = 7f;
        rotationSpeed = 100.0f;
        totalDistance = 0f;
        currentPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
        //calculates distance travelled.
        float distance = Vector2.Distance(currentPosition, gameObject.transform.position);
        totalDistance += distance;
        currentPosition = gameObject.transform.position;

        //player boost.
        if (totalDistance >= 50f) {
            boosted = true;
            speed = 15f;
            //gameObject.GetComponent<Rigidbody2D>().mass = 1.5f;

            if (gameObject.tag == "Player1") {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
            } else if (gameObject.tag == "Player2") {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
            }

            StartCoroutine(BoostDuration(5f));
        }
        
        if (Input.GetKeyDown(KeyCode.P)) {
            PauseCharacter();
        } else if (Input.GetKeyDown(KeyCode.U)) {
            UnpauseCharacter();
        }

    }

    protected override void FixedUpdate() {
        base.FixedUpdate();
        //Player forward/backward movement and rotation.
        if (paused) {
            return;
        } else {
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
    }

    protected override void MoveCharacter(Vector2 direction) {
        base.MoveCharacter(direction);
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * speed * 2);
    }

    //player boost duration.
    private IEnumerator BoostDuration(float waitTime) {
        yield return new WaitForSeconds(waitTime);

        if (gameObject.tag == "Player1") {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        } else if (gameObject.tag == "Player2") {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.6f, 0.2f, 1);
        }

        speed = 7f;
        //gameObject.GetComponent<Rigidbody2D>().mass = 1;
        totalDistance = 0f;
        boosted = false;
    }

    public void PauseCharacter() {
        //pauseForce = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        paused = true;
        pauseVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void UnpauseCharacter() {
        gameObject.GetComponent<Rigidbody2D>().velocity = pauseVelocity;
        paused = false;
    }
}
