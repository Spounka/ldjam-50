using UnityEngine;

namespace Spounka
{
    public class EnemyMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _movementSpeed = 3.0f, _distanceThreshold = 1.5f;
        [SerializeField] private Transform _target = null;

        private Transform _transform = null;
        private Rigidbody2D _rb = null;
        private EnemyAttack _attack;
        private HealthSystem enemyHealth;

        #endregion

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _attack = GetComponent<EnemyAttack>();
            _transform = transform;
            enemyHealth = _target.GetComponent<HealthSystem>();
        }

        private void FixedUpdate()
        {
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            if (Vector2.Distance(_target.position, _transform.position) < _distanceThreshold)
            {
                _attack.Attack(enemyHealth);
                return;
            }

            var direction = (Vector2)(_target.position - _transform.position).normalized;
            var velocity = direction * _movementSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(_rb.position + velocity);
        }
    }
}