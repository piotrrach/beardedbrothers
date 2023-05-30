using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SriptableVariables
{
    [CreateAssetMenu(fileName = "New Random Sprite Variable", menuName = "Scriptable Variables/Random Sprite Variable")]
    public class RandomSprite : SpriteVariable
    {
        [SerializeField]
        private Sprite[] _spritesPool;

        public override Sprite Value { get => GetRandomSprite(); }

        private Sprite GetRandomSprite()
        {
            int randomIndex = UnityEngine.Random.Range(0, _spritesPool.Length);
            return _spritesPool[randomIndex];
        }

    }
}
