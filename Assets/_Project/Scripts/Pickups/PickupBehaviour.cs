using System;
using UnityEngine;

namespace Spounka.Pickups
{
    public class PickupBehaviour : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PickupEffect _pickupEffect;

        #endregion

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
                _pickupEffect.ApplyEffect(col.gameObject);
            Destroy(gameObject);
        }
    }
}