using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTestScript : MonoBehaviour
{
    public GameObject audioManager;

    // Start is called before the first frame update
    void Start() {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        audioManager.GetComponent<AudioManagerScript>().musicSource = GameObject.FindGameObjectWithTag("Music");
    }

}
