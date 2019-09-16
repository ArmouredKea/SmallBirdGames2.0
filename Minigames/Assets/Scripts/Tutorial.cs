using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject tutorial;
    public GameObject minigameUI;
    public GameObject minigameSchtuff;
    public GameObject countdown;
    public GameObject countdownTimer;
    public GameObject bumperCarsPause;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Continue() {
        tutorial.SetActive(false);
        gameObject.GetComponent<Animator>().SetBool("ZoomIn", true);
        StartCoroutine(MinigameUIDelay(5f));
    }

    private IEnumerator MinigameUIDelay (float waitTime) {
        Debug.Log("Hello");
        //bumperCarsPause.GetComponent<Pause_BumperCars>().PauseButton();
        Time.timeScale = 1;        
        yield return new WaitForSeconds(waitTime);
        //bumperCarsPause.GetComponent<Pause_BumperCars>().PauseButton();
        minigameUI.SetActive(true);
        minigameSchtuff.SetActive(true);
        gameObject.GetComponent<Animator>().SetBool("ZoomIn", false);
        countdownTimer.SetActive(true);
        StartCoroutine(countdown.GetComponent<CountdownTimer>().Countdown());        
    }
}
