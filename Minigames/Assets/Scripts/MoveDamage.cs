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

    [SerializeField]
    private Sprite Mika;

    [SerializeField]
    private Sprite Bo;

    [SerializeField]
    private Sprite Hiro;

    [SerializeField]
    private bool isSpeechBubble;
    [SerializeField]
    private bool isP1;
    [SerializeField]
    private bool isP2;

    [SerializeField]
    private Canvas rotationP1;

    [SerializeField]
    private Canvas rotationP2;



    void Start()
    {

        start = transform.position;
        end = start + new Vector3(Random.Range(-xOffset, xOffset), distance, 0.5f);


        if(isSpeechBubble == true)
        {
            StartCoroutine(AnimateImage(start, end));
        }

        else
        {
         StartCoroutine(AnimateText(start, end));

        }
           
    }

    private void Update()
    {
        
    }

    IEnumerator AnimateText(Vector3 pos1, Vector3 pos2)
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

    IEnumerator AnimateImage(Vector3 pos1, Vector3 pos2)
    {
        //start our timer
        float timer = 0.0f;
        //stores the values of our animation curve evaluation
        float evalMove = 0.0f;
        float evalAlpha = 0.0f;

        
        Image imageCol = GetComponent<Image>();

        //while we haven't hit our timeout
        while (timer <= time)
        {
            //get the next values from the animation curve
            evalMove = acMove.Evaluate(timer / time);
            evalAlpha = 1f - acAlpha.Evaluate(timer / time);

            //lerp along our path from start to end position
            transform.position = Vector3.Lerp(pos1, pos2, evalMove);

            //get the current color of the text
            Color color = imageCol.color;
            //set the alpha value for fade out
            color.a = evalAlpha;
            imageCol.color = color;

            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }


    public void ChangeSprite(string character, int player)
    {

        if(character == "Bo")
        {
            gameObject.GetComponent<Image>().sprite = Bo;
        }

        else if(character == "Hiro")
        {
            gameObject.GetComponent<Image>().sprite = Hiro;
        }
        else if (character == "Mika")
        {
            gameObject.GetComponent<Image>().sprite = Mika;
        }
    }
    public void OnDestroy()
    {
        isP1 = false;
        isP2 = false;
    }
}
