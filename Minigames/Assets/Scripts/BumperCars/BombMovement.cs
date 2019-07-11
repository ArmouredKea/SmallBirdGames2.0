﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{

    private float speed = 3.0f;

    //REMINDER for invulnerability (not yet completed)
    private bool p1Invulnerable;
    private bool p2Invulnerable;

    // Use this for initialization
    void Start() {
        //gives bomb a random velocity.
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), 1) * speed;
    }

    // Update is called once per frame
    void Update() {
        speed = Random.Range(1f, 3f);
    }

    //checking what the bomb is colliding with.
    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Bombs") {
            StartCoroutine(BombDelay(1f));
        }

        if ((collision.gameObject.tag == "Player1") && (p1Invulnerable == false)) {
            p1Invulnerable = true;
            Destroy(gameObject);
            GameObject.Find("Background").GetComponent<BombSchtuff>().SpawnBomb();
            GameObject.Find("Background").GetComponent<BombSchtuff>().p1Lives--;
        } else if ((collision.gameObject.tag == "Player2")  && (p2Invulnerable == false)) {
            p2Invulnerable = true;
            Destroy(gameObject);
            GameObject.Find("Background").GetComponent<BombSchtuff>().SpawnBomb();
            GameObject.Find("Background").GetComponent<BombSchtuff>().p2Lives--;
        }

    }

    //bomb explosion and replacement.
    private IEnumerator BombDelay(float waitTime) {
        gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
        GameObject.Find("Background").GetComponent<BombSchtuff>().SpawnBomb();
    }

    private IEnumerator Vulnerability(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        GameObject.Find("Background").GetComponent<BombSchtuff>().SpawnBomb();
    }

}
