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


    public void PlaySex()
    {
        this.audio.PlayOneShot(this.sexwith, this.volume);
    }

    public void PlayRandomSound()
    {
        int rand = Random.Range(0, this.goofySounds.Length);
        this.audio.PlayOneShot(this.goofySounds[rand], this.volume);
    }
}