using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCheck : MonoBehaviour
{
 
    public GunnerPowerups gunnerSpawn;
    public RunnerPowerups runnerSpawn;

    [SerializeField]
    private bool forShooter;

    [SerializeField]
    private bool forRunner;

    public PC_BulletHell getRunner;

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
        if(forShooter == true)
        { 
            if (collision.tag == "Projectile")
            {
                //"Use" effect here.
            
                gunnerSpawn.Deactivate();
                gunnerSpawn.ExecutePowerup(r, y, g, w);
                gameObject.SetActive(false);
            }
            else if (collision.tag == "Player1" || collision.tag == "Player2")
            {
                //"Pop" effect here.
                gameObject.SetActive(false);
            }
        }
        else if (forRunner == true)
        {
            if (collision.tag == "Projectile")
            {
                //"Use" effect here.

                //runnerSpawn.Deactivate(); ? Do we want the shooter to be able to hit the powerups?!
               
                gameObject.SetActive(false);
            }
            else if (collision.tag == "Player1" || collision.tag == "Player2")
            {
                //"Pop" effect here.
                getRunner = collision.gameObject.GetComponent<PC_BulletHell>();
                runnerSpawn.GetRunner(runner: getRunner);
                gameObject.SetActive(false);

              
                runnerSpawn.ExecutePowerup(r, y, g, w);
                
                
            }
        }
    }


 



}
