using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextoMagico : MonoBehaviour
{
    public GameObject UiObject;
    public GameObject cube;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UiObject.GetComponentInChildren<TMP_Text>().SetText(name);
            UiObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        UiObject.SetActive(false);
    }
}
