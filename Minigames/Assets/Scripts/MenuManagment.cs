using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManagment : MonoBehaviour
{

    public GameObject audioManager;
    private GameObject musicSource;

    public GameObject SettingMen;
    public GameObject SplashScreen;
    public GameObject MainMenu;
    public GameObject CharSelect;
    public GameObject GameLeng;
    public GameObject MenuButtons;
    public GameObject MuteBTN;
    public GameObject UnMuteBTN;
    public GameObject settingsButton;
    public GameObject credits;

    void Start() {
      audioManager = GameObject.FindGameObjectWithTag("AudioManager");
      musicSource = GameObject.FindGameObjectWithTag("Music");
    }

    void Update() {
      if (audioManager.GetComponent<AudioManagerScript>().isMuted) {
          MuteBTN.SetActive(false);
          UnMuteBTN.SetActive(true);
          musicSource.GetComponent<AudioSource>().mute = true;
      } else if (audioManager.GetComponent<AudioManagerScript>().isMuted == false) {
          MuteBTN.SetActive(true);
          UnMuteBTN.SetActive(false);
          musicSource.GetComponent<AudioSource>().mute = false;
      }
    }

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

    public void mute(){
            MuteBTN.SetActive(false);
            UnMuteBTN.SetActive(true);
            audioManager.GetComponent<AudioManagerScript>().isMuted = true;
            audioManager.GetComponent<AudioManagerScript>().MuteAudio();
    }

    public void Unmute(){
        MuteBTN.SetActive(true);
        UnMuteBTN.SetActive(false);
        audioManager.GetComponent<AudioManagerScript>().isMuted = false;
        audioManager.GetComponent<AudioManagerScript>().UnMuteAudio();
    }

    public void Credits() {
        MenuButtons.SetActive(false);
        settingsButton.SetActive(false);
        credits.SetActive(true);
    }

    public void closeCredits() {
        MenuButtons.SetActive(true);
        settingsButton.SetActive(true);
        credits.SetActive(false);
    }
}
