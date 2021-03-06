﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSeed : MonoBehaviour
{

    public GameObject Cloud1;
    public GameObject Cloud2;


    public float minTimeTill;
    public float maxTimeTill;
    public float setTime;
    public float timer;

    public bool spawnCheck;
    public float whichSpawn;

    public GameObject cloudSpawnPoint;
    public GameObject cloudEndPoint;


    // Start is called before the first frame update
    void Start()
    {
        spawnCheck = true;
        timer = 5;
    }

     void Awake()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        



        timer += Time.deltaTime;



        if(spawnCheck == true)
        {
            setTime = Random.Range(minTimeTill, maxTimeTill);
            whichSpawn = Random.Range(0, 2);

            spawnCheck = false;
        }



        if(timer >= setTime)
        {

            if (whichSpawn >= 0.5f)
            {
                Cloud1.GetComponent<MoveCloud>().StartPoint = cloudSpawnPoint;
                Cloud1.GetComponent<MoveCloud>().EndPoint = cloudEndPoint;
                Instantiate(Cloud1, cloudSpawnPoint.transform);
                
            }

            else
            {
                Cloud2.GetComponent<MoveCloud>().StartPoint = cloudSpawnPoint;
                Cloud2.GetComponent<MoveCloud>().EndPoint = cloudEndPoint;
                Instantiate(Cloud2, cloudSpawnPoint.transform.position, cloudSpawnPoint.transform.rotation, cloudEndPoint.transform);
               
            }



            timer = 0;
            spawnCheck = true;
        }

    }

  


}
