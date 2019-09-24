using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTestScript : MonoBehaviour
{

    public GameObject audioManager;
    private float start = 1f;
    public float timer;
    public string test;
    private string eo = "EO";
    private string three = "321";
    private string draw = "Draw";
    private string pathetic = "Pathetic";
    private string eugh = "EUGH";

    public List<string> soundList = new List<string>();

    // Start is called before the first frame update
    void Start() {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        soundList.Add(eo);
        soundList.Add(three);
        soundList.Add(draw);
        soundList.Add(pathetic);
        soundList.Add(eugh);
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= start) {
            test = (soundList[(Random.Range(0,soundList.Count))]);
            audioManager.GetComponent<AudioManagerScript>().PlayAudio(test);
            timer = 0;
        }
    }
}
