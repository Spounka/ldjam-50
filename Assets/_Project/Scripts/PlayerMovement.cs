using UnityEngine;

namespace Spounka
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationOffset;

        private Vector2 input;
        private Camera _camera;
        private Transform _transform;

        private void Start()
        {
            _camera = Camera.main ? Camera.main : Camera.current;
            _transform = transform;
        }

        private void Update()
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            Move();
            RotateToMouse();
        }

        private void Move()
        {
            var direction = input.normalized;
            var velocity = direction * _movementSpeed * Time.deltaTime;
            _transform.position += _transform.rotation * velocity;
        }

        private void RotateToMouse()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var difference = (mousePosition - _transform.position).normalized;
            var angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.Euler(0, 0, angle + _rotationOffset);
        }
    }
}