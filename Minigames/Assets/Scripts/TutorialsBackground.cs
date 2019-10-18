using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialsBackground : MonoBehaviour
{

    public GameObject outer;
    public GameObject inner;
    public GameObject title;
    public GameObject minigameUI;
    public GameObject minigameSchtuff;
    public GameObject pauseScript;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(TutorialAnimation(4f));
    }

    // Update is called once per frame
    void Update() {

    }

    //zooms in to the tutorial
    private IEnumerator TutorialAnimation(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        title.SetActive(false);
        outer.GetComponent<Animator>().SetBool("ZoomIn", true);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "BulletHell") {
            inner.GetComponent<Animator>().SetBool("ZoomInBH", true);
        } else {
            inner.GetComponent<Animator>().SetBool("ZoomIn", true);
        }
        StartCoroutine(TutorialUI(1.25f));
    }

    //displays the minigame for the tutorial
    private IEnumerator TutorialUI(float waitTIme) {
        yield return new WaitForSeconds(waitTIme);
        minigameUI.SetActive(true);
        minigameSchtuff.SetActive(true);
        pauseScript.GetComponent<Pause>().PauseButton();
        outer.GetComponent<Animator>().SetBool("ZoomIn", false);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "BulletHell") {
            inner.GetComponent<Animator>().SetBool("ZoomInBH", false);
        } else {
            inner.GetComponent<Animator>().SetBool("ZoomIn", false);
        }
    }
}
