using UnityEngine;

namespace Spounka.Enemy
{
    public class EnemyMovement
    {
        #region Variables

        private readonly float _movementSpeed;

        private readonly Transform _target = null;
        private readonly Rigidbody2D _rb = null;
        private readonly Transform _transform = null;

        #endregion

        public EnemyMovement(Rigidbody2D rb, Transform target, Transform transform, float movementSpeed)
        {
            _rb = rb;
            _target = target;
            _movementSpeed = movementSpeed;
            _transform = transform;
        }

        public void MoveToTarget()
        {
            var direction = (Vector2)(_target.position - _transform.position).normalized;
            var velocity = direction * _movementSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(_rb.position + velocity);
        }
    }
}