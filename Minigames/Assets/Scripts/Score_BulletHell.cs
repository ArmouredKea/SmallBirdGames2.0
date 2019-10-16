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
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    public void closeTutorial () {

        countDownref.SetActive(true);
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown() {

        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 4f;
        int i = 0;
        while (Time.realtimeSinceStartup < pauseTime) {
            if (i == 0 && (pauseTime - Time.realtimeSinceStartup > 3) && (pauseTime - Time.realtimeSinceStartup < 4)) {
                audioManager.GetComponent<AudioManagerScript>().PlayAudio("Button");
                i++;
            } else if (i == 1 && (pauseTime - Time.realtimeSinceStartup > 2) && (pauseTime - Time.realtimeSinceStartup < 3)) {
                audioManager.GetComponent<AudioManagerScript>().PlayAudio("Button");
                i++;
            } else if (i == 2 && (pauseTime - Time.realtimeSinceStartup > 1) && (pauseTime - Time.realtimeSinceStartup < 2)) {
                audioManager.GetComponent<AudioManagerScript>().PlayAudio("Button");
                i++;
            } else if (i == 3 && (pauseTime - Time.realtimeSinceStartup > 0) && (pauseTime - Time.realtimeSinceStartup < 1)) {
                audioManager.GetComponent<AudioManagerScript>().PlayAudio("Button");
                i++;
            }
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

            base.TokensUpdate();

            if (bulletHellManage.GetComponent<BulletHellManage>().p1TimesHit < bulletHellManage.GetComponent<BulletHellManage>().p2TimesHit) {
                p1Tokens[PlayerController.p1Score - 1].GetComponent<Animator>().enabled = true;
                p1Tokens[PlayerController.p1Score - 1].GetComponent<Animator>().SetBool("Spin", true);
            } else if (bulletHellManage.GetComponent<BulletHellManage>().p1TimesHit < bulletHellManage.GetComponent<BulletHellManage>().p2TimesHit) {
                p2Tokens[PlayerController.p2Score - 1].GetComponent<Animator>().enabled = true;
                p2Tokens[PlayerController.p2Score - 1].GetComponent<Animator>().SetBool("Spin", true);
            } else {
                p1Tokens[PlayerController.p1Score - 1].GetComponent<Animator>().enabled = true;
                p2Tokens[PlayerController.p2Score - 1].GetComponent<Animator>().enabled = true;
                p1Tokens[PlayerController.p1Score - 1].GetComponent<Animator>().SetBool("Spin", true);
                p2Tokens[PlayerController.p2Score - 1].GetComponent<Animator>().SetBool("Spin", true);
            }
            StartCoroutine(TokenSound(0.9f));

            p1Score.GetComponent<Text>().text = PlayerController.p1Score.ToString();
            p2Score.GetComponent<Text>().text = PlayerController.p2Score.ToString();

            canvaspausebutton.SetActive(false);
            pauseBulletHell.GetComponent<Pause_BulletHell>().paused = false;
            pauseBulletHell.GetComponent<Pause_BulletHell>().PauseButton();

            gameCanEnd = false;

        }
    }

}
