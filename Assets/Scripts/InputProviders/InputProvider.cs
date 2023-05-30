using UnityEngine;

namespace Assets.Scripts.InputProviding
{
    public abstract class InputProvider : ScriptableObject
    {
        public abstract Vector2 GetMovementVector();

        public abstract Quaternion GetRotation();

        public abstract bool GetShootIntent();
    }

}