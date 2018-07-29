using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        SceneManager.sceneLoaded += this.OnLoadCallback;
        audioSource = GetComponent<AudioSource>();
	}

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode) {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];

        if (thisLevelMusic) {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void SetVolume(float volume) {
        audioSource.volume = volume;
    }

    /*   
    void OnLevelWasLoaded(int level) {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];

        if (thisLevelMusic) {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }

    }
    */
}
