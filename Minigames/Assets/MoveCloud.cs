using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Rigidbody2D self;

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



    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody2D>();
        
        speed = Random.Range(minSpeed, maxSpeed);


        yPos = Random.Range(minY, maxY); //Set the area that the object can start between.
        zPos = Random.Range(minZ, maxZ);
        Size = Random.Range(minSize, maxSize); //Set the shared size
        Alpha = Random.Range(minAlpha, maxAlpha);

        Pos = new Vector3(transform.position.x, yPos, zPos);
        gameObject.transform.localScale = new Vector3(Size, Size, 10);
        self.transform.position = Pos;
        self.velocity = transform.right * speed;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, Alpha);

        


        //Add transpacy randomiser
        //add Zpos seperate randomizer
        //tighten scope of movement
        //test in menus
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

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
