using UnityEngine;

namespace Paintings
{
    [RequireComponent(typeof(BoxCollider))]
    public class MarioPainting : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public string sceneName;
    }
}