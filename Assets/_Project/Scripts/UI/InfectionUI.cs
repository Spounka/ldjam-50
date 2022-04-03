using Spounka.Core.DataTypes;
using UnityEngine;
using UnityEngine.UI;

namespace Spounka
{
    public class InfectionUI : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Slider _infectionSlider;
        [SerializeField] private VariableReference<float> _maxInfectionValue;
        [SerializeField] private VariableReference<float> _currentInfectionValue;

        #endregion


        private void Start()
        {
            _infectionSlider.value = 0;
            _infectionSlider.maxValue = _maxInfectionValue;
        }

        private void Update()
        {
            _infectionSlider.value = _currentInfectionValue;
        }
    }
}