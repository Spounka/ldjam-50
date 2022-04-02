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

        private void OnGUI()
        {
            if (GUI.Button(new Rect(100, 100, 200, 50), "Take Damage"))
            {
                _healthSystem.TakeDamage(10);
            }
        }
    }
}