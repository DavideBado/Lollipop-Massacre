using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingState : StateBehaviourBase
{
    public string SceneNameToLoad; 
    float loadingtimer;


    private void OnEnable()
    {
        
    }
    public override void OnEnter()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        ChangeScene();
        GameManager.singleton.UIMngr.ChangeMenu(MenuType.Loading);
        loadingtimer = ctx.timer;
    }

    public override void OnUpdate()
    {
        loadingtimer -= Time.deltaTime;
        if (loadingtimer <= 0)
            GameManager.GoToGamePlay();
    }

    public override void OnExit()
    {
        GameManager.singleton.UIMngr.Loading.SetActive(false);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneNameToLoad);
       
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if(scene.name == SceneNameToLoad && scene.name != "MenuIniziale")
        {
            GameManager.singleton.LevelMngr.SetUp();
            GameManager.singleton.LevelMngr.Init();
            
        }

    }

    private void OnDisable()
    {
        
    }
}
