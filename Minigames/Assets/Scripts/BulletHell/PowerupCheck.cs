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
    public PC_BulletHell gunner;


    [SerializeField]
    private bool r;
    [SerializeField]
    private bool y;
    [SerializeField]
    private bool g;
    [SerializeField]
    private bool w;

    public Transform Position_current;
    public GameObject audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnEnable()
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
                if (gunnerSpawn.Powerup_Activated == false)
                {
                    if (collision != null)
                    {
                        gunner = collision.gameObject.GetComponent<ProjectileParent>().firedFrom.GetComponent<PC_BulletHell>();
                    }
                    gunnerSpawn.GetGunner(gunner);
                    gunnerSpawn.Deactivate();
                    gunnerSpawn.ExecutePowerup(r, y, g, w);
                    gunnerSpawn.Spawn_SpawnedObj.Remove(Position_current);

                    audioManager.GetComponent<AudioManagerScript>().PlayAudio("Crate2");
                    gameObject.SetActive(false);
                }

               else if (gunnerSpawn.Powerup_Activated == true && ObjectPool.pool_Instance.pool_WhiteProjTime == true & w == true)
                {
                    gunnerSpawn.refreshDuration = true;
                    gunnerSpawn.Spawn_SpawnedObj.Remove(Position_current);
                    audioManager.GetComponent<AudioManagerScript>().PlayAudio("Crate2");
                    gameObject.SetActive(false);
                }

                else if (gunnerSpawn.Powerup_Activated == true && ObjectPool.pool_Instance.pool_YellowProjTime == true & y == true)
                {
                    gunnerSpawn.refreshDuration = true;
                    gunnerSpawn.Spawn_SpawnedObj.Remove(Position_current);
                    audioManager.GetComponent<AudioManagerScript>().PlayAudio("Crate2");
                    gameObject.SetActive(false);
                }

                else if (gunnerSpawn.Powerup_Activated == true && ObjectPool.pool_Instance.pool_GreenProjTime == true & g == true)
                {
                    gunnerSpawn.refreshDuration = true;
                    gunnerSpawn.Spawn_SpawnedObj.Remove(Position_current);
                    audioManager.GetComponent<AudioManagerScript>().PlayAudio("Crate2");
                    gameObject.SetActive(false);
                }
                else { }
            }
            else
            {
                //do nothing
            }
                   
                }
            
           /* else if (collision.tag == "Player1" || collision.tag == "Player2")
            {
                //"Pop" effect here.
                gunnerSpawn.Spawn_SpawnedObj.Remove(Position_current);
                gameObject.SetActive(false);
                
            }*/
        

        else if (forRunner == true)
        {
            if (collision.tag == "Projectile")
            {
                //"Use" effect here.

                //runnerSpawn.Deactivate(); ? Do we want the shooter to be able to hit the powerups?!
               
                //gameObject.SetActive(false);
            }
            else if (collision.tag == "Player1" || collision.tag == "Player2")
            {
                //"Pop" effect here.
                getRunner = collision.gameObject.GetComponent<PC_BulletHell>();
                runnerSpawn.GetRunner(runner: getRunner);
                runnerSpawn.Spawn_SpawnedObj.Remove(Position_current);
                audioManager.GetComponent<AudioManagerScript>().PlayAudio("PowerUp");
                if (runnerSpawn.Powerup_Activated == true & r == true)
                {
                    runnerSpawn.refreshDuration = true;
                }
                runnerSpawn.ExecutePowerup(r, y, g, w);
                gameObject.SetActive(false);
                
               

                
                
                
            }
        }

      
    }



}
