using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_BumperCars : PlayerController {

    public Vector2 currentPosition;
    public float totalDistance;
    public bool boosted;

    public GameObject floatie;

    public Vector3 pauseVelocity;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        speed = 7f;
        rotationSpeed = 100.0f;
        totalDistance = 0f;
        currentPosition = gameObject.transform.position;

        /*GetComponent<Animator>().SetLayerWeight(0, 1);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        GetComponent<Animator>().SetLayerWeight(2, 0);*/
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
        //calculates distance travelled.
        float distance = Vector2.Distance(currentPosition, gameObject.transform.position);
        totalDistance += distance;
        currentPosition = gameObject.transform.position;

        //player boost.
        if (totalDistance >= 50f) {
            boosted = true;
            speed = 15f;
            floatie.GetComponent<Animator>().SetBool("Boosted", true);

            /*if (gameObject.tag == "Player1") {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
            } else if (gameObject.tag == "Player2") {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
            }*/

            StartCoroutine(BoostDuration(5f));
        }

        if (GetComponent<Rigidbody2D>().velocity.y == 0 && GetComponent<Rigidbody2D>().velocity.x == 0 && !paused) {
            animator.SetBool("Moving", false);
            floatie.GetComponent<Animator>().SetBool("Moving", false);
        } else {
            animator.SetBool("Moving", true);
            floatie.GetComponent<Animator>().SetBool("Moving", true);
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            PauseCharacter();
        } else if (Input.GetKeyDown(KeyCode.U)) {
            UnpauseCharacter();
        }

        if (paused) {
            GetComponent<Animator>().speed = 0;
            floatie.GetComponent<Animator>().speed = 0;
        } else {
            GetComponent<Animator>().speed = 1;
            floatie.GetComponent<Animator>().speed = 1;
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

    protected override void MoveCharacter(Vector2 direction) {
        base.MoveCharacter(direction);
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * speed * 2);
    }

    //player boost duration.
    private IEnumerator BoostDuration(float waitTime) {
        float l = 0;
        while (l < waitTime) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                yield return null;
            }
        }

        /*if (gameObject.tag == "Player1") {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        } else if (gameObject.tag == "Player2") {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.6f, 0.2f, 1);
        }*/

        speed = 7f;
        totalDistance = 0f;
        boosted = false;
        floatie.GetComponent<Animator>().SetBool("Boosted", false);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bombs") {
            GetComponent<Animator>().SetBool("TakeDamage", true);
            floatie.GetComponent<Animator>().SetBool("Hit", true);
            StartCoroutine(InvulnerableDuration(2f));
            //StartCoroutine(TakeDamage(1f, 0f, 0.5f));
        }
    }

    private IEnumerator InvulnerableDuration (float waitTime) {
        float l = 0;
        while (l < waitTime) {
            if (paused) {
                yield return null;
            } else {
                l += Time.deltaTime;
                yield return null;
            }
        }
        GetComponent<Animator>().SetBool("TakeDamage", false);
        floatie.GetComponent<Animator>().SetBool("Hit", false);
    }

    private IEnumerator TakeDamage(float startAlpha, float endAlpha, float duration) {        
        float t = 0;
        yield return null;
        /*while (t < duration) {
            float normalizedTime = t / duration;
            if (paused) {
                yield return null;
            } else {
                t += Time.deltaTime;
                floatieColor.a = Mathf.Lerp(startAlpha, endAlpha, normalizedTime);
                yield return null;
            }
        }
        floatieColor.a = endAlpha;
        t = 0;

        while (t < duration) {
            float normalizedTime = t / duration;
            if (paused) {
                yield return null;
            } else {
                t += Time.deltaTime;
                floatieColor.a = Mathf.Lerp(endAlpha, startAlpha, normalizedTime);
                yield return null;
            }
        }
        floatieColor.a = startAlpha;
        t = 0;

        while (t < duration) {
            float normalizedTime = t / duration;
            if (paused) {
                yield return null;
            } else {
                t += Time.deltaTime;
                floatieColor.a = Mathf.Lerp(startAlpha, endAlpha, normalizedTime);
                yield return null;
            }
        }
        floatieColor.a = endAlpha;
        t = 0;

        while (t < duration) {
            float normalizedTime = t / duration;
            if (paused) {
                yield return null;
            } else {
                t += Time.deltaTime;
                floatieColor.a = Mathf.Lerp(endAlpha, startAlpha, normalizedTime);
                yield return null;
            }
        }
        floatieColor.a = startAlpha;
        t = 0;*/
    }

    public void PauseCharacter() {
        //pauseForce = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        paused = true;
        pauseVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void UnpauseCharacter() {
        gameObject.GetComponent<Rigidbody2D>().velocity = pauseVelocity;
        paused = false;
    }
}
