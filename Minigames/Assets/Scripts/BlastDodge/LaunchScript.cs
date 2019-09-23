using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScript : MonoBehaviour
{
    public GameObject gameController;

    public Vector3 startPos;
    public Vector3 target;
    public float throwTime;

    public float timer;
    private float waitTime;



    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= throwTime) {
        timer += Time.deltaTime;
        } else {
            waitTime += Time.deltaTime;
        }
        gameObject.transform.position = Vector3.Lerp(startPos, target, timer/throwTime);
        if (gameObject.transform.position == target) {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            if (waitTime >= 2.2) {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                gameObject.SetActive(false);
                timer = 0f;
                gameController.GetComponent<BlastGameController>().balloonQueue.Enqueue(gameObject);
                if (throwTime >= 2.2) {
                    for (int i = 0; i <= gameController.GetComponent<BlastGameController>().currentLines.Count - 1; i++) {
                        gameController.GetComponent<BlastGameController>().currentLines[i].SetActive(false);
                    }
                }
                waitTime = 0f;
            }
        }
    }
}
