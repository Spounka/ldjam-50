using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spounka.Shooting
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private WeaponSO _weapon;
        [SerializeField] private GameObject _bulletObject;


        private Transform _transform;
        private float timer = 0;
        private bool _mousePressed = false;
        private AudioEffects _audioEffects;

        private bool CanShoot => _mousePressed && timer <= 0;

        public WeaponSO Weapon
        {
            get => _weapon;
            set => _weapon = value;
        }


        private void OnEnable()
        {
            GetComponent<SpriteRenderer>().sprite = Weapon.weaponSprite;
            _audioEffects = GetComponent<AudioEffects>() ?? GetComponentInChildren<AudioEffects>();
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
            for (var i = 0; i < Weapon.bulletsShot.Value; i++)
            {
                var rotation = _transform.rotation;
                var bullet = Instantiate(_bulletObject, _transform.position, rotation);
                var randomSpread = Random.Range(-Weapon.spread, Weapon.spread);
                var spreadVector = rotation * Quaternion.AngleAxis(randomSpread, Vector3.forward);
                bullet.transform.rotation = spreadVector;
                bullet.SetActive(true);
            }

            _audioEffects.PlayAudio(Weapon.shootingSound);
            timer = Weapon.fireRate;
        }
    }
}