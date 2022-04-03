using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spounka.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _player;
        [SerializeField] private Vector2 _xRange, _yRange;
        [SerializeField] private float _spawnRate;
        [SerializeField] private GameObject _enemySpawn;

        private WaitForSeconds _spawnDelay;

        #endregion

        private void Awake()
        {
            _spawnDelay = new WaitForSeconds(_spawnRate);
        }

        private IEnumerator Start()
        {
            while (true)
            {
                var randomX = Random.Range(_xRange.x, _xRange.y);
                var randomY = Random.Range(_yRange.x, _yRange.y);
                var position = _player.position;
                var randomPosition = new Vector2(randomX + position.x, randomY + position.y);

                // If is close to player, pick another spot
                if (Vector2.Distance(randomPosition, _player.position) <= 3.0f)
                    continue;

                var obj = Instantiate(_enemySpawn, randomPosition, Quaternion.identity);
                obj.name = "Zombie";
                yield return _spawnDelay;
            }
        }
    }
}