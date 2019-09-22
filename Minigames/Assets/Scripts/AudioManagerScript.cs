using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    [Serializable]
    public class StringAudioClipDictionary : SerializableDictionary<string, AudioClip> {}

    public StringAudioClipDictionary soundsDicitonary;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start() {
      audioSource = gameObject.GetComponent<AudioSource>();
      foreach (AudioClip ac in Resources.LoadAll("", typeof(AudioClip))) {
        string audioName = ac.name;
        soundsDicitonary.Add(audioName, ac);
      }
    }

    public void PlayAudio(string clipName) {

      AudioClip temp = null;

      if (soundsDicitonary.TryGetValue(clipName, out temp)) {
        audioSource.clip = temp;
      }
      audioSource.Play(0);
    }
}
