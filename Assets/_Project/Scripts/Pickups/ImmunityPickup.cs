using Spounka.Core.DataTypes;
using UnityEngine;

namespace Spounka.Pickups
{
    [CreateAssetMenu(fileName = "Immunity Pickup", menuName = "Pickups/Immunity Pickup")]
    public class ImmunityPickup : PickupEffect
    {
        public float amount;
        public VariableReference<float> _playerInfectionValue;

        public override void ApplyEffect(GameObject target)
        {
            if (_playerInfectionValue.Value > 0)
                _playerInfectionValue.Value -= amount;
            if (_playerInfectionValue.Value < 0)
                _playerInfectionValue.Value = 0;
        }
    }
}