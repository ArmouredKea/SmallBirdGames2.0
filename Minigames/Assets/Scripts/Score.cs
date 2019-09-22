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
    public GameObject p1Score0;
    public GameObject p1Score1;
    public GameObject p1Score2;
    public GameObject p1Score3;
    public GameObject p2Score0;
    public GameObject p2Score1;
    public GameObject p2Score2;
    public GameObject p2Score3;
    public GameObject winBo;
    public GameObject winHiro;
    public GameObject winMika;
    public GameObject drawP1Bo;
    public GameObject drawP1Hiro;
    public GameObject drawP1Mika;
    public GameObject drawP2Bo;
    public GameObject drawP2Hiro;
    public GameObject drawP2Mika;
    public GameObject scoreTextbox;
    public GameObject pauseButton;

    public float currentTime = 60f;
    public bool paused;
    public bool gameCanEnd = true;

    // Start is called before the first frame update
    protected virtual void Start() {

    }

    // Update is called once per frame
    protected virtual void Update() {

    }
}
