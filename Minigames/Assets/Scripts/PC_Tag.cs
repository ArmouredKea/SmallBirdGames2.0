using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Tag : PlayerController
{

    private float timer = 8f;
    public bool tagged = false;
    public bool it = false;
    public bool boosted;
    public bool slowed;
    public GameObject tagIcon;
    public GameObject pointLight;    

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();

        speed = 7f;
        rotationSpeed = 100.0f;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();        

        if (it) {
            tagIcon.SetActive(true);            
        } else {
            tagIcon.SetActive(false);
        }

        if (tagged) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    protected override void FixedUpdate() {
        base.FixedUpdate();

        //Player forward/backward movement and rotation.
        if (paused) {
            return;
        } else {
            if (gameObject.tag == "Player1") {
                GetComponent<Rigidbody2D>().AddForce(transform.up * Input.GetAxis("VerticalP1") * speed);
                transform.Rotate(0f, 0f, Input.GetAxis("HorizontalP1") * rotationSpeed * Time.deltaTime * -1);
            } else if (gameObject.tag == "Player2") {
                GetComponent<Rigidbody2D>().AddForce(transform.up * Input.GetAxis("VerticalP2") * speed);
                transform.Rotate(0f, 0f, Input.GetAxis("HorizontalP2") * rotationSpeed * Time.deltaTime * -1);
            } else {
                return;
            }
        }
    }

    //move character based on joystick directions.
    protected override void MoveCharacter(Vector2 direction) {
        base.MoveCharacter(direction);
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * speed * 2);
    }

    public void OnCollisionEnter2D(Collision2D collision) {

        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") && it == false) {
            tagged = true;
            it = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            tagIcon.SetActive(true);
            pointLight.GetComponent<Light>().spotAngle = 60;            
            speed = 0;
            StartCoroutine(TagDelay(2f));
        } else if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") && it == true) {
            it = false;
            tagIcon.SetActive(false);
            pointLight.GetComponent<Light>().spotAngle = 50;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Powerup") {
            Destroy(collision.gameObject);
            float i = Random.Range(0f, 0.9f);
            if (i < 0.5f) {
                SpeedPowerup();
                Debug.Log("Speed Powerup");
            } else {
                LightPowerup();
                Debug.Log("Light Powerup");
            }
        } else if (collision.gameObject.tag == "Trap") {
            Destroy(collision.gameObject);
            float i = Random.Range(0f, 0.9f);
            if (i < 0.5f) {
                SpeedTrap();
                Debug.Log("Speed Trap");
            } else {
                LightTrap();
                Debug.Log("Light Trap");
            }
        }
    }    

    private IEnumerator TagDelay(float waitTime) {

        yield return new WaitForSeconds(waitTime);
        tagged = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        speed = 7f;

    }

    public void SpeedPowerup() {
        speed = 10f;
        boosted = true;
        StartCoroutine(SpeedBoost(4f));
    }

    public void SpeedTrap() {
        speed = 2f;
        slowed = true;
        StartCoroutine(SpeedSlow(2f));
    }

    public void LightPowerup() {
        pointLight.GetComponent<Light>().spotAngle += 10;
    }

    public void LightTrap() {
        if (pointLight.GetComponent<Light>().spotAngle >= 10) {
            pointLight.GetComponent<Light>().spotAngle -= 10;
        }        
    }

    private IEnumerator SpeedBoost(float waitTime) {

        yield return new WaitForSeconds(waitTime);
        if (!slowed) {
            speed = 7f;
        }
        boosted = false;

    }

    private IEnumerator SpeedSlow(float waitTime) {

        yield return new WaitForSeconds(waitTime);
        if (!boosted) {
            speed = 7f;
        }
        slowed = false;

    }

}
