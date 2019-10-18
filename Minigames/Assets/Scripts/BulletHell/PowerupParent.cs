using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupParent : MonoBehaviour
{//This is actually a Manager not a parent'

    public bool paused;
    public List<Transform> Spawn_ListPoints;

    public List<Transform> Spawn_SpawnedObj = new List<Transform>();

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
    public float TimeRatio;
    public GameObject getPlayer;
    public Image powerupProg;

    public bool stopAllPowerup;
    public bool refreshDuration;

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
      if(paused == false){
        Spawn_currentTime += Time.deltaTime;

          if(Spawn_currentTime > Spawn_maxTime)
          {
              Spawn_currentTime = 0f;
              Randomize_Powerup();
          }
        }
    }

    public virtual void Randomize_Powerup()
    {//Randomly spawns powerup based on an list of empty game objects.



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




        else if (Random.value <= YellowPowerupChance && YellowPowerup.activeInHierarchy == false )
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
    { //This is passed through child scripts, using the r y g w bools to see what powerup has been hit.

    }


    public virtual IEnumerator PowerupTimer(float seconds, PC_BulletHell player, Color color)
    {//Gets projtimer, manages the fill and the powerup duration.
        powerupProg = player.transform.Find("PowerupTimeZone").GetComponentInChildren<Canvas>().transform.Find("ProjTimer").GetComponentInChildren<Image>();

        powerupProg.gameObject.SetActive(true);
        float counter = seconds;

        powerupProg.color = color;
        Powerup_Activated = true;






        while (counter > 0.0f)
        {
            TimeRatio = counter / seconds;
            powerupProg.fillAmount = TimeRatio;
            counter -= Time.deltaTime;

            if (refreshDuration == true)
            {
                seconds = Powerup_Duration;
                counter = Powerup_Duration;
                refreshDuration = false;
            }
            if (stopAllPowerup == true)
            {
                Powerup_Activated = false;
                powerupProg.gameObject.SetActive(false);
                counter = 0f;
                yield return null;
            }
            yield return null;
        }
        powerupProg.gameObject.SetActive(false);
        Powerup_Activated = false;
    }

}
