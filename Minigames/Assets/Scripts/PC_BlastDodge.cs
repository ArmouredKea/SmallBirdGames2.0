using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_BlastDodge : PlayerController
{

    private int points;

    private float timer;
    private float stunTime = 1f;
    private bool stunned;
    public GameObject currency;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        speed = 7f;
        rotationSpeed = 100.0f;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
        if (stunned) {
            speed = 0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            timer += Time.deltaTime;
            if (timer >= stunTime) {
                stunned = false;
                speed = 7f;
                timer = 0;
            }
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

    public void HandlePoints(int tempPoints, GameObject tempGO) {
        if (tempGO.tag == "PickUp") {
            points += tempPoints;
            Debug.Log("Points after pick up : " + points);
        }
        if (tempGO.tag == "Blast") {
            points -= tempPoints;
            if (points <= -1) {
                points = 0;
            }
            Debug.Log("Points after hit : " + points);
        }
    }

    public void HandleHit(int spawnInt) {
        //Stun Player
        stunned = true;

        //Drop Currency
        if (points >= 1) {
            for (int i = 0; i <= spawnInt; i++) {
                if (i >= spawnInt +1) {
                    break;
                }
                int randomInt;
                randomInt = Random.Range(0, 4);
                if (randomInt == 0) {
                    //North
                } else if (randomInt == 1) {
                    //East
                } else if (randomInt == 2) {
                    //South
                } else {
                    //West
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PickUp") {
            HandlePoints(1, other.gameObject);
            Destroy(other.gameObject);
        }
        // if (other.gameObject.tag == "Blast") {
        //     HandlePoints(4, other.gameObject);
        //     HandleHit(4);
        // }
    }
    void OnParticleCollision(GameObject other) {
        Debug.Log(other);
        //HandlePoints(4, other.gameObject);
        HandleHit(4);
    }
}
