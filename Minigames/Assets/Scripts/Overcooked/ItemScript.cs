using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    public GameObject itemPrefab;
    public GameObject notTouchedItem;

    public Vector3 spawnedItemPos;

    //public GameObject spawnedItemSprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      SpawnItem();
    }

    void SpawnItem()
    {
      if (notTouchedItem == null)
      {
        notTouchedItem = Instantiate(itemPrefab, gameObject.transform.position, Quaternion.identity);
        spawnedItemPos = notTouchedItem.transform.position;
      }
      if (notTouchedItem.transform.position != spawnedItemPos)
      {
        notTouchedItem = null;
      }
    }
}
