using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagGameplay : MonoBehaviour
{

    public float timer = 60f;
    public float spawnTimer = 8f;
    public GameObject p1Light;
    public GameObject p2Light;
    public GameObject winText;
    public GameObject walls1;
    public GameObject walls2;
    public GameObject walls3;
    public Transform powerup;
    public Transform trap;
    private float j;
    private float m;

    // Start is called before the first frame update
    void Start() {
        float i = Random.Range(0f, 0.9f);

        if (i < 0.45f) {
            GameObject.FindWithTag("Player1").GetComponent<PC_Tag>().it = true;
            p1Light.GetComponent<Light>().spotAngle = 60;
        } else {
            GameObject.FindWithTag("Player2").GetComponent<PC_Tag>().it = true;
            p2Light.GetComponent<Light>().spotAngle = 60;
        }

        if (i < 0.3f) {
            walls1.SetActive(true);
        } else if (i < 0.6f) {
            walls2.SetActive(true);
        } else if (i < 0.9f) {
            walls3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f) {
            SpawnPickup();
            spawnTimer = 8f;
        }

        if (timer <= 0) {
            winText.SetActive(true);
            if (GameObject.FindWithTag("Player1").GetComponent<PC_Tag>().it == true) {
                winText.GetComponent<Text>().text = "Player 2 Wins!";
            } else if (GameObject.FindWithTag("Player2").GetComponent<PC_Tag>().it == true) {
                winText.GetComponent<Text>().text = "Player 1 Wins!";
            }
            Time.timeScale = 0;
        }
    }

    //spawns a pickup at a random position
    public void SpawnPickup() {
        float l = Random.Range(0f, 0.8f);        

        if (l < 0.1f) {
            m = -4.5f;
            j = 3.7f;
        } else if (l < 0.2f) {
            m = 4.5f;
            j = 3.7f;
        } else if (l < 0.3f) {
            m = -4.5f;
            j = -3.7f;
        } else if (l < 0.4f) {
            m = 4.5f;
            j = -3.7f;
        } else if (l < 0.5f) {
            m = 0f;
            j = -3.7f;
        } else if (l < 0.6f) {
            m = 0f;
            j = 3.7f;
        } else if (l < 0.7f) {
            m = -1.5f;
            j = 0f;
        } else if (l <= 0.8f) {
            m = 1.5f;
            j = 0f;
        }

        float k = Random.Range(0f, 1f);
        if (k < 0.5f) {
            Instantiate(powerup, new Vector2(m, j), Quaternion.identity);
        } else if (k <= 1f) {
            Instantiate(trap, new Vector2(m, j), Quaternion.identity);
        }
        

    }

}
