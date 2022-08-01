using System.Collections;
using System.Collections.Generic;
using Character;
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
        this.UiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Movement movement)) return;
        this.UiObject.GetComponentInChildren<TMP_Text>().SetText(this.name);
        this.UiObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out Movement movement)) return;
        this.UiObject.SetActive(false);
    }
}