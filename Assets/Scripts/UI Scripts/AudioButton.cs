using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioButton : Button
{
    public EventSystem eventsys;
    BaseEventData baseEvent;

    public override void OnSelect(BaseEventData eventData)
    {
        GetComponent<OnSelectData>().PointerAudio.SetActive(true);
        
    }

    public override void OnDeselect(BaseEventData eventData)
    {

        GetComponent<OnSelectData>().PointerAudio.SetActive(false);
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        if(GetComponent<OnSelectData>().panelBase.activeInHierarchy)
        {
            GetComponent<OnSelectData>().PanelActive.SetActive(true);
            GetComponent<OnSelectData>().panelBase.SetActive(false);
            //GetComponent<OnSelectData>().PointerAudio1.SetActive(false);
        } else if (GetComponent<OnSelectData>().PanelActive.activeInHierarchy)
        {
            GetComponent<OnSelectData>().PanelActive.SetActive(false);
            GetComponent<OnSelectData>().panelBase.SetActive(true);
            //GetComponent<OnSelectData>().PointerAudio1.SetActive(true);
        }

        //qui si spegnerà l'audio
    }
}
