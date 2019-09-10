using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManagement : MonoBehaviour
{

    public GameObject p1Bo;
    public GameObject p1Hiro;
    public GameObject p1Mika;
    public GameObject p2Bo;
    public GameObject p2Hiro;
    public GameObject p2Mika;

    // Start is called before the first frame update
    void Start() {
        if (CharacterCarryOver.player1 == "Bo") {
            p1Bo.SetActive(true);
        } else if (CharacterCarryOver.player1 == "Hiro") {
            p1Hiro.SetActive(true);
        } else if (CharacterCarryOver.player1 == "Mika") {
            p1Mika.SetActive(true);
        }

        if (CharacterCarryOver.player2 == "Bo") {
            p2Bo.SetActive(true);
        } else if (CharacterCarryOver.player2 == "Hiro") {
            p2Hiro.SetActive(true);
        } else if (CharacterCarryOver.player2 == "Mika") {
            p2Mika.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
