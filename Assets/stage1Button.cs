using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stage1Button : Button
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
        SceneManager.LoadScene("TORINO save(1)");
        GetComponent<MyEventSystemProvider>().eventSystem.SetSelectedGameObject(GetComponent<OnSelectData>().FirstSelectable);
        GetComponent<OnSelectData>().ThisCanvas.SetActive(false);
    }

}
