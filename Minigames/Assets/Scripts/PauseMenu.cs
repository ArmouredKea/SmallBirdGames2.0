using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausedMenu;
    public GameObject PauseManagerRef;
    public bool Paused;
    private string CurrentScene;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "BumperCarsMG")
        {
            CurrentScene = "BumperCars";
        }
        else if (scene.name == "OvercookedMG")
        {
            CurrentScene = "OverCooked";
        }
        else if (scene.name == "BulletHell")
        {
            CurrentScene = "BulletHell";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void togglePauseMenu()
    {
        if (Paused == false)
        {
            PausedMenu.SetActive(true);
            Paused = true;
        }
        else if (Paused == true)
        {
            PausedMenu.SetActive(false);
            Paused = false;
        }
        
    }

    public void UnPause()
    {
        if (CurrentScene == "BumperCars")
        {
            PauseManagerRef.GetComponent<Pause_BumperCars>().PauseButton();
            togglePauseMenu();
        }
        else if (CurrentScene == "OverCooked")
        {
            PauseManagerRef.GetComponent<Pause_Overcooked>().PauseButton();
            togglePauseMenu();
        }
        //else if (CurrentScene == "BulletHell")
        //{
        //PauseManagerRef.GetComponent<----insertpausescripthere---->().PauseButton();
        //togglePauseMenu();
        //}

    }
}
