using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class healthController : MonoBehaviour
    {

        #region var
        private int health;
        private int currentHealth;
        #endregion

        #region functions

        public void Setup(int _health)
        {
            health = _health;
        }

        public void LoseHealth(int _amount)
        {
            currentHealth -= _amount;
        }

        public void GainHealth(int _amount)
        {
            currentHealth += -_amount;
        }
        #endregion
    }
}

