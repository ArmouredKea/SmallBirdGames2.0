using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{

    private float speed = 3.0f;

    public bool p1Invulnerable;
    public bool p2Invulnerable;

    public Vector2 pauseVelocity;
    public bool paused;
    public bool bombExplosion;


    // Use this for initialization
    void Start() {
        //gives bomb a random velocity.
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), 1) * speed;
        p1Invulnerable = false;
        p2Invulnerable = false;
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Physics2D.IgnoreLayerCollision(8, 10, false);
    }

    // Update is called once per frame
    void Update() {
        speed = Random.Range(1f, 3f);
    }

    //checking what the bomb is colliding with.
    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Bombs") {
            if (bombExplosion == false) {
                StartCoroutine(BombDelay(0.6f));
            }
            bombExplosion = true;
        }

        if ((collision.gameObject.tag == "Player1") && (p1Invulnerable == false)) {
            p1Invulnerable = true;
            StartCoroutine(BombDelay(0.6f));
            Physics2D.IgnoreLayerCollision(8, 9, true);
            StartCoroutine(Vulnerability1(2));
            collision.gameObject.GetComponent<PC_BumperCars>().TakeHit();
            StartCoroutine(GameObject.Find("BombSchtuff").GetComponent<BombSchtuff>().SpawnBomb(1.5f));
            GameObject.Find("BombSchtuff").GetComponent<BombSchtuff>().p1Lives--;
        } else if ((collision.gameObject.tag == "Player2")  && (p2Invulnerable == false)) {
            p2Invulnerable = true;
            StartCoroutine(BombDelay(0.6f));
            Physics2D.IgnoreLayerCollision(8, 10, true);
            StartCoroutine(Vulnerability2(2));
            collision.gameObject.GetComponent<PC_BumperCars>().TakeHit();
            StartCoroutine(GameObject.Find("BombSchtuff").GetComponent<BombSchtuff>().SpawnBomb(1.5f));
            GameObject.Find("BombSchtuff").GetComponent<BombSchtuff>().p2Lives--;
        }

    }

    //bomb explosion and replacement.
    private IEnumerator BombDelay(float waitTime) {
        //gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        gameObject.GetComponent<Animator>().SetBool("Explode", true);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        float l = 0;
        while (l < waitTime) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                yield return null;
            }
        }
        //Destroy(gameObject);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        bombExplosion = false;
        StartCoroutine(GameObject.Find("BombSchtuff").GetComponent<BombSchtuff>().SpawnBomb(1.5f));
    }

    //vulnerability delay for player 1.
    private IEnumerator Vulnerability1(float waitTime) {
        float l = 0;
        while (l < waitTime) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                yield return null;
            }
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    //vulnerability delay for player 2.
    private IEnumerator Vulnerability2(float waitTime) {
        float l = 0;
        while (l < waitTime) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                yield return null;
            }
        }
        Physics2D.IgnoreLayerCollision(8, 10, false);
    }

    //pauses bomb movement.
    public void PauseBomb() {
        pauseVelocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        paused = true;
    }

    //unpauses bomb movement.
    public void UnpauseBomb() {
        GetComponent<Rigidbody2D>().velocity = pauseVelocity;
        paused = false;
    }

}
