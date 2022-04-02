using UnityEngine;
using UnityEngine.Events;

namespace Spounka.Lib
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        public UnityEvent unityEvent;

        private void OnEnable()
        {
            gameEvent.RegisterEvent(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterEvent(this);
        }

        public void Raise()
        {
            unityEvent.Invoke();
        }
    }
}