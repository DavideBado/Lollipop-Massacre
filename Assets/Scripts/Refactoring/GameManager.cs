using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gestisce le fasi di gioco 
/// </summary>
    namespace Refactoring
    {
    public class GameManager : MonoBehaviour
    {
        public static GameManager GMinstance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

        private LevelManager m_levelManager;
        private int m_NumPlayers;
        public List<List<Agent>> BMBench = new List<List<Agent>>();
        
        //Awake is always called before any Start functions
        void Awake()
        {
            //Check if instance already exists
            if (GMinstance == null)

                //if not, set instance to this
                GMinstance = this;

            //If instance already exists and it's not this:
            else if (GMinstance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

            Init();
        }

       /// <summary>
       /// Primo Init
       /// </summary>
        void Init()
        {


        }

        /// <summary>
        /// EventoBottoneCambioScena += Loader(ScenaDaCaricare);
        /// </summary>
        
        void Loader(int _Index)
        {
            m_levelManager = null;
            SceneManager.LoadScene(_Index);
            m_levelManager = FindObjectOfType<LevelManager>();
            if(m_levelManager != null)
            {
                m_levelManager.Init(m_NumPlayers);
            }
        }

        /// <summary>
        /// EventoBottoneNumeroGiocatori += Players(_num);
        /// Salva il numero di giocatori
        /// Crea una lista di personaggi per ogni giocatore
        /// </summary>
        
        void Players(int _num)
        {
            m_NumPlayers = _num;

            for (int i = 0; i < _num; i++)
            {
                BMBench.Add(new List<Agent>());
            }
        }
    }

}
