using UnityEngine;

namespace Spounka
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationOffset;
        [SerializeField] private float _rotationSpeed;

        private Vector2 input;
        private Camera _camera;
        private Transform _transform;

        private Rigidbody2D _rb;

        private void Start()
        {
            _camera = Camera.main ? Camera.main : Camera.current;
            _transform = transform;
            _rb = GetComponent<Rigidbody2D>() ?? GetComponentInChildren<Rigidbody2D>();
        }

        private void Update()
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            Move();
            RotateToMouse();
        }

        private void Move()
        {
            var direction = input.normalized;
            var velocity = direction * _movementSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(_rb.position + (Vector2)(_transform.rotation * velocity));
        }

        private void RotateToMouse()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var difference = (mousePosition - _transform.position).normalized;
            var angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            _rb.MoveRotation(angle + _rotationOffset);
        }
    }
}