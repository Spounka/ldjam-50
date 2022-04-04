using Spounka.Core.Event;
using UnityEngine;

namespace Spounka.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameEvent _playerHurt;

        [SerializeField] private int _damageAmount;
        [SerializeField] private float _attackRate;
        private float timer = 0.0f;

        #endregion

        private void Update()
        {
            if (timer > 0)
                timer -= Time.deltaTime;
        }

        public void Attack(HealthSystem target)
        {
            if (timer > 0)
                return;
            target.TakeDamage(_damageAmount);
            timer = _attackRate;
            _playerHurt.Raise();
        }
    }
}