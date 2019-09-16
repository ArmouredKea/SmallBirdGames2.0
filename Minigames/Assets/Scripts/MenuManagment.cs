using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManagment : MonoBehaviour
{

    public GameObject SettingMen;
    public GameObject SplashScreen;
    public GameObject MainMenu;
    public GameObject CharSelect;
    public GameObject GameLeng;
    public GameObject MenuButtons;
    public Image MoveTo;
    public Image TopSplash;

    //Quits the Game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Activates the settings canvas
    public void OpenSettings()
    {
        SettingMen.SetActive(true);
        MenuButtons.SetActive(false);
    }

    //Deactivates the settings Canvas
    public void CloseSettings()
    {
        SettingMen.SetActive(false);
        MenuButtons.SetActive(true);
    }

    //Changes you to the game length screen
    public void Play()
    {
        MainMenu.SetActive(false);
        GameLeng.SetActive(true);
    }

    //Transitions the tap to start screen
    public void ScreenFade()
    {
      SplashScreen.SetActive(false);

    }

    //loads the character select screen
    public void CharaScreen()
    {
        CharSelect.SetActive(true);
        GameLeng.SetActive(false);
    }

    //takes you back to the main menu from the game length screen
    public void BackToMenu()
    {
        MainMenu.SetActive(true);
        GameLeng.SetActive(false);
    }

    //takes you back to the game length screen
    public void BackToleng()
    {
        GameLeng.SetActive(true);
        CharSelect.SetActive(false);
    }
}
