using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingState : StateBehaviourBase
{
    public string SceneNameToLoad;

    public override void OnEnter()
    {
        ChangeScene();
        GameManager.singleton.UIMngr.ChangeMenu(MenuType.Loading);
        GameManager.singleton.LevelMngr = FindObjectOfType<LevelManager>();
        GameManager.singleton.LevelMngr.SetUp();
        GameManager.singleton.LevelMngr.Init();
    }

    public override void OnUpdate()
    {  
        ctx.timer -= Time.deltaTime;
        if (ctx.timer <= 0)
            GameManager.GoToGamePlay();
    }

    public override void OnExit()
    {
        GameManager.singleton.UIMngr.Loading.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneNameToLoad);
    }
}
