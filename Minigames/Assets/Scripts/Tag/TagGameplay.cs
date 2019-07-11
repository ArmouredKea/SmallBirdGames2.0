using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagGameplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float i = Random.Range(0f, 0.9f);

        if (i < 0.5f) {
            GameObject.Find("Player1").GetComponent<TagScript>().it = true;
        } else {
            GameObject.Find("Player2").GetComponent<TagScript>().it = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
