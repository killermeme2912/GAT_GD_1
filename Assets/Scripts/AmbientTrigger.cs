using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientTrigger : MonoBehaviour
{
    public AudioSource[] audioToPlay;
    GameObject[] ambientGameObjects;
    AudioSource[] ambientAudioSources;

    //get all the ambient game objects and audio souces
    void Start()
    {
        ambientGameObjects = GameObject.FindGameObjectsWithTag("Ambient");

        List<AudioSource> tempList = new List<AudioSource>();
        foreach (GameObject go in ambientGameObjects)
        {
            tempList.Add(go.GetComponent<AudioSource>());
        }
        ambientAudioSources = tempList.ToArray();
    }

    //checks current audio playing
    AudioSource[] GetCurrentAudioSourcePlaying()
    {
        List<AudioSource> returnList = new List<AudioSource>();

        foreach(AudioSource AS in ambientAudioSources)
        {
            if (AS.isPlaying)
            {
                returnList.Add(AS);
            }
        }

        if(returnList == null)
        {
            return null;
        }

        return returnList.ToArray();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioSource[] currentSounds = GetCurrentAudioSourcePlaying();
            foreach (AudioSource AS in currentSounds) 
            {
                AS.Stop();
            }
            foreach (AudioSource AS in audioToPlay)
            {
                AS.Play();
            }
        }
    }
}
