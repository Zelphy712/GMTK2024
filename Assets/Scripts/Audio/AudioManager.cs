using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    public Sound [] musicSounds, sfxSounds;
    [SerializeField]
    public AudioSource musicSource, sfxSource;


    private void Awake(){
        if(Instance == null){
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    private void Start(){
        // Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene ();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;
        if(sceneName == "GameplayScene"){
            PlayMusic("Level Theme");
        }else if(sceneName == "StartMenu" || sceneName == "Credits"){
            PlayMusic("Title Screen");
        }else if(sceneName == "EndGame"){
            PlayMusic("Boss Theme");
        }
    }

    public void PlayMusic(string name){
        Sound s = Array.Find(musicSounds, x => x.soundName == name);

        if(s == null){
            Debug.Log("Sound " + name + " not found.");
        }else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySfx(string name){
        Sound s = Array.Find(sfxSounds, x => x.soundName == name);

        if(s == null){
            Debug.Log("Sound " + name + " not found.");
        }else{
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic(){
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSfx(){
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SfxVolume(float volume){
        sfxSource.volume = volume;
    }
}
