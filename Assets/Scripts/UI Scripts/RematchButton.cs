﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RematchButton : Button
{
    EventSystem eventsystem;

    BaseEventData baseEvent;


    public override void OnSelect(BaseEventData eventData)
    {
        GetComponent<OnSelectData>().PanelActive.SetActive(true);
        GetComponent<OnSelectData>().panelBase.SetActive(false);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        GetComponent<OnSelectData>().panelBase.SetActive(true);
        GetComponent<OnSelectData>().PanelActive.SetActive(false);
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        GetComponent<MyEventSystemProvider>().eventSystem.SetSelectedGameObject(GetComponent<OnSelectData>().FirstSelectable);
        SceneReload();
    }

    public void SceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
