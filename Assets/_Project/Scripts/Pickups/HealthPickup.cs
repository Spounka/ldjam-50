using UnityEngine;

namespace Spounka.Pickups
{
    [CreateAssetMenu(fileName = "HealthPickup", menuName = "Pickups/Health")]
    public class HealthPickup : PickupEffect
    {
        public int amount;

        public override void ApplyEffect(GameObject target)
        {
            var healthSystem = target.GetComponentInParent<HealthSystem>() ?? target.GetComponent<HealthSystem>();
            if (healthSystem.CurrentHealth <= healthSystem.MaxHealth)
                healthSystem.CurrentHealth += amount;
        }
    }
}