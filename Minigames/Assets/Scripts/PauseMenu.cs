using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausedMenu;
    public GameObject PauseManagerRef;
    public GameObject AreYouSure;
    public GameObject mutebutton;
    public GameObject unmutebutton;
    public bool Paused;
    private string CurrentScene;

    // Start is called before the first frame update
    void Start() {
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

    // Update is called once per frame
    void Update() {

    }

    public void togglePauseMenu() {
        if (Paused == false) {
            PausedMenu.SetActive(true);
            Paused = true;
        }
        else if (Paused == true) {
            PausedMenu.SetActive(false);
            Paused = false;
        }

    }

    public void BackToMainCheck() {
        AreYouSure.SetActive(true);
    }

    public void CloseAlert() {
        AreYouSure.SetActive(false);
    }

    public void BackToMenu() {
        AreYouSure.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void MuteSound() {
        mutebutton.SetActive(false);
        unmutebutton.SetActive(true);
    }

    public void unMuteSound() {
        unmutebutton.SetActive(false);
        mutebutton.SetActive(true);
    }

    public void UnPause() {
        if (CurrentScene == "BumperCars") {
            PauseManagerRef.GetComponent<Pause_BumperCars>().PauseButton();
            togglePauseMenu();
        }
        else if (CurrentScene == "OverCooked") {
            PauseManagerRef.GetComponent<Pause_Overcooked>().PauseButton();
            togglePauseMenu();
        }
        else if (CurrentScene == "BulletHell") {
            PauseManagerRef.GetComponent<Pause_BulletHell>().PauseButton();
            togglePauseMenu();
        }

    }
}
