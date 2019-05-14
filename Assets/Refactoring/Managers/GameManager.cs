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

    #region Delegates
    public static Action GoToCharacterSelection;
    public static Action GoToMainMenu;
    public static Action GoToTutorial;
    public static Action GoToOptions;
    public static Action GoToGamePlay;

    #endregion

    private void Awake()
    {
        Instance();
        SetUp();
    }

    private void OnEnable()
    {
        if(singleton == this)
        {
            //iscrizioni agli eventi chiamati dagli stati
            GoToCharacterSelection += singleton.HandleOnCharacterSelection;
            GoToMainMenu += singleton.HandleOnMainMenu;
            GoToTutorial += singleton.HandleOnTutorial;
            GoToOptions += singleton.HandleOnOptions;
            GoToGamePlay += singleton.HandleOnGamePlay;

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

    }

    void SetUp()
    {
        //Setup della state machine
        animController = GetComponent<Animator>();
        //setup dei managers
        InputMngr = FindObjectOfType<InputManager>();
        UIMngr = FindObjectOfType<UIManager>();
        Context context = new Context()
        {
            timer = 3f,

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

    #endregion


    private void OnDisable()
    {
        if(singleton == this)
        {
            //disiscrizione dagli eventi
            GoToCharacterSelection -= singleton.HandleOnCharacterSelection;
            GoToMainMenu -= singleton.HandleOnMainMenu;
            GoToTutorial -= singleton.HandleOnTutorial;
            GoToOptions -= singleton.HandleOnOptions;
            GoToGamePlay -= singleton.HandleOnGamePlay;
        }
        
    }
}
