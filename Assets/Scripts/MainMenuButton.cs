using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuButton : Button
{
    public EventSystem eventsys;
    BaseEventData baseEvent;

    public override void OnSelect(BaseEventData eventData)
    {

        if (GetComponent<OnSelectData>().PanelActive != null)
        {
            GetComponent<OnSelectData>().PanelActive.SetActive(true); 
        }
        if (GetComponent<OnSelectData>().panelBase != null)
        {
            GetComponent<OnSelectData>().panelBase.SetActive(false); 
        }
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        if (GetComponent<OnSelectData>().panelBase != null)
        {
            GetComponent<OnSelectData>().panelBase.SetActive(true); 
        }
        if (GetComponent<OnSelectData>().PanelActive != null)
        {
            GetComponent<OnSelectData>().PanelActive.SetActive(false); 
        }
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        GetComponent<OnSelectData>().NextCanvas.SetActive(true);

        if (GetComponent<OnSelectData>().FirstSelectable != null)
        {
            GetComponent<MyEventSystemProvider>().eventSystem.SetSelectedGameObject(GetComponent<OnSelectData>().FirstSelectable); 
        }
        if (GetComponent<OnSelectData>().ThisCanvas != null && GetComponent<OnSelectData>().ThisCanvas != GetComponent<OnSelectData>().NextCanvas)
        {
            GetComponent<OnSelectData>().ThisCanvas.SetActive(false); 
        }
    }
}
