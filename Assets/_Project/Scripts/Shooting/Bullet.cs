using UnityEngine;

namespace Spounka.Shooting
{
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private BulletSO _bulletSo;

        private Rigidbody2D _rb;

        #endregion

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            GetComponent<SpriteRenderer>().sprite = _bulletSo.bulletSprite;
            Destroy(gameObject, _bulletSo.bulletLifeTime);
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + (Vector2)(_bulletSo.bulletSpeed * _rb.transform.up * Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag("Player") || col.collider.CompareTag("Pickable")) return;

            var healthSystem = col.collider.GetComponent<HealthSystem>();
            if (healthSystem == null) return;

            healthSystem.TakeDamage((int)_bulletSo.bulletDamage.Value);
            Destroy(gameObject);
        }
    }
}