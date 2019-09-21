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

    void BlastEm() {
        int randomInt;
        int randomNSInt;
        int randomEWInt;
        randomInt = Random.Range(0,4);
        randomNSInt = Random.Range(0,9);
        if (randomInt == 0) {
            //North
            //spawnsNorthLines[randomNSInt].SetActive(true);
            spawnsNorthCones[randomNSInt].SetActive(true);
        } else if (randomInt == 1) {
            //East
            //spawnsSouthLines[randomNSInt].SetActive(true);
            spawnsSouthCones[randomNSInt].SetActive(true);
        } else if (randomInt == 2) {
            //South
            spawnsSouthCones[randomNSInt].SetActive(true);
        } else {
            //West
            spawnsNorthCones[randomNSInt].SetActive(true);
        }
    }
}
