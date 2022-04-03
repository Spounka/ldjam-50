using Spounka.Core.DataTypes;
using UnityEngine;

namespace Spounka
{
    public class HealthSystem : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private bool _destroyOnHealthZero;

        [SerializeField] private VariableReference<int> _currentHealth;

        public int MaxHealth => _maxHealth;

        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth.Value = value;
        }

        #endregion

        private void Awake()
        {
            _currentHealth.Value = _maxHealth;
        }

        public void TakeDamage(int damageAmount)
        {
            _currentHealth.Value -= damageAmount;
            if (_currentHealth > 0) return;

            _currentHealth.Value = 0;
            if (_destroyOnHealthZero)
                Destroy(gameObject);
        }
    }
}