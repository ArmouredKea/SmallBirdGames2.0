using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManagment : MonoBehaviour
{

    public GameObject settingmen;
    public GameObject splashscreen;
    public GameObject mainmenu;
    public GameObject charselect;
    public GameObject gameleng;
    public Image moveto;
    public Image topsplash;

    //Quits the Game
    public void QuitGame() {
        Application.Quit();
    }

    //Activates the settings canvas
    public void OpenSettings() {
        settingmen.SetActive(true);
    }

    //Deactivates the settings Canvas
    public void CloseSettings() {
        settingmen.SetActive(false);
    }

    //Changes you to the game length screen
    public void Play() {
        mainmenu.SetActive(false);
        gameleng.SetActive(true);
    }

    //Transitions the tap to start screen
    public void ScreenFade() {
      splashscreen.SetActive(false);

    }

    //loads the character select screen
    public void CharaScreen() {
        charselect.SetActive(true);
        gameleng.SetActive(false);
    }

    //takes you back to the main menu from the game length screen
    public void BackToMenu() {
        mainmenu.SetActive(true);
        gameleng.SetActive(false);
    }

    //takes you back to the game length screen
    public void BackToleng() {
        gameleng.SetActive(true);
        charselect.SetActive(false);
    }
}
