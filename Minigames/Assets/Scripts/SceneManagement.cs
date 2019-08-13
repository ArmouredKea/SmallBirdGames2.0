using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    [SerializeField]
    private string nextScene = "";
    public GameObject SettingMen;
    public GameObject SplashScreen;
    public GameObject MainMenu;
    public GameObject CharSelect;
    public GameObject GameLeng;
    private string CurrentScene;

    private static List<int> scenes = new List<int>(Enumerable.Range(1, 3));

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "End")
        {
            GameObject.Find("FinalScore").GetComponent<Text>().text = "[P1] " + PlayerController.p1Score + " - " + PlayerController.p2Score + " [P2]";
            Time.timeScale = 1f;
        }
        else if (scene.name == "MainMenu")
        {
            Time.timeScale = 1f;
            PlayerController.p1Score = 0;
            PlayerController.p2Score = 0;
        }
        else if (scene.name == "CharacterSelect")
        {
            PlayerController.p1Score = 0;
            PlayerController.p2Score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene()
    {
        // }
        //SceneManager.LoadScene(nextScene);
    }

    public void NextMinigame()
    {
        StartCoroutine(CharacterSelectDelay(2));
        if (scenes.Count == 0)
        {
            scenes = new List<int>(Enumerable.Range(1, 3));
            SceneManager.LoadScene("End");
        }
        else
        {
            int randomIndex = Random.Range(0, scenes.Count);
            int minigame = scenes[randomIndex] + 2;
            scenes.RemoveAt(randomIndex);
            SceneManager.LoadScene(minigame);
        }
    }

    public void NextMinigameDelay()
    {
        StartCoroutine(CharacterSelectDelay(2));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        SettingMen.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingMen.SetActive(false);
    }

    public void ScreenFade()
    {
        CurrentScene = "MainMenu";
        SplashScreen.SetActive(false);
    }

    public void Play()
    {
        MainMenu.SetActive(false);
        GameLeng.SetActive(true);
    }

    public void CharaScreen()
    {
        CharSelect.SetActive(true);
        GameLeng.SetActive(false);
    }

    public void BackToMenu()
    {
        MainMenu.SetActive(true);
        GameLeng.SetActive(false);
    }

    public void BackToleng()
    {
        GameLeng.SetActive(true);
        CharSelect.SetActive(false);
    }

    private IEnumerator CharacterSelectDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //NextScene();
        NextMinigame();
    }

}
