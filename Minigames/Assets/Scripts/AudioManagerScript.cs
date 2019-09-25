using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    [Serializable]
    public class StringAudioClipDictionary : SerializableDictionary<string, AudioClip> {}

    public StringAudioClipDictionary soundsDicitonary;
    //test
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource audioSource5;

    public bool isMuted;
    // Start is called before the first frame update
    void Awake() {
      foreach (AudioClip ac in Resources.LoadAll("", typeof(AudioClip))) {
        string audioName = ac.name;
        soundsDicitonary.Add(audioName, ac);
      }

      DontDestroyOnLoad(this.gameObject);
    }

    public void PlayAudio(string clipName) {

      AudioClip temp = null;
      if (soundsDicitonary.TryGetValue(clipName, out temp)) {
        if (audioSource1.isPlaying == false) {
            audioSource1.clip = temp;
            audioSource1.Play(0);
        } else if (audioSource2.isPlaying == false) {
            audioSource2.clip = temp;
            audioSource2.Play(0);
        } else if (audioSource3.isPlaying == false) {
            audioSource3.clip = temp;
            audioSource3.Play(0);
        } else if (audioSource4.isPlaying == false) {
            audioSource4.clip = temp;
            audioSource4.Play(0);
        } else if (audioSource5.isPlaying == false) {
            audioSource5.clip = temp;
            audioSource5.Play(0);
        }
      }
    }

    public void MuteAudio() {
        foreach (Transform child in transform) {
            child.GetComponent<AudioSource>().mute = true;
        }
    }
    public void UnMuteAudio() {
      foreach (Transform child in transform) {
          child.GetComponent<AudioSource>().mute = false;
      }
    }
}
