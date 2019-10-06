using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {

    public float currentTime = 60f;
    private bool gameEnded =  true;
    private bool timeswap = true;
    public bool paused;
    public float TimeRatio;
    public float TotalTime = 60f;
    public GameObject countDownref;
    public GameObject canvaspausebutton;
    public GameObject tutorialRefrence;
    public BulletHellManage hellManage;

    //public GameObject minigameBackground;

    public Image ProgressBar;
    public Image ProgressBar2;

    // Use this for initialization
    void Start () {
        //Time.timeScale = 0;
        canvaspausebutton.SetActive(false);
    }

    public void closeTutorial () {
        tutorialRefrence.SetActive(false);
        countDownref.SetActive(true);
        StartCoroutine(Countdown());
    }

	// Update is called once per frame
	void Update () {
        //setting a basic two significant figures timer
        Scene scene = SceneManager.GetActiveScene();
        if (paused == false) {
            currentTime -= Time.deltaTime;

            TimeRatio = currentTime / TotalTime;
            //ProgressBar.fillAmount = TimeRatio;
            //ProgressBar2.fillAmount = TimeRatio;
        }

        if(scene.name == "BulletHell")
        {
            hellManage = GetComponent<BulletHellManage>();

            if(currentTime <= 33 && currentTime >= 30 && timeswap == true)
            {
                countDownref.SetActive(true);
            }

            if(currentTime <= 30 && timeswap == true)
            {
                countDownref.SetActive(false);
                hellManage.Bhell_Swap();
                //StartCoroutine(Countdown());
                timeswap = false;
                //This is where the 123 thing goes.
               

            }
        }
    }

    //countdown before game begins
    public IEnumerator Countdown() {

        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 4f;

        while (Time.realtimeSinceStartup < pauseTime) {
            yield return 0;
        }

        Time.timeScale = 1;
        countDownref.SetActive(false);
        canvaspausebutton.SetActive(true);
    }
}
