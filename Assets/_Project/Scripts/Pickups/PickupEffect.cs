using UnityEngine;

namespace Spounka.Pickups
{
    public abstract class PickupEffect : ScriptableObject
    {
        public abstract void ApplyEffect(GameObject target);
    }
}