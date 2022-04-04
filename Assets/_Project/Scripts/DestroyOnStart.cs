using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spounka
{
    public class DestroyOnStart : MonoBehaviour
    {
        #region Variables

        #endregion


        private void Start()
        {
            Destroy(gameObject, 3.0f);
        }
    }
}