using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupParent : MonoBehaviour
<<<<<<< Updated upstream
{//This is actually a Manager not a parent'
    public Transform[] Spawn_ListPoints;
=======
{
    public bool paused;
    public List<Transform> Spawn_ListPoints;

    public List<Transform> Spawn_SpawnedObj = new List<Transform>();
>>>>>>> Stashed changes

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
    /// Get list of positions
    /// Figure out if a position is already filled by a powerup
    /// Probably easier to just do a 1234 check
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

      

        if (Random.value <= RedPowerupChance && RedPowerup.activeInHierarchy == false )
        {   // Need to create a way for powerups to cease spawning if the slot is taken up.
            if (!Spawn_SpawnedObj.Contains(Spawn_ToPoint))
            {
                RedPowerup.SetActive(true);
                RedPowerup.transform.position = Spawn_ToPoint.position;
                RedPowerup.GetComponent<PowerupCheck>().Position_current = Spawn_ToPoint;
                Spawn_SpawnedObj.Add(Spawn_ToPoint);
            }
            else
            {
                Spawn_Control();
            }
        }

            


        else if (Random.value <= YellowPowerupChance && YellowPowerup.activeInHierarchy == false)
        {
            if (!Spawn_SpawnedObj.Contains(Spawn_ToPoint))
            {
                YellowPowerup.SetActive(true);
                YellowPowerup.transform.position = Spawn_ToPoint.position;
                YellowPowerup.GetComponent<PowerupCheck>().Position_current = Spawn_ToPoint;
                Spawn_SpawnedObj.Add(Spawn_ToPoint);
            }
            else
            {
                Spawn_Control();
            }
        }

        
         
      
        else if (Random.value <= WhitePowerupChance && WhitePowerup.activeInHierarchy == false)
        {
            if (!Spawn_SpawnedObj.Contains(Spawn_ToPoint))
            {
                WhitePowerup.SetActive(true);
                WhitePowerup.transform.position = Spawn_ToPoint.position;
                Spawn_SpawnedObj.Add(Spawn_ToPoint);
                WhitePowerup.GetComponent<PowerupCheck>().Position_current = Spawn_ToPoint;
            }
            else
            {
                Spawn_Control();
            }
        }
        else if (Random.value <= GreenPowerupChance && GreenPowerup.activeInHierarchy == false )
        {
            if (!Spawn_SpawnedObj.Contains(Spawn_ToPoint))
            {
                GreenPowerup.SetActive(true);
                GreenPowerup.transform.position = Spawn_ToPoint.position;
                Spawn_SpawnedObj.Add(Spawn_ToPoint);
                GreenPowerup.GetComponent<PowerupCheck>().Position_current = Spawn_ToPoint;
            }
            else
            {
                Spawn_Control();
            }
        }

    }

    public virtual void Spawn_Control()
    {
        Spawn_ToPoint = Spawn_ListPoints[Random.Range(0, Spawn_ListPoints.Count)];
    }

    virtual public void ExecutePowerup(bool red, bool yellow, bool green, bool white)
    {

    }


    public virtual IEnumerator PowerupTimer(float seconds)
    {
        float counter = seconds;
        Powerup_Activated = true;
        while (counter > 0.0f)
        {

            counter -= Time.deltaTime;
            yield return null;
        }
        Powerup_Activated = false;
    }

}
