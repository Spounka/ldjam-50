using Spounka.Core.DataTypes;
using UnityEngine;

namespace Spounka.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private VariableReference<float> _movementSpeed, _distanceThreshold;
        [SerializeField] private VariableReference<float> _infectionChance;
        [SerializeField] private VariableReference<bool> _isPlayerInfected;


        private HealthSystem _targetHealth;
        private EnemyAttack _attack;
        private Transform _target = null;
        private Transform _transform = null;
        private EnemyMovement _enemyMovement;

        #endregion

        private bool isCloseToTarget =>
            Vector2.Distance(_target.position, _transform.position) < _distanceThreshold;


        private void Awake()
        {
            _transform = transform;
            _target = GameObject.FindGameObjectWithTag("Player").transform;

            _targetHealth = _target.GetComponent<HealthSystem>();
            _attack = GetComponent<EnemyAttack>();
            var rb = GetComponent<Rigidbody2D>();
            _enemyMovement = new EnemyMovement(rb, _target, _transform, _movementSpeed);
        }

        private void Update()
        {
            if (!isCloseToTarget) return;
            _attack.Attack(_targetHealth);
            if (Random.Range(0, 1) <= _infectionChance && !_isPlayerInfected.Value)
                _isPlayerInfected.Value = true;
        }

        private void FixedUpdate()
        {
            if (!isCloseToTarget)
                _enemyMovement.MoveToTarget();
        }
    }
}