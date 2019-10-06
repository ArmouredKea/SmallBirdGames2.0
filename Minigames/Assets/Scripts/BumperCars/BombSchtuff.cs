using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombSchtuff : MonoBehaviour {

    public Transform bomb;
    public Transform exclamation;
    private float timer = 10.0f;
    private int k = 0;

    public int p1Lives = 3;
    public int p2Lives = 3;
    public GameObject p1H1Bo;
    public GameObject p1H2Bo;
    public GameObject p1H3Bo;
    public GameObject p1H1Hiro;
    public GameObject p1H2Hiro;
    public GameObject p1H3Hiro;
    public GameObject p1H1Mika;
    public GameObject p1H2Mika;
    public GameObject p1H3Mika;
    public GameObject p2H1Bo;
    public GameObject p2H2Bo;
    public GameObject p2H3Bo;
    public GameObject p2H1Hiro;
    public GameObject p2H2Hiro;
    public GameObject p2H3Hiro;
    public GameObject p2H1Mika;
    public GameObject p2H2Mika;
    public GameObject p2H3Mika;
    
    public bool paused;
    private GameObject pauseParent;

    // Use this for initialization
    void Start () {
        pauseParent = GameObject.Find("Pause");
        //StartCoroutine(SpawnBomb(1.5f));
        //spawningBomb = true;

        if (CharacterCarryOver.player1 == "Bo") {
            p1H1Bo.SetActive(true);
            p1H2Bo.SetActive(true);
            p1H3Bo.SetActive(true);
        } else if (CharacterCarryOver.player1 == "Hiro") {
            p1H1Hiro.SetActive(true);
            p1H2Hiro.SetActive(true);
            p1H3Hiro.SetActive(true);
        } else if (CharacterCarryOver.player1 == "Mika") {
            p1H1Mika.SetActive(true);
            p1H2Mika.SetActive(true);
            p1H3Mika.SetActive(true);
        }

        if (CharacterCarryOver.player2 == "Bo") {
            p2H1Bo.SetActive(true);
            p2H2Bo.SetActive(true);
            p2H3Bo.SetActive(true);
        } else if (CharacterCarryOver.player2 == "Hiro") {
            p2H1Hiro.SetActive(true);
            p2H2Hiro.SetActive(true);
            p2H3Hiro.SetActive(true);
        } else if (CharacterCarryOver.player2 == "Mika") {
            p2H1Mika.SetActive(true);
            p2H2Mika.SetActive(true);
            p2H3Mika.SetActive(true);
        }

    }

	// Update is called once per frame
	void Update () {

        //timer countdown for spawning bombs.
        if (paused == false) {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f) {
            if (k <= 5) {
                StartCoroutine(SpawnBomb(1.5f));
                k++;
                timer = 10.0f - k;
            }
        }

        //player 1 lives
        if (CharacterCarryOver.player1 == "Bo") {
            if (p1Lives == 2) {
                p1H3Bo.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p1Lives == 1) {
                p1H2Bo.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p1Lives <= 0) {
                p1H1Bo.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            }
        } else if (CharacterCarryOver.player1 == "Hiro") {
            if (p1Lives == 2) {
                p1H3Hiro.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p1Lives == 1) {
                p1H2Hiro.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p1Lives <= 0) {
                p1H1Hiro.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            }
        } else if (CharacterCarryOver.player1 == "Mika") {
            if (p1Lives == 2) {
                p1H3Mika.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p1Lives == 1) {
                p1H2Mika.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p1Lives <= 0) {
                p1H1Mika.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            }
        }


        //player 2 lives
        if (CharacterCarryOver.player2 == "Bo") {
            if (p2Lives == 2) {
                p2H3Bo.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p2Lives == 1) {
                p2H2Bo.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p2Lives <= 0) {
                p2H1Bo.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            }
        } else if (CharacterCarryOver.player2 == "Hiro") {
            if (p2Lives == 2) {
                p2H3Hiro.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p2Lives == 1) {
                p2H2Hiro.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p2Lives <= 0) {
                p2H1Hiro.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            }
        } else if (CharacterCarryOver.player2 == "Mika") {
            if (p2Lives == 2) {
                p2H3Mika.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p2Lives == 1) {
                p2H2Mika.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            } else if (p2Lives <= 0) {
                p2H1Mika.GetComponent<Image>().color = new Color(0, 0, 0, 1);
            }
        }
    }

    //spawns a bomb at a random position either at the top or bottom of the arena.
    public IEnumerator SpawnBomb(float waitTime) {
        float i = Random.Range(0f, 0.9f);
        float j;
        float m = Random.Range(-3.5f, 3.5f);

        if (i < 0.5f) {
            j = 3.5f;
        } else {
            j = -4.1f;
        }

        Instantiate(exclamation, new Vector2(m, j), Quaternion.identity).transform.SetParent(pauseParent.transform, true);

        float l = 0;
        while (l < waitTime) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                yield return null;
            }
        }

        Instantiate(bomb, new Vector2(m, j), Quaternion.identity).transform.SetParent(pauseParent.transform, true);

    }

}
