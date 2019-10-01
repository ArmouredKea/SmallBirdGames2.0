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

    // Start is called before the first frame update
    protected virtual void Start() {

    }

    // Update is called once per frame
    protected virtual void Update() {
        if (!paused) {
            currentTime -= Time.deltaTime;
        }
    }

    protected virtual void FixedUpdate() {

    }
}
