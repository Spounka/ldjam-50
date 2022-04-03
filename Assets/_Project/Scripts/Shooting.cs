using UnityEngine;

namespace Spounka
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private WeaponSO _weapon;
        [SerializeField] private GameObject _bulletObject;


        private Transform _transform;
        private float timer = 0;
        private bool _mousePressed = false;

        private bool CanShoot => _mousePressed && timer <= 0;

        private void OnEnable()
        {
            GetComponent<SpriteRenderer>().sprite = _weapon.weaponSprite;
        }

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
            if (_weapon.bulletsShot.Value <= 1)
            {
                var obj = Instantiate(_bulletObject, _transform.position, _transform.rotation);
                obj.SetActive(true);
            }
            else
            {
                for (var i = 0; i < _weapon.bulletsShot.Value; i++)
                {
                    var rotation = _transform.rotation;
                    var bullet = Instantiate(_bulletObject, _transform.position, rotation);
                    var randomSpread = Random.Range(-_weapon.spread, _weapon.spread);
                    var spreadVector = rotation * Quaternion.AngleAxis(randomSpread, Vector3.forward);
                    bullet.transform.rotation = spreadVector;
                    bullet.SetActive(true);
                }
            }

            timer = _weapon.fireRate;
        }
    }
}