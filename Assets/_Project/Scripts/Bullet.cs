using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spounka
{
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _bulletSpeed = 5.0f;
        [SerializeField] private int _bulletDamage = 5;
        [SerializeField] private float _bulletLifeTime = 3.0f;

        private Rigidbody2D _rb;

        #endregion

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            Destroy(gameObject, _bulletLifeTime);
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + (Vector2)(_bulletSpeed * _rb.transform.up * Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag("Player")) return;

            var healthSystem = col.collider.GetComponent<HealthSystem>();
            if (healthSystem == null) return;

            healthSystem.TakeDamage(_bulletDamage);
            Destroy(gameObject);
        }
    }
}