using UnityEngine;

namespace Assets.Scripts.Entities.Spawning
{
    public abstract class SpawnPositionProvider : ScriptableObject
    {
        public abstract Vector2 GetNextSpawnPosition();
    }
}
