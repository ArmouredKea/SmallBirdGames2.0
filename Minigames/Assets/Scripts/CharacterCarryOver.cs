using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCarryOver : MonoBehaviour
{

    static public string player1 = "";
    static public string player2 = "";
    public static int p1Score;
    public static int p2Score;
    public GameObject audioManager;

    // Start is called before the first frame update
    void Start() {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    // Update is called once per frame
    void Update() {

    }

    public void ButtonSound() {
        audioManager.GetComponent<AudioManagerScript>().PlayAudio("Countdown");
    }
}
