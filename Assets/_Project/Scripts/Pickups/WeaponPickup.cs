using Spounka.Shooting;
using UnityEngine;

namespace Spounka.Pickups
{
    [CreateAssetMenu(fileName = "Weapon Pickup", menuName = "Pickups/Weapon Pickup")]
    public class WeaponPickup : PickupEffect
    {
        [SerializeField] private WeaponSO _weapon;

        public override void ApplyEffect(GameObject target)
        {
            var shooting = target.GetComponent<Shooting.Shooting>() ??
                           target.GetComponentInChildren<Shooting.Shooting>() ??
                           target.transform.parent.GetComponentInChildren<Shooting.Shooting>();
            shooting.Weapon = _weapon;
        }
    }
}