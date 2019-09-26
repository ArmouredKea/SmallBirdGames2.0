using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagFade : MonoBehaviour
{
    // Start is called before the first frame update


    public AnimationCurve acAlpha;
    public float time = 2.0f;


    void OnEnable()
    {

      
        StartCoroutine(AnimateFade());
    }

    IEnumerator AnimateFade()
    {
        //start our timer
        float timer = 0.0f;
        //stores the values of our animation curve evaluation
        
        float evalAlpha = 0.0f;

        //the textmesh to change the color
        Text textMesh = GetComponent<Text>();

        //while we haven't hit our timeout
        while (timer <= time)
        {
            //get the next values from the animation curve
           
            evalAlpha = 1f - acAlpha.Evaluate(timer / time);

            //lerp along our path from start to end position
          

            //get the current color of the text
            Color color = textMesh.color;
            //set the alpha value for fade out
            color.a = evalAlpha;
            textMesh.color = color;

            timer += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
