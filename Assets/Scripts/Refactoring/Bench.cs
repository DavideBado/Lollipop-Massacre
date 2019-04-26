using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La panchina a disposizione del giocatore
/// </summary>
namespace Refactoring
{
    public abstract class Bench : MonoBehaviour
    {
        private List<Agent> m_Bench = new List<Agent>();
       
        public void Init(List<Agent> _ManagerBench)
        {
            m_Bench = _ManagerBench;

        }
    }

}
