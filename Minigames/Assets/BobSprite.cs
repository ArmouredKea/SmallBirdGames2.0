using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BobSprite : MonoBehaviour
{

    //public AnimationCurve bobCurve;


        [SerializeField]
        private float height;

        [SerializeField]
        private float speed;





    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Stores the position, this way the object can be anywhere and still bob correctly.
        Vector3 storePos = transform.localPosition;

        float newY = Mathf.Sin(Time.time * speed) * height + storePos.y;
        transform.localPosition = new Vector3(storePos.x, newY, storePos.z) * height;


        //transform.position = new Vector2(transform.position.x, bobCurve.Evaluate((Time.fixedTime % bobCurve.length))); 
        //While easier to use, there was not enough control. Cannot randomize bob-level for other things.
    }
}
