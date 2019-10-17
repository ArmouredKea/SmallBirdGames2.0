using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject p1Bo;
    public GameObject p1Hiro;
    public GameObject p1Mika;
    public GameObject p2Bo;
    public GameObject p2Hiro;
    public GameObject p2Mika;
    public GameObject p1WinBo;
    public GameObject p1WinHiro;
    public GameObject p1WinMika;
    public GameObject p2WinBo;
    public GameObject p2WinHiro;
    public GameObject p2WinMika;
    public GameObject p1Score;
    public GameObject p2Score;
    public GameObject scoreTextbox;
    public GameObject pauseButton;

    public float currentTime = 60f;
    public bool paused;
    public bool gameCanEnd = true;

    public static string[] p1Wins = { "", "", "", "", "", "", "", "", "" };
    public static string[] p2Wins = { "", "", "", "", "", "", "", "", "" };
    public GameObject[] p1Tokens;
    public GameObject[] p2Tokens;

    public GameObject audioManager;

    public Image ProgressBar;
    public Image ProgressBar2;
    public float TimeRatio;

    // Start is called before the first frame update
    protected virtual void Start() {
        
    }

    // Update is called once per frame
    protected virtual void Update() {
        if (!paused) {
            currentTime -= Time.deltaTime;
            TimeRatio = currentTime / 60;
            ProgressBar.fillAmount = TimeRatio;
            ProgressBar2.fillAmount = TimeRatio;
        }
    }

    protected virtual void FixedUpdate() {

    }

    protected virtual void TokensUpdate() {
        for (int i = 0; i < CharacterCarryOver.p1Score; i++) {
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

        for (int i = 0; i < CharacterCarryOver.p2Score; i++) {
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
    }

    protected virtual IEnumerator TokenSound(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        audioManager.GetComponent<AudioManagerScript>().PlayAudio("Coin");
    }
}
