using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private Scene AScene;
    private String sceneName;


    void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    //�eby zagra� dzwi�k to trzeba wpisa� to: FindObjectOfType<AudioManager>().Play("nazwa_dzwi�ku");


    private void Start()
    {
        Play("Theme");

        
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
            
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }

        s.source.Stop();
    }

	private void Update()
	{
        AScene = SceneManager.GetActiveScene();
        sceneName = AScene.name;
        print(sceneName);

        if(sceneName == "level10")
		{
            Destroy(gameObject);
		}
        if(sceneName == "level7")
		{
            //FindObjectOfType<AudioManager>().Stop("Theme");
            Destroy(gameObject);
        }
    }

}
