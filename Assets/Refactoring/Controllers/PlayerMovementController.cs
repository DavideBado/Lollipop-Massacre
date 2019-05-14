using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class playerMovementController : MonoBehaviour
    {
        #region var

        public bool CanMove;

        #endregion

        #region functions

        public void SetCanMove()
        {
            CanMove = true;
        }
        #endregion
    }

}




