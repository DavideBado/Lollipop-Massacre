using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterViewController : MonoBehaviour
    {
        #region var

        private GameObject view;

        #endregion

        #region functions

        public void Setup(GameObject _view)
        {
            view = _view;
        }

        public void EnableView()
        {
            view.gameObject.SetActive(true);
        }

        public void DisableView()
        {
            view.gameObject.SetActive(false);
        }
        #endregion
    }

}
