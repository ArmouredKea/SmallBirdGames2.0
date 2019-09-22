using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    public GameObject tutorial;
    public GameObject minigameUI;
    public GameObject minigameSchtuff;
    public GameObject countdown;
    public GameObject countdownTimer;

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
        Time.timeScale = 1;        
        yield return new WaitForSeconds(waitTime);
        minigameUI.SetActive(true);
        minigameSchtuff.SetActive(true);
        gameObject.GetComponent<Animator>().SetBool("ZoomIn", false);
        countdownTimer.SetActive(true);

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "BumperCarsMG" || scene.name == "BulletHell") {
            StartCoroutine(countdown.GetComponent<CountdownTimer>().Countdown());
        } else if (scene.name == "OvercookedMG") {
            StartCoroutine(countdown.GetComponent<Pause_Overcooked>().Countdown());
        }
               
    }
}
