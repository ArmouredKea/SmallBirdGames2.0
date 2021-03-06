﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    [SerializeField]
    private string nextScene = "";
    public static List<int> scenes = new List<int>(Enumerable.Range(1, 3));
    private static int gameLength;
    private static bool muted;
    // Start is called before the first frame update
    void Start() {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>().isMuted = muted;
    }

    // Update is called once per frame
    void Update() {
        muted = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>().isMuted;
    }

    public void NextScene() {
        SceneManager.LoadScene(nextScene);
        Destroy(GameObject.FindGameObjectWithTag("AudioManager"));
    }

    //randomly picks a minigame from the list.
    public void NextMinigame() {
        if (scenes.Count == 0 && (gameLength == 6 || gameLength == 3)) {
            gameLength--;
            scenes = new List<int>(Enumerable.Range(1, 3));
            int randomIndex = Random.Range(0, scenes.Count);
            int minigame = scenes[randomIndex] + 1;
            scenes.RemoveAt(randomIndex);
            SceneManager.LoadScene(minigame);
        } else if (scenes.Count == 0 && gameLength == 0) {
            gameLength--;
            scenes = new List<int>(Enumerable.Range(1, 3));
            SceneManager.LoadScene("End");
        } else {
            gameLength--;
            int randomIndex = Random.Range(0, scenes.Count);
            int minigame = scenes[randomIndex] + 1;
            scenes.RemoveAt(randomIndex);
            SceneManager.LoadScene(minigame);
        }
    }

    public void ShortGame() {
        gameLength = 3;
    }

    public void MediumGame() {
        gameLength = 6;
    }

    public void LongGame() {
        gameLength = 9;
    }

}
