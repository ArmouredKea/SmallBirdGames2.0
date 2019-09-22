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


    //Overcooked Buttons
    public GameObject p1BoB;
    public GameObject p1HiroB;
    public GameObject p1MikaB;
    public GameObject p2BoB;
    public GameObject p2HiroB;
    public GameObject p2MikaB;

    // Start is called before the first frame update
    void Awake() {
        if (CharacterCarryOver.player1 == "Bo") {
            p1Bo.SetActive(true);
            if (SceneManager.GetActiveScene().name == "OvercookedMG") {
              p1BoB.SetActive(true);
            }
        } else if (CharacterCarryOver.player1 == "Hiro") {
            p1Hiro.SetActive(true);
            if (SceneManager.GetActiveScene().name == "OvercookedMG") {
              p1HiroB.SetActive(true);
            }
        } else if (CharacterCarryOver.player1 == "Mika") {
            p1Mika.SetActive(true);
            if (SceneManager.GetActiveScene().name == "OvercookedMG") {
              p1MikaB.SetActive(true);
            }
        }

        if (CharacterCarryOver.player2 == "Bo") {
            p2Bo.SetActive(true);
            if (SceneManager.GetActiveScene().name == "OvercookedMG") {
              p2BoB.SetActive(true);
            }
        } else if (CharacterCarryOver.player2 == "Hiro") {
            p2Hiro.SetActive(true);
            if (SceneManager.GetActiveScene().name == "OvercookedMG") {
              p2HiroB.SetActive(true);
            }
        } else if (CharacterCarryOver.player2 == "Mika") {
            p2Mika.SetActive(true);
            if (SceneManager.GetActiveScene().name == "OvercookedMG") {
              p2MikaB.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
