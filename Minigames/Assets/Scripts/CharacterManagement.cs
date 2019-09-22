using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManagement : MonoBehaviour
{

    public GameObject p1Bo;
    public GameObject p1Hiro;
    public GameObject p1Mika;
    public GameObject p2Bo;
    public GameObject p2Hiro;
    public GameObject p2Mika;
    public GameObject p1JoystickInner;
    public GameObject p1JoystickOuter;
    public GameObject p2JoystickInner;
    public GameObject p2JoystickOuter;


    // Start is called before the first frame update
    void Awake() {
        if (CharacterCarryOver.player1 == "Bo") {
            p1Bo.SetActive(true);
            p1JoystickInner.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickInner_Bo");
            p1JoystickOuter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickOuter_Bo");
        } else if (CharacterCarryOver.player1 == "Hiro") {
            p1Hiro.SetActive(true);
            p1JoystickInner.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickInner_Hiro");
            p1JoystickOuter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickOuter_Hiro");
        } else if (CharacterCarryOver.player1 == "Mika") {
            p1Mika.SetActive(true);
            p1JoystickInner.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickInner_Mika");
            p1JoystickOuter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickOuter_Mika");
        }

        if (CharacterCarryOver.player2 == "Bo") {
            p2Bo.SetActive(true);
            p2JoystickInner.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickInner_Bo");
            p2JoystickOuter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickOuter_Bo");
        } else if (CharacterCarryOver.player2 == "Hiro") {
            p2Hiro.SetActive(true);
            p2JoystickInner.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickInner_Hiro");
            p2JoystickOuter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickOuter_Hiro");
        } else if (CharacterCarryOver.player2 == "Mika") {
            p2Mika.SetActive(true);
            p2JoystickInner.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickInner_Mika");
            p2JoystickOuter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("JoystickOuter_Mika");
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
