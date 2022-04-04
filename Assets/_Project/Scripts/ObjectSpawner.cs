using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spounka
{
    public class ObjectSpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _player;
        [SerializeField] private Vector2 _xRange, _yRange;
        [SerializeField] private float _spawnTime;
        [SerializeField] private float _spawnChance;
        [SerializeField] private float _distanceThreshold;
        [SerializeField] private GameObject _spawnObjet;

        private WaitForSeconds _spawnDelay;
        private bool isDead = false;

        #endregion

        private void Awake()
        {
            _spawnDelay = new WaitForSeconds(_spawnTime);
        }

        private IEnumerator Start()
        {
            while (!isDead)
            {
                if (Random.Range(0.0f, 1.0f) > _spawnChance)
                    continue;

                var randomX = Random.Range(_xRange.x, _xRange.y);
                var randomY = Random.Range(_yRange.x, _yRange.y);
                var position = _player.position;
                // Spawn relative to player's position
                var randomPosition = new Vector2(randomX + position.x, randomY + position.y);

                // If is close to player, pick another spot
                if (Vector2.Distance(randomPosition, _player.position) <= _distanceThreshold)
                    continue;

                var obj = Instantiate(_spawnObjet, randomPosition, Quaternion.identity);
                obj.name = _spawnObjet.name;
                yield return _spawnDelay;
            }
        }

        private void OnValidate()
        {
            _spawnDelay = new WaitForSeconds(_spawnTime);
        }

        public void SetIsDead()
        {
            isDead = true;
        }
    }
}