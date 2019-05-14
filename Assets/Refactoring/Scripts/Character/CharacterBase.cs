using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterBase : MonoBehaviour, IAgent
    {
        public CharacterData Data;
        private healthController HealthCtrl;
        private playerMovementController MovementCtrl;
        private CharacterViewController viewCtrl;
        private int PlayerID;

        public void Setup()
        {
            HealthCtrl = GetComponent<healthController>();
            MovementCtrl = GetComponent<playerMovementController>();
            viewCtrl = GetComponent<CharacterViewController>();
            HealthCtrl.Setup(Data.Life);
            viewCtrl.Setup(Data.CharacterView);
        }
    }
}

