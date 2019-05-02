using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

    private float currentTime = 60f;
    public Text p1Time;
    public Text p2Time;
    public GameObject endText;
    //public GameObject countdown;

    // Use this for initialization
    void Start () {
        StartCoroutine(Countdown());
    }
	
	// Update is called once per frame
	void Update () {
        //setting a basic two significant figures timer
        currentTime -= Time.deltaTime;
        p1Time.text = "Time: " + currentTime.ToString("00");
        p2Time.text = "Time: " + currentTime.ToString("00");

        //check number of lives for each player when timer reaches 0
        if (currentTime <= 0f) {

            if (GameObject.Find("Background").GetComponent<BombSchtuff>().p1Lives > GameObject.Find("Background").GetComponent<BombSchtuff>().p1Lives) {
                endText.SetActive(true);
                endText.GetComponent<Text>().text = "Player 1 Wins!";
                Time.timeScale = 0;
            } else if (GameObject.Find("Background").GetComponent<BombSchtuff>().p1Lives < GameObject.Find("Background").GetComponent<BombSchtuff>().p1Lives) {
                endText.SetActive(true);
                endText.GetComponent<Text>().text = "Player 2 Wins!";
                Time.timeScale = 0;
            } else {
                endText.SetActive(true);
                endText.GetComponent<Text>().text = "Draw!";
                Time.timeScale = 0;
            }

        }

    }

    //countdown before game begins
    private IEnumerator Countdown() {     
        
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        //countdown.SetActive(true);

        while (Time.realtimeSinceStartup < pauseTime) {
            yield return 0;
        }

        Time.timeScale = 1;
    }
}
