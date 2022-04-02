using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spounka
{
    public class HealthSystem : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _maxHealth;
        private int _currentHealth;

        #endregion

        public void TakeDamage(int damageAmount)
        {
            _currentHealth -= damageAmount;
        }
    }
}