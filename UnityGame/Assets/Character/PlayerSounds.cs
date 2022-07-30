using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private float volume = 0.3f;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip[] goofySounds;
    [SerializeField] private AudioClip sexwith;


    void Update()
    {
        if(Input.GetKeyDown("space") || Input.GetKeyDown("q")) {
            PlayRandomSound();
        }

        if(Input.GetKeyDown("e")) {
            audio.PlayOneShot(sexwith, volume);
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
