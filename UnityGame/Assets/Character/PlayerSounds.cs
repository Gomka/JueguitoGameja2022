using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private float volume = 0.3f;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip[] goofySounds;


    void Update()
    {
        if(Input.GetKeyDown("e") || Input.GetKeyDown("space") || Input.GetKeyDown("q")) {
            PlayRandomSound();
        }

        if(Input.GetKey("r")) { //chaos
            PlayRandomSound();
        }

    }

    void PlayRandomSound()
    {         
        int rand = Random.Range(0,goofySounds.Length);
        Debug.Log(rand); 
        audio.PlayOneShot(goofySounds[rand], volume);
    }
}
