using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource coinSound;
    public AudioSource chestSound;
    public AudioSource engine;
    public AudioSource debuff;

    public AudioSource currentTrack;
    public AudioSource[] tracks;

    void Start()
    {
        currentTrack = tracks[Random.Range(0, tracks.Length)];
        currentTrack.Play();
    }
    void Update()
    {
        if(Time.timeScale != 0 && !currentTrack.isPlaying)
        {
            currentTrack = tracks[Random.Range(0, tracks.Length)];
            currentTrack.Play();
            Debug.Log("new track");
        }
    }
    public void PauseLoops()
    {
        engine.Pause();
        currentTrack.Pause();
    }
    public void ResumeLoops()
    {
        engine.UnPause();
        currentTrack.UnPause();
    }
}
