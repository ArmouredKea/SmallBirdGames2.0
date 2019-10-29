using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleTimer : MonoBehaviour
{

    public float currentTime = 300f;

    // Start is called before the first frame update
    void OnEnable() {
        currentTime = 300f;
    }

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
