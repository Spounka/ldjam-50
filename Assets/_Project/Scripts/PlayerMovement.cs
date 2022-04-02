using UnityEngine;

namespace Spounka
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationOffset;

        private Vector2 input;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main ? Camera.main : Camera.current;
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
            transform.position += (Vector3)velocity;
        }

        private void RotateToMouse()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var difference = (mousePosition - transform.position).normalized;
            var angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + _rotationOffset);
        }
    }
}