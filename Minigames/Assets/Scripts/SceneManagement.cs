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
    private static List<int> scenes = new List<int>(Enumerable.Range(1, 3));

    // Start is called before the first frame update
    void Start() {

        //checks for current scene.
        Scene scene = SceneManager.GetActiveScene();
        
        if (scene.name == "End") {
            GameObject.Find("FinalScore").GetComponent<Text>().text = "[P1] " + PlayerController.p1Score + " - " + PlayerController.p2Score + " [P2]";
            Time.timeScale = 1f;
        } else if (scene.name == "MainMenu") {
            Time.timeScale = 1f;
            PlayerController.p1Score = 0;
            PlayerController.p2Score = 0;
        }

    }

    // Update is called once per frame
    void Update() {

    }

    //changes scene depending on what you type on the variable "nextScene".
    public void NextScene() {

        SceneManager.LoadScene(nextScene);

    }

    //changes scene for minigames. Makes sure to randomise minigames
    //and prevents repetitions of minigames
    public void NextMinigame() {

        if (scenes.Count == 0) {
            scenes = new List<int>(Enumerable.Range(1, 3));
            SceneManager.LoadScene("End");
        } else {
            int randomIndex = Random.Range(0, scenes.Count);
            int minigame = scenes[randomIndex] + 2;
            scenes.RemoveAt(randomIndex);
            SceneManager.LoadScene(minigame);
        }

    }

    //delays the changing of scenes.
    public void NextMinigameDelay() {

        StartCoroutine(CharacterSelectDelay(2));

    }

    //it....... quits the game.
    public void QuitGame() {

         Application.Quit();

    }

    //Includes a delay after selction in the character select scene.
    private IEnumerator CharacterSelectDelay(float waitTime) {

        yield return new WaitForSeconds(waitTime);

        if (scenes.Count == 0) {
            scenes = new List<int>(Enumerable.Range(1, 3));
            SceneManager.LoadScene("End");
        } else {
            int randomIndex = Random.Range(0, scenes.Count);
            int minigame = scenes[randomIndex] + 2;
            scenes.RemoveAt(randomIndex);
            SceneManager.LoadScene(minigame);
        }

    }

}
