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
    private float timer;
    private float spawnTime = 5;

    public GameObject thrown;

    public Queue<GameObject> balloonQueue = new Queue<GameObject>();
    private float fireTime;
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
    public List <GameObject> spawnsSouthLines = new List <GameObject>(); //index total of 9
    List <GameObject> spawnsEastLines = new List <GameObject>(); //index total of 7
    List <GameObject> spawnsWestLines = new List <GameObject>(); //index total of 7
    List <Vector3> lineTargets = new List <Vector3>();


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
        PickUpSpawn();
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnTime) {
            PickUpSpawn();
            BlastEm();
            timer = 0;
        }
    }

    void PickUpSpawn() {
        Instantiate(pickUp, new Vector3(Random.Range(nw.x, se.x), Random.Range(nw.y, se.y), -5), Quaternion.identity);
    }

    //Spawn V balloon -4.9 Y
    //Spawn H balloon -7 Y
    //land V balloon 8.05 X
    //land H balloon 5.89 X

    //per splat, 0.2s between each

    //SouthV Sp -0.4
    //SouthV 1st -3.45 (+1.15)

    void BlastEm() {
        int randomInt;
        int randomNSInt;
        int randomEWInt;
        randomInt = Random.Range(0,4);
        randomNSInt = Random.Range(0,9);

        spawnsSouthLines[randomNSInt].SetActive(true);
        foreach (Transform child in spawnsSouthLines[randomNSInt].transform) {
            if (child.tag == "Target") {
                lineTargets.Add(child.transform.position);
            }
        }
        for (int i = 0; i <= 11; i++) {
            GameObject b;
            b = balloonQueue.Dequeue();
            //b.GetComponent<ThrownBalloonScript>().throwTime = (fireTime += 0.2f);
            b.transform.position = new Vector3(spawnsSouthLines[randomNSInt].transform.position.x, (spawnsSouthLines[randomNSInt].transform.position.y -= 0.4f), spawnsSouthLines[randomNSInt].transform.position.z);
            //b.GetComponent<ThrownBalloonScript>().target += lineTargets[i];
            b.SetActive(true);
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
}
