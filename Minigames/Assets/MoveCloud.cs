using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCloud : MonoBehaviour
{
    public float speed;

    public CloudSeed generator;

    public float minSize;
    public float maxSize;
    public float Size;

    public float minSpeed;
    public float maxSpeed;



    public float minY;
    public float maxY;
    public float yPos;

    public float minZ;
    public float maxZ;
    public float zPos;

    public Vector3 Pos;

    public float minAlpha;
    public float maxAlpha;
    public float Alpha;

    public float expireIn;
    private float expireCurrent;
    public GameObject StartPoint;
    public GameObject EndPoint;
    public float minDistance;



    // Start is called before the first frame update
    void Start()
    {
        //self = gameObject.GetComponent<Rigidbody2D>();
        
        speed = Random.Range(minSpeed, maxSpeed);

        
        yPos = Random.Range(minY, maxY); //Set the area that the object can start between.
        zPos = Random.Range(minZ, maxZ);
        Size = Random.Range(minSize, maxSize); //Set the shared size
        Alpha = Random.Range(minAlpha, maxAlpha);

        //Pos = new Vector3(transform.position.x, yPos, zPos);
        gameObject.transform.localScale = new Vector3(Size, Size, 10);
        //gameObject.transform.position = Pos;
        
        gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, Alpha);

   
        


        //Add transpacy randomiser
        //add Zpos seperate randomizer
        //tighten scope of movement
        //test in menus
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        if (Vector3.Distance(gameObject.transform.position, EndPoint.transform.position) > minDistance)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, EndPoint.transform.position, Time.deltaTime * speed);

        }
        else
        {
            gameObject.gameObject.transform.position = EndPoint.transform.position;
            gameObject.gameObject.transform.rotation = EndPoint.transform.rotation;
            Destroy(gameObject);
        }





            //gameObject.transform.position = new Vector3(move.x, 0f, 0f);

            expireCurrent += Time.deltaTime;

            if (expireIn < expireCurrent)
            {
                Destroy(gameObject);
            }
        }
    

     void OnEnable()
    {
      

    }

}

