using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    [SerializeField]
    private string nextScene = "";

    private static List<int> scenes = new List<int>(Enumerable.Range(1, 3));

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene() {
        SceneManager.LoadScene(nextScene);
    }

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

    public void NextMinigameDelay() {
        StartCoroutine(CharacterSelectDelay(2));
    }

    public void QuitGame() {
         Application.Quit();
    }

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
