using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spounka
{
    public class HealthSystem : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;

        public int MaxHealth => _maxHealth;

        public int CurrentHealth => _currentHealth;

        #endregion

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damageAmount)
        {
            _currentHealth -= damageAmount;
            if (_currentHealth <= 0)
                _currentHealth = 0;
        }
    }
}