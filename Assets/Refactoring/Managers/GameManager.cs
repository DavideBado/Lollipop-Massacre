using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public Animator animController;
    public Context newContext;
    public UIManager UIMngr;
    public InputManager InputMngr;
    public LevelManager LevelMngr;
    public GridManager GridMngr;
    public TurnManager TurnMngr;
    public PlayerManager PlayerMngr;


    #region Delegates
    public static Action GoToCharacterSelection;
    public static Action GoToMainMenu;
    public static Action GoToTutorial;
    public static Action GoToOptions;
    public static Action GoToGamePlay;
    public static Action GoToIdle;
    public static Action GoToBaseAttack;
    public static Action GoToMovement;
    public static Action GoToAbility;
    public static Action GoToPreturn;
    public static Action GoToEndGame;
    public static Action GoToPause;
    

    #endregion


    public void InitManagers()
    {
        GetInputManager();
        GetUiManager();
        GetLevelManager();
        GetTurnManager();
        GetGridMngr();
        GetPlayerManager();
    }

    private void Awake()
    {
        Instance();
        SetUpSM();
    }

    private void OnEnable()
    {
        if (singleton == this)
        {
            //iscrizioni agli eventi chiamati dagli stati
            GoToCharacterSelection += singleton.HandleOnCharacterSelection;
            GoToMainMenu += singleton.HandleOnMainMenu;
            GoToTutorial += singleton.HandleOnTutorial;
            GoToOptions += singleton.HandleOnOptions;
            GoToGamePlay += singleton.HandleOnGamePlay;
            GoToIdle += singleton.HandleOnIdle;
            GoToBaseAttack += singleton.HandleOnBaseAttack;
            GoToMovement += singleton.HandleOnMovement;
            GoToAbility += singleton.HandleOnAbility;
            GoToPreturn += singleton.HandleOnPreTurn;
            GoToEndGame += singleton.HandleOnEndGame;
            GoToPause += singleton.HandleOnPause;
        }

    }

    public void Instance()
    {
        if (singleton == null)
            singleton = this;

        else if (singleton != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    public class Context
    {
        //parametri context
        public float timer;
        public int CurrentPlayer;
        public float preturnTimer;

    }

    #region  Getter
    public GridManager GetGridMngr()
    {
        return GridMngr;
    }

    public UIManager GetUiManager()
    {
        if (!UIMngr)
        {
            return UIMngr;
        }
        return UIMngr;

    }

    public InputManager GetInputManager()
    {
        if (InputMngr == null)
        {
            return InputMngr;
        }
        return InputMngr;
    }

    public LevelManager GetLevelManager()
    {
        return LevelMngr;
    }

    public TurnManager GetTurnManager()
    {
        return TurnMngr;
    }

    public PlayerManager GetPlayerManager()
    {
        return PlayerMngr;
    }
    #endregion
    /// <summary>
    /// StateMachineSetup
    /// </summary>
    void SetUpSM()
    {
        //Setup della state machine
        animController = GetComponent<Animator>();
        //setup dei managers
        Context context = new Context()
        {
            timer = 5f,
            preturnTimer = 1f,
        };
        foreach (StateBehaviourBase state in animController.GetBehaviours<StateBehaviourBase>())
        {
            state.Setup(context);
        }
    }


    #region events

    private void HandleOnCharacterSelection()
    {
        animController.SetTrigger("GoToCharacterSelection");
    }

    private void HandleOnMainMenu()
    {
        animController.SetTrigger("GoToMainMenu");
    }

    private void HandleOnTutorial()
    {
        animController.SetTrigger("GoToTutorial");
    }

    private void HandleOnOptions()
    {
        animController.SetTrigger("GoToOptions");
    }

    private void HandleOnGamePlay()
    {
        animController.SetTrigger("GoToGamePlay");
    }

    private void HandleOnIdle()
    {
        animController.SetTrigger("GoToIdle");
    }

    private void HandleOnBaseAttack()
    {
        animController.SetTrigger("GoToBaseAttack");
    }

    private void HandleOnMovement()
    {
        animController.SetTrigger("GoToMovement");
    }

    private void HandleOnAbility()
    {
        animController.SetTrigger("GoToAbility");
    }

    private void HandleOnPreTurn()
    {
        animController.SetTrigger("GoToPreTurn");
    }

    private void HandleOnEndGame()
    {
        animController.SetTrigger("GoToEndGame");
    }

    private void HandleOnPause()
    {
        animController.SetTrigger("GoToPause");
    }
    #endregion


    private void OnDisable()
    {
        if (singleton == this)
        {
            //disiscrizione dagli eventi
            GoToCharacterSelection -= singleton.HandleOnCharacterSelection;
            GoToMainMenu -= singleton.HandleOnMainMenu;
            GoToTutorial -= singleton.HandleOnTutorial;
            GoToOptions -= singleton.HandleOnOptions;
            GoToGamePlay -= singleton.HandleOnGamePlay;
            GoToIdle -= singleton.HandleOnIdle;
            GoToBaseAttack -= singleton.HandleOnBaseAttack;
            GoToMovement -= singleton.HandleOnMovement;
            GoToAbility -= singleton.HandleOnAbility;
            GoToPreturn -= singleton.HandleOnPreTurn;
            GoToEndGame -= singleton.HandleOnEndGame;
            GoToPause -= singleton.HandleOnPause;
        }

    }

    #region Static Bench

    public List<GameObject> POnePart = new List<GameObject>();
    public List<GameObject> PTwoPart = new List<GameObject>();
    /// <summary>
    /// Riempie la lista dei player e gli seta l'id.
    /// </summary>
    /// <param name="m_PlayerID"></param>
    /// <param name="m_Character"></param>
    public void AddToParty(int m_PlayerID, GameObject m_Character)
    {
        if (m_PlayerID == 1)
        {
            singleton.POnePart.Add(m_Character);
            m_Character.GetComponent<Agent>().SwitchIndex = singleton.POnePart.Count;
            m_Character.GetComponent<Agent>().PlayerID = 1;
        }
        else if (m_PlayerID == 2)
        {
            singleton.PTwoPart.Add(m_Character);
            m_Character.GetComponent<Agent>().SwitchIndex = singleton.PTwoPart.Count;
            m_Character.GetComponent<Agent>().PlayerID = 2;
        }
    }

    /// <summary>
    /// Setta la lista in base all'indice del Player che riceve.
    /// </summary>
    /// <param name="m_PlayerID"></param>
    /// <returns></returns>
    public int PartyCount(int m_PlayerID)
    {
        if (m_PlayerID == 1)
        {
            return singleton.POnePart.Count;
        }
        else if (m_PlayerID == 2)
        {
            return singleton.PTwoPart.Count;
        }
        else
        {
            return -1;
        }
    }

    public void ClearData()
    {
        singleton.POnePart.Clear();
        singleton.PTwoPart.Clear();
    }



    #endregion
}
