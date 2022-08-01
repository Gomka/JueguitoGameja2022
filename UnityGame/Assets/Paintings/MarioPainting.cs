using System;
using System.Collections;
using Character;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Paintings
{
    [RequireComponent(typeof(BoxCollider))]
    public class MarioPainting : MonoBehaviour
    {
        [Serializable]
        private class SpriteRendererNullable
        {
            public SpriteRenderer spriteRenderer;
        }

        [SerializeField] private SpriteRendererNullable _spriteRendererNullable;
        public string sceneName;
        [SerializeField] private AudioSource audio;
        [SerializeField] private AudioClip portal;
        [SerializeField] private float time = 1.0f;
        [SerializeField] private float volume = 0.3f;
        [SerializeField] private Material mat;

        private bool _entered;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("xd");
            if (this._entered) return;
            Debug.Log("xd");

            if (!other.TryGetComponent(out Movement cc)) return;
            Debug.Log("xd");

            this._entered = true;
            this._spriteRendererNullable.spriteRenderer.material = this.mat;
            this._spriteRendererNullable.spriteRenderer.material.SetInteger("_Secondary", 1);
            this._spriteRendererNullable.spriteRenderer.material.SetFloat("_RippleStrength", 1);
            Debug.Log("xd");

            StartCoroutine(ChangeSceneCoroutine());
        }

        IEnumerator ChangeSceneCoroutine()
        {
            this.audio.PlayOneShot(portal, this.volume);
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(this.sceneName);
        }
    }
}