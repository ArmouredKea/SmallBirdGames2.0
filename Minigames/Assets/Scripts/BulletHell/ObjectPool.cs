using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool pool_Instance; //If others want to use this, can help.
    // Start is called before the first frame update
   // public List<GameObject> pool_List; // List of pooled objects

    public GameObject pool_Object; // Object to pool
    //public GameObject pool_RedProj; //Put different projectiles in their relevant slots. The pool switches and changes depending on current active.
    public GameObject pool_BlueProj; //add rest if this works.
    public GameObject pool_YellowProj;

    public GameObject pool_WhiteProj;
    public GameObject pool_GreenProj;


    //public bool pool_RedProjTime;
    public bool pool_YellowProjTime;
    public bool pool_GreenProjTime;
    public bool pool_WhiteProjTime;
    public bool pool_BlueProjTime;

    public int pool_NumToPool;

    //This works
   // public List<GameObject> pool_ListR;
    public List<GameObject> pool_ListB;
    public List<GameObject> pool_ListG;
    public List<GameObject> pool_ListY;
    public List<GameObject> pool_ListYC;
    public List<GameObject> pool_ListW;


    //Make a powerup start bool? Does it reuse previous pools?


    void Start()
    {
        PoolTime();


    }

    void Awake()
    {
        pool_Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetPooledObject()
    {

        if (pool_YellowProjTime == true)
        {
            for (int i = 0; i < pool_ListY.Count; i++)
            //Check if the item is not currently active. If not, it exists and gives inactive to GetPooledObject.
            {
                if (!pool_ListY[i].activeInHierarchy)
                {
                    return pool_ListY[i];
                }
            }
        }

        else if (pool_GreenProjTime == true)
        {
            for (int i = 0; i < pool_ListG.Count; i++)
            //Check if the item is not currently active. If not, it exists and gives inactive to GetPooledObject.
            {
                if (!pool_ListG[i].activeInHierarchy)
                {
                    return pool_ListG[i];
                }
            }
        }

        else if (pool_WhiteProjTime == true)
        {
            for (int i = 0; i < pool_ListW.Count; i++)
            //Check if the item is not currently active. If not, it exists and gives inactive to GetPooledObject.
            {
                if (!pool_ListW[i].activeInHierarchy)
                {
                    return pool_ListW[i];
                }
            }
        }

        else //if powerup isn't set to anything, use default.
        {
            for (int i = 0; i < pool_ListB.Count; i++)
            //Check if the item is not currently active. If not, it exists and gives inactive to GetPooledObject.
            {
                if (!pool_ListB[i].activeInHierarchy)
                {
                    return pool_ListB[i];
                }
            }
        }

        return null;

        /*if (pool_RedProjTime == true) //Set bool via GunnerPowerup Script.
            {
                //iterates through pool_list
                for (int i = 0; i < pool_ListR.Count; i++)
                //Check if the item is not currently active. If not, it exists and gives inactive to GetPooledObject.
                {
                    if (!pool_ListR[i].activeInHierarchy)
                    {
                        return pool_ListR[i];
                    }
                }

            }
            */
    }

    public void PoolTime()
    { //This function just adds the projectiles to lists.
        //pool_ListR = new List<GameObject>();
        pool_ListB = new List<GameObject>();
        pool_ListY = new List<GameObject>();
       // pool_ListYC = new List<GameObject>();
        pool_ListW = new List<GameObject>();
        pool_ListG = new List<GameObject>();

        for (int i = 0; i < pool_NumToPool; i++)
        {
            GameObject pool_objBlue = (GameObject)Instantiate(pool_BlueProj);
          //  GameObject pool_objRed = (GameObject)Instantiate(pool_RedProj);
            GameObject pool_objYellow = (GameObject)Instantiate(pool_YellowProj);
           // GameObject pool_objYellowChild = (GameObject)Instantiate(pool_YellowChildProj);
            GameObject pool_objWhite = (GameObject)Instantiate(pool_WhiteProj);
            GameObject pool_objGreen = (GameObject)Instantiate(pool_GreenProj);
            //pool_ListR.Add(pool_objRed);
            pool_ListB.Add(pool_objBlue);
            pool_ListY.Add(pool_objYellow);
            pool_ListW.Add(pool_objWhite);
            pool_ListG.Add(pool_objGreen);
            pool_Object.SetActive(false);

        }
    }
    public void StopAll()
    {
            //ObjectPool.pool_Instance.pool_RedProjTime = false;
            ObjectPool.pool_Instance.pool_YellowProjTime = false;
            ObjectPool.pool_Instance.pool_GreenProjTime = false;
            ObjectPool.pool_Instance.pool_WhiteProjTime = false;

        }


    public void PausePool(bool isPause)
    {
        if(isPause == true) {
                foreach(GameObject blueStop in pool_ListB)
             {
                blueStop.GetComponent<BlueProjectile>().PauseProj();
             }
            /*foreach (GameObject redStop in pool_ListR)
            {
                redStop.GetComponent<RedProjectile>().PauseProj();
            }*/
            foreach (GameObject yellowStop in pool_ListY)
            {
                yellowStop.GetComponent<YellowProjectile>().PauseProj();
            }
            foreach (GameObject greenStop in pool_ListG)
            {
                greenStop.GetComponent<GreenProjectile>().PauseProj();
            }
            foreach (GameObject whiteStop in pool_ListW)
            {
                whiteStop.GetComponent<WhiteProjectile>().PauseProj();
            }
        }

        if (isPause == false)
        {
            foreach (GameObject blueStop in pool_ListB)
            {
                blueStop.GetComponent<BlueProjectile>().UnpauseProj();
            }
           /* foreach (GameObject redStop in pool_ListR)
            {
                redStop.GetComponent<RedProjectile>().UnpauseProj();
            } */
            foreach (GameObject yellowStop in pool_ListY)
            {
                yellowStop.GetComponent<YellowProjectile>().UnpauseProj();
            }
            foreach (GameObject greenStop in pool_ListG)
            {
                greenStop.GetComponent<GreenProjectile>().UnpauseProj();
            }
            foreach (GameObject whiteStop in pool_ListW)
            {
                whiteStop.GetComponent<WhiteProjectile>().UnpauseProj();
            }
        }
    }

    }
