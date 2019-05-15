using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{

    private float speed = 3.0f;

    // Use this for initialization
    void Start() {

        //gives bomb a random velocity.
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), 1) * speed;

    }

    // Update is called once per frame
    void Update() {

        speed = Random.Range(1f, 3f);

    }

    //checking what the bomb is colliding with and
    //respawns another bomb while taking away one life from the specific player.
    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Bombs") {
            StartCoroutine(BombDelay(1f));
        }

        if (collision.gameObject.tag == "Player1") {
            Destroy(gameObject);
            GameObject.Find("Background").GetComponent<BombSchtuff>().SpawnBomb();
            GameObject.Find("Background").GetComponent<BombSchtuff>().p1Lives--;
        } else if (collision.gameObject.tag == "Player2") {
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

}
