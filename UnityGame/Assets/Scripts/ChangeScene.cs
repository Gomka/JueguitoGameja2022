using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int target;
    [SerializeField] private float time = 1.0f, volume = 0.3f;
    [SerializeField] private Material mat;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip portal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   
            StartCoroutine(ChangeSceneCoroutine());
        }
    }
 
    IEnumerator ChangeSceneCoroutine()
    {
        if(mat != null) this.GetComponent<Renderer>().material = mat;
        this.audio.PlayOneShot(portal, this.volume);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(target);

    }
}
