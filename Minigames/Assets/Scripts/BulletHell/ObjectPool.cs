using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool pool_Instance; //If others want to use this, can help.
    // Start is called before the first frame update
    public List<GameObject> pool_List; // List of pooled objects
    public GameObject pool_Object; // Object to pool
    public int pool_NumToPool;

    void Start()
    {
        pool_List = new List<GameObject>();
        for (int i = 0; i < pool_NumToPool; i++)
        {
            GameObject pool_obj = (GameObject)Instantiate(pool_Object);
            pool_Object.SetActive(false);
            pool_List.Add(pool_obj);
        }


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
        //iterates through pool_list
        for (int i = 0; i < pool_List.Count; i++)
            //Check if the item is not currently active. If not, it exists and gives inactive to GetPooledObject.
         {
            if (!pool_List[i].activeInHierarchy)
            {
                return pool_List[i];
            }
         }
        return null;
    }
}
