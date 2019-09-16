using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    //time that it takes to dispense
    public int dispenseTime;

    //bool to check if a player is already dispensing to x dispenser
    public bool dispensingP1;
    public bool dispensingP2;

    //variables to be apoplied to balloon on fill
    public Color dColor;
    public string dBalloonName;
    public int points;

}
