using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_BulletHell : Score
{
    public BulletHellManage bulletHellManage;
    public GameObject pauseBulletHell;

    public Image ProgressBar;
    public Image ProgressBar2;
    private bool timeswap = true;
    public float TimeRatio;
    public float TotalTime;
    public GameObject countDownref;
    public GameObject canvaspausebutton;


    // Start is called before the first frame update
    protected override void Start() {
        currentTime = 64;
        TotalTime = currentTime;
    }

    public void closeTutorial () {

        countDownref.SetActive(true);
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown() {

        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 4f;

        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }

        Time.timeScale = 1;
        countDownref.SetActive(false);
        paused = false;
        canvaspausebutton.SetActive(true);
    }

    // Update is called once per frame
    protected override void Update() {

        if (!paused) {
            currentTime -= Time.deltaTime;

            TimeRatio = currentTime / TotalTime;
            ProgressBar.fillAmount = TimeRatio;
            ProgressBar2.fillAmount = TimeRatio;
        }

        bulletHellManage = GameObject.FindObjectOfType<BulletHellManage>();

        if(currentTime <= 33 && currentTime >= 30 && timeswap == true)
        {
            countDownref.SetActive(true);
        }

        if(currentTime <= 30 && timeswap == true)
        {
            countDownref.SetActive(false);
            bulletHellManage.Bhell_Swap();
            //StartCoroutine(Countdown());
            timeswap = false;
            //This is where the 123 thing goes.


        }







        if (currentTime <= 0f && gameCanEnd) {
            scoreTextbox.SetActive(true);

            if (bulletHellManage.GetComponent<BulletHellManage>().p1TimesHit < bulletHellManage.GetComponent<BulletHellManage>().p2TimesHit) {
                if (CharacterCarryOver.player1 == "Bo") {
                    p1WinBo.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Hiro") {
                    p1WinHiro.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Mika") {
                    p1WinMika.SetActive(true);
                }

                if (CharacterCarryOver.player2 == "Bo") {
                    p2Bo.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Hiro") {
                    p2Hiro.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Mika") {
                    p2Mika.SetActive(true);
                }

                PlayerController.p1Score++;
                p1Wins[PlayerController.p1Score - 1] = "BalloonBattle";

            } else if (bulletHellManage.GetComponent<BulletHellManage>().p1TimesHit > bulletHellManage.GetComponent<BulletHellManage>().p2TimesHit) {
                if (CharacterCarryOver.player2 == "Bo") {
                    p2WinBo.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Hiro") {
                    p2WinHiro.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Mika") {
                    p2WinMika.SetActive(true);
                }

                if (CharacterCarryOver.player1 == "Bo") {
                    p1Bo.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Hiro") {
                    p1Hiro.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Mika") {
                    p1Mika.SetActive(true);
                }

                PlayerController.p2Score++;
                p2Wins[PlayerController.p2Score - 1] = "BalloonBattle";

            } else {
                if (CharacterCarryOver.player1 == "Bo") {
                    p1WinBo.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Hiro") {
                    p1WinHiro.SetActive(true);
                } else if (CharacterCarryOver.player1 == "Mika") {
                    p1WinMika.SetActive(true);
                }

                if (CharacterCarryOver.player2 == "Bo") {
                    p2WinBo.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Hiro") {
                    p2WinHiro.SetActive(true);
                } else if (CharacterCarryOver.player2 == "Mika") {
                    p2WinMika.SetActive(true);
                }

                PlayerController.p1Score++;
                PlayerController.p2Score++;
                p1Wins[PlayerController.p1Score - 1] = "BalloonBattle";
                p2Wins[PlayerController.p2Score - 1] = "BalloonBattle";

            }

            for (int i = 0; i < PlayerController.p1Score; i++) {
                if (p1Wins[i] == "WaterWars") {
                    p1Tokens[i].SetActive(true);
                    p1Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/WaterWarsToken");
                } else if (p1Wins[i] == "FillingFrenzy") {
                    p1Tokens[i].SetActive(true);
                    p1Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/FillingFrenzyToken");
                } else if (p1Wins[i] == "BalloonBattle") {
                    p1Tokens[i].SetActive(true);
                    p1Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/BalloonBattleToken");
                }
            }

            for (int i = 0; i < PlayerController.p2Score; i++) {
                if (p2Wins[i] == "WaterWars") {
                    p2Tokens[i].SetActive(true);
                    p2Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/WaterWarsToken");
                } else if (p2Wins[i] == "FillingFrenzy") {
                    p2Tokens[i].SetActive(true);
                    p2Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/FillingFrenzyToken");
                } else if (p2Wins[i] == "BalloonBattle") {
                    p2Tokens[i].SetActive(true);
                    p2Tokens[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Tokens/BalloonBattleToken");
                }
            }

            p1Score.GetComponent<Text>().text = PlayerController.p1Score.ToString();
            p2Score.GetComponent<Text>().text = PlayerController.p2Score.ToString();

            canvaspausebutton.SetActive(false);
            pauseBulletHell.GetComponent<Pause_BulletHell>().paused = false;
            pauseBulletHell.GetComponent<Pause_BulletHell>().PauseButton();

            gameCanEnd = false;

        }
    }

}
