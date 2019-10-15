using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BobSprite : MonoBehaviour
{

    //public AnimationCurve bobCurve;


        [SerializeField]
        private float bobAmp;

        [SerializeField]
        private float bobFreq;

        [SerializeField]
        private float durationBob;

        Vector2 storePos = new Vector2();
        Vector2 offset = new Vector2();




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        storePos = offset; //Stores the position, this way the object can be anywhere and still bob correctly.

        storePos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * bobFreq) * bobAmp;
        transform.position = storePos;


        //transform.position = new Vector2(transform.position.x, bobCurve.Evaluate((Time.fixedTime % bobCurve.length))); 
        //While easier to use, there was not enough control. Cannot randomize bob-level for other things.
    }
}
