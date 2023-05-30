using Assets.Scripts.SriptableVariables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Misc
{
    [RequireComponent(typeof(SpriteRenderer))]      
    public class SpriteRendererSetter : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private SpriteVariable _spriteVariable;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _spriteRenderer.sprite = _spriteVariable.Value;
        }
    }
}