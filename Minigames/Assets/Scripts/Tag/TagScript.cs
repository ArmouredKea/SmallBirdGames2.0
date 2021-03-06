﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagScript : MonoBehaviour
{

    public bool tagged = false;
    public bool it = false;
    public GameObject tagIcon;
    public GameObject pointLight;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        //gives the tag icon to the person who is it and resets spotlight radius
        if (it) {
            tagIcon.SetActive(true);
            pointLight.GetComponent<Light>().spotAngle = 60;
        } else if (it == false) {
            tagIcon.SetActive(false);
            pointLight.GetComponent<Light>().spotAngle = 40;
        }

        if (tagged) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

    }

    //checks when player is tagged to switch roles
    public void OnCollisionEnter2D(Collision2D collision) {

        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") && it == false) {
            tagged = true;
            it = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<PlayerController>().speed = 0;
            if (gameObject.tag == "Player1") {
                GameObject.Find("LeftIJ").GetComponent<PlayerController>().speed = 0;
            } else if (gameObject.tag == "Player2") {
                GameObject.Find("RightIJ").GetComponent<PlayerController>().speed = 0;
            }
                StartCoroutine(TagDelay(2f));
        } else if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") && it == true) {
            it = false;
        }

    }

    //freezes the person who gets tagged
    private IEnumerator TagDelay(float waitTime) {

        yield return new WaitForSeconds(waitTime);
        tagged = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<PlayerController>().speed = 7;
        GameObject.Find("LeftIJ").GetComponent<PlayerController>().speed = 7;
        GameObject.Find("RightIJ").GetComponent<PlayerController>().speed = 7;

    }
}
