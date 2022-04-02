using UnityEngine;

namespace Spounka
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private float _shootingRate;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private Rigidbody2D _bulletPrefab;
        private Transform _transform;
        private float timer = 0;
        private bool _mousePressed = false;

        private bool CanShoot => _mousePressed && timer <= 0;


        private void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            _mousePressed = Input.GetMouseButton(0);
            if (timer > 0)
                timer -= Time.deltaTime;
        }

        private void FixedUpdate()
        {
            if (CanShoot)
                Shoot();
        }

        private void Shoot()
        {
            var @obj = Instantiate(_bulletPrefab, _transform.position, _transform.rotation);
            @obj.AddForce(transform.up * _bulletSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            Destroy(@obj, 5.0f);
            timer = _shootingRate;
        }
    }
}