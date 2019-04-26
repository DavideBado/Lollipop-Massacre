using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gestisce i livelli di gioco
/// Spawn:
///     - Grid
///     - Personaggi
///     - Powerup e portali
/// Trasparenza ostacoli
/// UI
/// </summary>
namespace Refactoring
{
    public class LevelManager : MonoBehaviour
    {
        private Grid m_grid;

        public void Init(int _Players)
        {
            m_grid = FindObjectOfType<Grid>();
            if(m_grid != null)
            {
                m_grid.Init();
            }
        }

        /// <summary>
        /// EventoMorteOCambioForzato += SpawnChara(int _PlayerID); 
        /// </summary>
        void SpawnChara(int _PlayerID)
        {

        }

        /// <summary>
        /// EventoSwitcher += SpawnSwitcher(int _PlayerID, int _SwitcherID); 
        /// </summary>
        void SpawnSwitcher(int _PlayerID, int _SwitcherID)
        {

        }

        /// <summary>
        /// EventoCharacterDietroMuro += WallTransparency
        /// Come recuperare i muri senza usare le collisioni? Sistemare pivot parent/controllare le props nuove
        /// </summary>
        void WallTransparency()
        {

        }
    }
}
