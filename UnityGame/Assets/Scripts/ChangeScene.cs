using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int target;
    [SerializeField] private float time = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   
            StartCoroutine(ChangeSceneCoroutine());
        }
    }
 
    IEnumerator ChangeSceneCoroutine()
    {
        // Aplicar shader boludo
        // Sonido kripta
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(target);

    }
}
