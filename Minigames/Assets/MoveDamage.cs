using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveDamage : MonoBehaviour
{
    private Vector3 start;
    private Vector3 end;
    public AnimationCurve acMove;
    public AnimationCurve acAlpha;
    public float time = 2.0f;
    public float distance = 2.0f;
    public float xOffset = 0.5f;

    void Start()
    {
     
        start = transform.position;
        end = start + new Vector3(Random.Range(-xOffset, xOffset), distance, 0.5f);
        StartCoroutine(Animate(start, end));
    }

    IEnumerator Animate(Vector3 pos1, Vector3 pos2)
    {
        //start our timer
        float timer = 0.0f;
        //stores the values of our animation curve evaluation
        float evalMove = 0.0f;
        float evalAlpha = 0.0f;

        //the textmesh to change the color
        Text textMesh = GetComponent<Text>();

        //while we haven't hit our timeout
        while (timer <= time)
        {
            //get the next values from the animation curve
            evalMove = acMove.Evaluate(timer / time);
            evalAlpha = 1f - acAlpha.Evaluate(timer / time);

            //lerp along our path from start to end position
            transform.position = Vector3.Lerp(pos1, pos2, evalMove);

            //get the current color of the text
            Color color = textMesh.color;
            //set the alpha value for fade out
            color.a = evalAlpha;
            textMesh.color = color;

            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
