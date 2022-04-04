using Spounka.Core.DataTypes;
using Spounka.Core.Event;
using UnityEngine;

namespace Spounka
{
    public class InfectionSystem : MonoBehaviour
    {
        #region Variables

        [SerializeField] private VariableReference<float> _playerInfectionValue;
        [SerializeField] private VariableReference<bool> _isPlayerInfected;
        [SerializeField] private VariableReference<float> _maxInfectionValue;


        [SerializeField] private VariableReference<float> _timeForFullInfection;

        public GameEvent playerDead;

        #endregion

        private void Awake()
        {
            _isPlayerInfected.Value = false;
            _playerInfectionValue.Value = 0;
        }

        private void Update()
        {
            if (!_isPlayerInfected.Value || _playerInfectionValue.Value >= _maxInfectionValue.Value) return;

            _playerInfectionValue.Value += Time.deltaTime * (_maxInfectionValue / _timeForFullInfection);
            if (_playerInfectionValue.Value >= _maxInfectionValue)
            {
                playerDead.Raise();
            }
        }
    }
}