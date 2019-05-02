using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombSchtuff : MonoBehaviour {

    public Transform bomb;
    private float timer = 10.0f;
    private int k = 0;

    public int p1Lives = 3;
    public int p2Lives = 3;
    public GameObject p1H1;
    public GameObject p1H2;
    public GameObject p1H3;
    public GameObject p2H1;
    public GameObject p2H2;
    public GameObject p2H3;
    public GameObject endText;

    // Use this for initialization
    void Start () {
        SpawnBomb();
    }
	
	// Update is called once per frame
	void Update () {

        //timer countdown for spawning bombs.
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            if (k <= 5) {
                SpawnBomb();
                k++;
                timer = 10.0f - k;
            }
        }

        //player 1 lives
        if (p1Lives == 2) {
            p1H3.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        } else if (p1Lives == 1) {
            p1H2.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        } else if (p1Lives <= 0) {
            p1H1.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            endText.SetActive(true);
            endText.GetComponent<Text>().text = "Player 2 Wins!";
            Time.timeScale = 0;
        }

        //player 2 lives
        if (p2Lives == 2) {
            p2H3.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        }
        else if (p2Lives == 1) {
            p2H2.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        }
        else if (p2Lives <= 0) {
            p2H1.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            endText.SetActive(true);
            endText.GetComponent<Text>().text = "Player 1 Wins!";
            Time.timeScale = 0;
        }
    }

    //spawns a bomb at a random position either at the top or bottom of the arena.
    public void SpawnBomb() {
        float j;
        float i = Random.Range(0f, 0.9f);

        if (i < 0.5f) {
            j = 4.5f;
        } else {
            j = -4.5f;
        }

        Instantiate(bomb, new Vector2(Random.Range(-6, 6), j), Quaternion.identity);

    }
}
