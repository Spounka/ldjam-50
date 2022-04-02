using System.Collections.Generic;
using UnityEngine;

namespace Spounka.Lib
{
    [CreateAssetMenu(fileName = "GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private readonly LinkedList<GameEventListener> _listeners = new LinkedList<GameEventListener>();

        public void RegisterEvent(GameEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.AddLast(listener);
        }

        public void UnregisterEvent(GameEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }

        public void Raise()
        {
            var current = _listeners.First;
            while (current != null)
            {
                var next = current.Next;
                current.Value.Raise();
                current = next;
            }
        }
    }
}