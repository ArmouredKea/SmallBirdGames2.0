using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCScoreControls : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player1Control;
    public GameObject player2Control;

    public bool player1Wins;
    public bool player2Wins;
    public bool draw;

    void Update() {
    if (player1Control.gameObject.GetComponent<GameController>().gameEnd) {
        if (player1Control.gameObject.GetComponent<GameController>().points > player2Control.gameObject.GetComponent<GameController>().points) {
            player1Wins = true;
        } else if (player1Control.gameObject.GetComponent<GameController>().points < player2Control.gameObject.GetComponent<GameController>().points) {
            player2Wins = true;
        } else if (player1Control.gameObject.GetComponent<GameController>().points == player2Control.gameObject.GetComponent<GameController>().points)
            draw = true;
        }
    }
}
