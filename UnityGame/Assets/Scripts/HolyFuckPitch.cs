using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyFuckPitch : MonoBehaviour
{


    // Update is called once per frame
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        audioSource.pitch = Random.Range(0.5f, 1.5f);
    }
}
