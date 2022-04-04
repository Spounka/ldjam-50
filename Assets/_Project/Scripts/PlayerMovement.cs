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
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = !Cursor.visible;
            }
        }

        private void FixedUpdate()
        {
            Move();
            RotateToMouse();
        }

        private void Move()
        {
            // var directionX = input.x * Vector2.right;
            // var directionY = input.y * Vector2.up;
            // var upVelocity = _transform.rotation * directionY;
            // var velocity = new Vector2(directionX.x, upVelocity.y) * _movementSpeed * Time.fixedDeltaTime;
            // _rb.MovePosition(_rb.position + velocity);
            var direction = input.normalized;
            var velocity = direction * _movementSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(_rb.position + velocity);
        }

        private void RotateToMouse()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var difference = (mousePosition - _transform.position).normalized;
            var angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            if (Mathf.Abs(angle) > 2.0f)
                _rb.MoveRotation(angle + _rotationOffset);
        }
    }
}