using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonBranchingDialogue : MonoBehaviour
{
    public float radius;
    public AudioClip[] clips;
    AudioSource audioSource;

    int _audioPos = 0;
    public int audioPos
    {
        get { return _audioPos; }
        set
        {
            if(value >= clips.Length)
            {
                value = clips.Length - 1;
            }
            _audioPos = value;
        }
    }


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                if(Input.GetKeyDown(KeyCode.E)) { PlayNextAudioClip(); }
            }
        }
    }

    void PlayNextAudioClip()
    {
        audioSource.clip = clips[audioPos];
        audioSource.Play();
        audioPos++;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
