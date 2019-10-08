using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPosition : MonoBehaviour
{

    public Transform getPosition;
    public bool isP1;
    public bool isP2;
    // Start is called before the first frame update
    void Start()
    {
        if(isP1 == true) { getPosition = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>(); }
        else if (isP2 == true) {getPosition = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>(); }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = getPosition.transform.position;

    }
}
