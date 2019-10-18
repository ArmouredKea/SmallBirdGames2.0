using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject audioManager;

    public GameObject PausedMenu;
    public GameObject PauseManagerRef;
    public GameObject AreYouSure;
    public GameObject mutebutton;
    public GameObject unmutebutton;
    public GameObject threeSecPause;
    public GameObject countdownRef;
    public GameObject Pausebuttonref;
    public GameObject SubPauseMenu;
    public bool Paused;
    private string CurrentScene;
    public GameObject scoreTextbox;
    public bool tutorial = true;

    // sets audiomanager and checks what scene you are in
    void Start() {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "BumperCarsMG") {
            CurrentScene = "BumperCars";
        }
        else if (scene.name == "OvercookedMG") {
            CurrentScene = "OverCooked";
        }
        else if (scene.name == "BulletHell") {
            CurrentScene = "BulletHell";
        }
    }

    // manages muting for audio
    void Update() {
      if (audioManager.GetComponent<AudioManagerScript>().isMuted) {
          mutebutton.SetActive(false);
          unmutebutton.SetActive(true);
      } else if (audioManager.GetComponent<AudioManagerScript>().isMuted == false) {
        mutebutton.SetActive(true);
        unmutebutton.SetActive(false);
      }
    }

    //turning the pause menu on and off
    public void togglePauseMenu() {
        if (Paused == false && scoreTextbox.activeSelf == false) {
            PausedMenu.SetActive(true);
            Paused = true;
        }
        else if (Paused == true && scoreTextbox.activeSelf == false) {
            PausedMenu.SetActive(false);
            Paused = false;
        }

    }

    public void BackToMainCheck() {
        AreYouSure.SetActive(true);
        SubPauseMenu.SetActive(false);
    }

    public void CloseAlert() {
        AreYouSure.SetActive(false);
        SubPauseMenu.SetActive(true);
    }

    public void BackToMenu() {
        AreYouSure.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        Destroy(audioManager);
    }

    public void MuteSound() {
            mutebutton.SetActive(false);
            unmutebutton.SetActive(true);
            audioManager.GetComponent<AudioManagerScript>().isMuted = true;
            audioManager.GetComponent<AudioManagerScript>().MuteAudio();
    }

    public void unMuteSound() {
            unmutebutton.SetActive(false);
            mutebutton.SetActive(true);
            audioManager.GetComponent<AudioManagerScript>().isMuted = false;
            audioManager.GetComponent<AudioManagerScript>().UnMuteAudio();
    }

    public void UnPause() {
        if (CurrentScene == "BumperCars") {
            PauseManagerRef.GetComponent<Pause_BumperCars>().PauseButton();
            if (!tutorial) {
                countdownRef.SetActive(true);
                Pausebuttonref.SetActive(false);
                threeSecPause.GetComponent<CountdownTimer>().closeTutorial();
                togglePauseMenu();
            }
        }
        else if (CurrentScene == "OverCooked") {
            PauseManagerRef.GetComponent<Pause_Overcooked>().PauseButton();
            if (!tutorial) {
                countdownRef.SetActive(true);
                Pausebuttonref.SetActive(false);
                threeSecPause.GetComponent<Pause_Overcooked>().closeTutorial();
                togglePauseMenu();
            }
        }
        else if (CurrentScene == "BulletHell") {
            PauseManagerRef.GetComponent<Pause_BulletHell>().PauseButton();
            if (!tutorial) {
                countdownRef.SetActive(true);
                Pausebuttonref.SetActive(false);
                threeSecPause.GetComponent<Score_BulletHell>().closeTutorial();
                togglePauseMenu();
            }
        }

    }
}
