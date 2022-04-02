using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spounka
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        private Vector2 input;

        private void Start()
        {
        }

        private void Update()
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            Move();
        }

        private void Move()
        {
            var direction = input.normalized;
            var velocity = direction * _movementSpeed * Time.deltaTime;
            transform.position += (Vector3)velocity;
        }
    }
}