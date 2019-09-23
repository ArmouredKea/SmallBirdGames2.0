using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownScript : MonoBehaviour
{
    public GameObject gameController;

    public Vector3 target;
    public float throwTime;



    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
