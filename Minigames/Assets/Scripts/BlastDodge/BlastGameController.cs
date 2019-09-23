using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastGameController : MonoBehaviour
{
    /*
        Dictionary of N horizontal Points = 16
        Dictionary of S horizontal Points = 16
        Dictionary of E horizontal Points = 12
        Dictionary of W horizontal Points = 12

        NW -4.4, 3
        SE 4.4, -3
    */

    public GameObject pickUp;
    private Vector2 nw = new Vector2(-4.4f, 3f);
    private Vector2 se = new Vector2(4.4f, -3f);
    public float timer;
    private float spawnTime = 5;

    public GameObject thrown;

    public Queue<GameObject> balloonQueue = new Queue<GameObject>();
    private bool fire;

    /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    //Blast object list setting
    public GameObject northCones;
    public GameObject southCones;
    public GameObject northLines;
    public GameObject southLines;
    public GameObject eastLines;
    public GameObject westLines;

    List <GameObject> spawnsNorthCones = new List <GameObject>(); //index total of 9
    List <GameObject> spawnsSouthCones = new List <GameObject>(); //index total of 9
    List <GameObject> spawnsNorthLines = new List <GameObject>(); //index total of 9
    List <GameObject> spawnsSouthLines = new List <GameObject>(); //index total of 9
    List <GameObject> spawnsEastLines = new List <GameObject>(); //index total of 7
    List <GameObject> spawnsWestLines = new List <GameObject>(); //index total of 7
    public List <GameObject> currentLines = new List <GameObject>();


    void Start() {
        foreach (Transform transform in northCones.transform) {
            spawnsNorthCones.Add(transform.gameObject);
        }
        foreach (Transform transform in southCones.transform) {
            spawnsSouthCones.Add(transform.gameObject);
        }
        foreach (Transform transform in northLines.transform) {
            spawnsNorthLines.Add(transform.gameObject);
        }
        foreach (Transform transform in southLines.transform) {
            spawnsSouthLines.Add(transform.gameObject);
        }
        foreach (Transform transform in eastLines.transform) {
            spawnsEastLines.Add(transform.gameObject);
        }
        foreach (Transform transform in westLines.transform) {
            spawnsWestLines.Add(transform.gameObject);
        }
        GameObject tempGO;
        for (int i = 0; i <= 55; i++) {
            tempGO = Instantiate (thrown, new Vector3(0, 0, 0), Quaternion.identity);
            tempGO.SetActive(false);
            balloonQueue.Enqueue(tempGO);
            Debug.Log(balloonQueue.Peek());
        }
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnTime) {
            timer = 0;
            PickUpSpawn();
            BlastEm();

        }
    }

    void PickUpSpawn() {
        Instantiate(pickUp, new Vector3(Random.Range(nw.x, se.x), Random.Range(nw.y, se.y), -5), Quaternion.identity);
    }

    void BlastEm() {
        int randomInt;
        int randomNSInt;
        int randomEWInt;
        currentLines.Clear();
        for (int j = 0; j <= 3; j++) {
            randomInt = Random.Range(0,4);
            randomNSInt = Random.Range(0,9);
            currentLines.Add(spawnsSouthLines[randomNSInt]);
            StartCoroutine(SpawnWave(randomNSInt));
        }
        // if (randomInt == 0) {
        //     //North
        //     //spawnsNorthLines[randomNSInt].SetActive(true);
        //     spawnsNorthCones[randomNSInt].SetActive(true);
        // } else if (randomInt == 1) {
        //     //East
        //     //spawnsSouthLines[randomNSInt].SetActive(true);
        //     spawnsSouthCones[randomNSInt].SetActive(true);
        // } else if (randomInt == 2) {
        //     //South
        //     spawnsSouthCones[randomNSInt].SetActive(true);
        // } else {
        //     //West
        //     spawnsNorthCones[randomNSInt].SetActive(true);
        // }
    }

    IEnumerator SpawnWave (int rr) {
        float fireTime = 0;
        spawnsSouthLines[rr].SetActive(true);
        List <Vector3> lineTargets = new List <Vector3>();
        foreach (Transform child in spawnsSouthLines[rr].transform) {
            if (child.tag == "Target") {
                lineTargets.Add(child.transform.position);
            }
        }
        for (int i = 0; i <= 10; i++) {
            GameObject b;
            b = balloonQueue.Dequeue();
            b.GetComponent<LaunchScript>().throwTime = (fireTime += 0.2f);
            b.transform.position = spawnsSouthLines[rr].transform.position;
            b.GetComponent<LaunchScript>().startPos = spawnsSouthLines[rr].transform.position;
            b.GetComponent<LaunchScript>().target = lineTargets[i];
            b.SetActive(true);
        }
        lineTargets.Clear();
        yield return null;
    }
}
