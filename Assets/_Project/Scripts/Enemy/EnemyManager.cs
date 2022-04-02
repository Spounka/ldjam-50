using UnityEngine;

namespace Spounka.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _movementSpeed, _distanceThreshold = 1.5f;

        private HealthSystem enemyHealth;
        private EnemyAttack _attack;
        private Transform _target = null;
        private Transform _transform = null;
        private EnemyMovement _enemyMovement;

        #endregion

        private bool isCloseToTarget => Vector2.Distance(_target.position, _transform.position) < _distanceThreshold;


        private void Awake()
        {
            _transform = transform;
            _target = GameObject.FindGameObjectWithTag("Player").transform;

            enemyHealth = _target.GetComponent<HealthSystem>();
            _attack = GetComponent<EnemyAttack>();
            var rb = GetComponent<Rigidbody2D>();
            _enemyMovement = new EnemyMovement(rb, _target, _transform, _movementSpeed);
        }

        private void Update()
        {
            if (isCloseToTarget)
                _attack.Attack(enemyHealth);
        }

        private void FixedUpdate()
        {
            if (!isCloseToTarget)
                _enemyMovement.MoveToTarget();
        }
    }
}