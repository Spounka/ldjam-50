using System;
using Spounka.Core.DataTypes;
using UnityEngine;

namespace Spounka
{
    public class InfectionSystem : MonoBehaviour
    {
        #region Variables

        [SerializeField] private VariableReference<float> _playerInfectionValue;
        [SerializeField] private VariableReference<bool> _isPlayerInfected;

        [SerializeField] private int _maxValue = 100;
        [SerializeField] private VariableReference<float> _timeForFullInfection;

        #endregion

        private void Awake()
        {
            _isPlayerInfected.Value = false;
            _playerInfectionValue.Value = _maxValue;
        }

        private void Update()
        {
            if (_isPlayerInfected.Value)
                _playerInfectionValue.Value += Time.deltaTime * (_maxValue / _timeForFullInfection);
        }
    }
}