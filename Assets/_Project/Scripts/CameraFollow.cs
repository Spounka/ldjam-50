using System;
using UnityEngine;

namespace Spounka
{
    public class CameraFollow : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _followSpeed;
        [SerializeField] private Transform _followTarget;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _rotationSpeed;

        private Transform _transform;

        #endregion

        private void Awake()
        {
            _transform = transform;
        }

        private void LateUpdate()
        {
            _transform.position =
                Vector3.Lerp(_transform.position, _followTarget.position + _offset, _followSpeed * Time.deltaTime);
        }
    }
}