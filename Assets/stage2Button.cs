using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stage2Button : Button
{
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
        //SceneManager.LoadScene("lilitest");
        //GetComponent<MyEventSystemProvider>().eventSystem.SetSelectedGameObject(GetComponent<OnSelectData>().FirstSelectable);
        OnClickTest();
    }

    public void OnClickTest()
    {
        LoadSceneLoading.SceneIndex = GetComponent<OnSelectData>().SceneIndex;
        GetComponent<OnSelectData>().NextCanvas.SetActive(true);
        GetComponent<OnSelectData>().ThisCanvas.SetActive(false);
    }
}
