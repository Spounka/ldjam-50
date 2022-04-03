using UnityEngine;

namespace Spounka
{
    public class CameraFollow : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _followSpeed;
        [SerializeField] private Transform _followTarget;
        [SerializeField] private Vector3 _offset;

        #endregion

        private void LateUpdate()
        {
            transform.position =
                Vector3.Lerp(transform.position, _followTarget.position + _offset, _followSpeed * Time.deltaTime);
        }
    }
}