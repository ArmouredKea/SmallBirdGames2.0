using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {

    public float currentTime = 60f;
    public Text p1Time;
    public Text p2Time;
    public GameObject endText;
    public GameObject overallScore;
    public GameObject minigameChanger;
    private bool gameEnded =  true;
    private bool timeswap = true;

    // Use this for initialization
    void Start () {
        StartCoroutine(Countdown());
    }
	
	// Update is called once per frame
	void Update () {
        //setting a basic two significant figures timer
        Scene scene = SceneManager.GetActiveScene();
        currentTime -= Time.deltaTime;
        p1Time.text = "Time: " + currentTime.ToString("00");
        p2Time.text = "Time: " + currentTime.ToString("00");

        //check number of lives for each player when timer reaches 0
        if(scene.name == "BumperCarsMG") { 
            if ((currentTime <= 0f || GameObject.Find("Background").GetComponent<BombSchtuff>().p1Lives == 0 || GameObject.Find("Background").GetComponent<BombSchtuff>().p2Lives == 0) && (gameEnded == true)) {

                endText.SetActive(true);
                overallScore.SetActive(true);
                minigameChanger.SetActive(true);

                if (GameObject.Find("Background").GetComponent<BombSchtuff>().p1Lives > GameObject.Find("Background").GetComponent<BombSchtuff>().p2Lives) {
                    PlayerController.p1Score++;
                    endText.GetComponent<Text>().text = "Player 1 Wins!";
                
                } else if (GameObject.Find("Background").GetComponent<BombSchtuff>().p1Lives < GameObject.Find("Background").GetComponent<BombSchtuff>().p2Lives) {
                    PlayerController.p2Score++;
                    endText.GetComponent<Text>().text = "Player 2 Wins!";
                } else {
                    PlayerController.p1Score++;
                    PlayerController.p2Score++;
                    endText.GetComponent<Text>().text = "Draw!";
                }

                overallScore.GetComponent<Text>().text = "[P1] " + PlayerController.p1Score + " - " + PlayerController.p2Score + " [P2]";
                gameEnded = false;
                Time.timeScale = 0;

            }
        }
        if(scene.name == "BulletHell")
        {
            BulletHellManage hellManage = GetComponent<BulletHellManage>();

            if(currentTime <= 30 && timeswap == true)
            {
                hellManage.Bhell_Swap();
                StartCoroutine(Countdown());
                
                timeswap = false;
                
            }


            if ((currentTime <= 0f ) && (gameEnded == true))
            {

                endText.SetActive(true);
                overallScore.SetActive(true);
                minigameChanger.SetActive(true);

                if (hellManage.p1TimesHit < hellManage.p2TimesHit)
                {
                    PlayerController.p1Score++;
                    endText.GetComponent<Text>().text = "Player 1 Wins!";

                }
                else if (hellManage.p1TimesHit > hellManage.p2TimesHit)
                {
                    PlayerController.p2Score++;
                    endText.GetComponent<Text>().text = "Player 2 Wins!";
                }
                else
                {
                    PlayerController.p1Score++;
                    PlayerController.p2Score++;
                    endText.GetComponent<Text>().text = "Draw!";
                }

                overallScore.GetComponent<Text>().text = "[P1] " + PlayerController.p1Score + " - " + PlayerController.p2Score + " [P2]";
                gameEnded = false;
                Time.timeScale = 0;

            }
        }

    }

    //countdown before game begins
    private IEnumerator Countdown() {     
        
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;

        while (Time.realtimeSinceStartup < pauseTime) {
            yield return 0;
        }

        Time.timeScale = 1;
    }
}
