using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupParent : MonoBehaviour
{
    public bool paused;
    public Transform[] Spawn_ListPoints;

    [SerializeField]
    private GameObject RedPowerup;
    [SerializeField]
    private GameObject WhitePowerup;
    [SerializeField]
    private GameObject GreenPowerup;
    [SerializeField]
    private GameObject YellowPowerup;

    [SerializeField]
    private float RedPowerupChance;
    [SerializeField]
    private float WhitePowerupChance;
    [SerializeField]
    private float GreenPowerupChance;
    [SerializeField]
    private float YellowPowerupChance;

    public Transform Spawn_ToPoint;

    public float Spawn_currentTime;
    public float Spawn_maxTime;

    public bool Powerup_Activated;

   
    public int Powerup_Duration;


    /// <summary>
    /// Requirements:
    /// Use an Array of Empty GameObjects as the spawning location for each powerup.
    /// Spawn from Array every X seconds.
    /// Set location and powerup types in children.
    /// Use this to determine firing mode?!
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        

    }

    public virtual void Spawn_Timer()
    {
        Spawn_currentTime += Time.deltaTime;

        if(Spawn_currentTime > Spawn_maxTime)
        {
            Spawn_currentTime = 0f;
            Randomize_Powerup();

        }

    }

    public virtual void Randomize_Powerup()
    {
        Spawn_ToPoint = Spawn_ListPoints[Random.Range(0, Spawn_ListPoints.Length)];
        if(Random.value <= RedPowerupChance && RedPowerup.activeInHierarchy == false)
        {   // Need to create a way for powerups to cease spawning if the slot is taken up.
            RedPowerup.SetActive(true);
            RedPowerup.transform.position = Spawn_ToPoint.position;
        }
        else if (Random.value <= YellowPowerupChance && YellowPowerup.activeInHierarchy == false)
        {
            YellowPowerup.SetActive(true);
            YellowPowerup.transform.position = Spawn_ToPoint.position;
        }
        else if (Random.value <= WhitePowerupChance && WhitePowerup.activeInHierarchy == false)
        {
            WhitePowerup.SetActive(true);
            WhitePowerup.transform.position = Spawn_ToPoint.position;
        }
         else if (Random.value <= GreenPowerupChance && GreenPowerup.activeInHierarchy == false)
        {
            GreenPowerup.SetActive(true);
            GreenPowerup.transform.position = Spawn_ToPoint.position;
        }


    }

    virtual public void ExecutePowerup(bool red, bool yellow, bool green, bool white)
    {

    }


    public virtual IEnumerator PowerupTimer(float seconds)
    {
        float counter = seconds;
        Powerup_Activated = true;
        while (paused == true)
        {
            yield return null;
        }

            while (counter > 0.0f)
            {

                counter -= Time.deltaTime;
                yield return null;
            }
            Powerup_Activated = false;
        }
    }


