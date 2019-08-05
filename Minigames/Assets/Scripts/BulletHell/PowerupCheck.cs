using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCheck : MonoBehaviour
{
 
    public GunnerPowerups powerupSpawn;

    [SerializeField]
    private bool r;
    [SerializeField]
    private bool y;
    [SerializeField]
    private bool g;
    [SerializeField]
    private bool w;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //Powerup Spawn Effect here.
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            //"Use" effect here.
            
            powerupSpawn.Deactivate();
            powerupSpawn.ExecutePowerup(r, y, g, w);
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player1" || collision.tag == "Player2")
        {
            //"Pop" effect here.
            gameObject.SetActive(false);
        }
    }


 



}
