using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManagment : MonoBehaviour
{

    public GameObject audioManager;
    public GameObject SettingMen;
    public GameObject SplashScreen;
    public CanvasGroup SplashScreenFade;
    public GameObject MainMenu;
    public GameObject CharSelect;
    public GameObject GameLeng;
    public GameObject MenuButtons;
    public GameObject MuteBTN;
    public GameObject UnMuteBTN;
    public GameObject settingsButton;
    public GameObject credits;
    public GameObject BackgroundTop;
    public CanvasGroup AllMenuButtons;
    public GameObject AllMenuButtonsRef;
    public GameObject MenuBlocker;
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 5.0f;
    private float startTime;
    private float journeyLength;
    public bool Started = false;
    bool logoFade = true;


    void Start() {
      audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    void Update() {
        //changes the state of the mute button depending on if the music is muted
      if (audioManager.GetComponent<AudioManagerScript>().isMuted) {
          MuteBTN.SetActive(false);
          UnMuteBTN.SetActive(true);
      } else if (audioManager.GetComponent<AudioManagerScript>().isMuted == false) {
          MuteBTN.SetActive(true);
          UnMuteBTN.SetActive(false);
      }
      MoveBackground();
    }

    void MoveBackground()
    {
        //pans the background image up to the end point object
        if (Started == true)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            BackgroundTop.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        }
        else {
            Started = false;
        }
    }

    //Quits the Game
    public void QuitGame() {
        Application.Quit();
    }

    //Activates the settings canvas
    public void OpenSettings() {
        SettingMen.SetActive(true);
        MenuButtons.SetActive(false);
    }

    //Deactivates the settings Canvas
    public void CloseSettings() {
        SettingMen.SetActive(false);
        MenuButtons.SetActive(true);
    }

    //Changes you to the game length screen
    public void Play() {
        MainMenu.SetActive(false);
        GameLeng.SetActive(true);
    }

    //Transitions the tap to start screen
    public void ScreenFade() {
        MenuBlocker.SetActive(true);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        StartCoroutine(logoFadeRoutine(SplashScreenFade, SplashScreenFade.alpha, 0));
        SplashScreen.SetActive(false);
        Started = true;
        StartCoroutine(buttonsShowUp(AllMenuButtons, AllMenuButtons.alpha, 1));
    }

    //this co routine handdles the fadding on of the menu buttons
    IEnumerator buttonsShowUp(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        //waits before starting to fade
        yield return new WaitForSeconds(2);
        AllMenuButtonsRef.SetActive(true);


        float timeStartedLerping = Time.time;
        float timesincestarting = Time.time - timeStartedLerping;
        float percentageComplete = timesincestarting / lerpTime;

        //figures out how long the fade has been going for and stops it when it gets to full opacity
        while(true) {
            timesincestarting = Time.time - timeStartedLerping;
            percentageComplete = timesincestarting / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
        
        MenuBlocker.SetActive(false);
    }

    //this co routine handdles the fadding out of the logo
    IEnumerator logoFadeRoutine(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {

        float timeStartedLerping = Time.time;
        float timesincestarting = Time.time - timeStartedLerping;
        float percentageComplete = timesincestarting / lerpTime;

        //figures out how long the fade has been going for and stops it when it gets to full opacity
        while (true)
        {
            timesincestarting = Time.time - timeStartedLerping;
            percentageComplete = timesincestarting / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }

    //loads the character select screen
    public void CharaScreen() {
        CharSelect.SetActive(true);
        GameLeng.SetActive(false);
    }

    //takes you back to the main menu from the game length screen
    public void BackToMenu() {
        MainMenu.SetActive(true);
        GameLeng.SetActive(false);
    }

    //takes you back to the game length screen
    public void BackToleng() {
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
