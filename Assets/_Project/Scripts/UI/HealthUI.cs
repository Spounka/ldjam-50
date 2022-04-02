using UnityEngine;
using UnityEngine.UI;

namespace Spounka
{
    public class HealthUI : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Slider _healthSlider;
        [SerializeField] private HealthSystem _healthSystem;

        #endregion


        private void Start()
        {
            _healthSlider.value = _healthSlider.maxValue = _healthSystem.MaxHealth;
        }


        private void Update()
        {
            _healthSlider.value = _healthSystem.CurrentHealth;
        }
    }
}