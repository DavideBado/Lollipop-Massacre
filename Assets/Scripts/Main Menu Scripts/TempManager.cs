using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class TempManager : MonoBehaviour
{
    public GameObject POnePartyObj, PTwoPartyObj;
    EventSystem m_EventSystem;
    PointerEventData m_PointerEventData;
    GraphicRaycaster m_Raycaster;
    List<RaycastResult> results = new List<RaycastResult>();
    
    // Update is called once per frame
    void Update()
    {
       
    }

    void ShowParty()
    {
        Image image1 = POnePartyObj.transform.GetChild(0).GetComponent<Image>();
            image1.sprite = PartyData.POneParty[0]._Sprites[0];
    }

    void AddToParty()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            m_PointerEventData = new PointerEventData(m_EventSystem);

            m_PointerEventData.position = Input.mousePosition;

            m_Raycaster.blockingObjects = GraphicRaycaster.BlockingObjects.TwoD;
            m_Raycaster.Raycast(m_PointerEventData, results);
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponentInParent<GameObject>().name == "Panel" && result.gameObject.GetComponent<CharaSprites>() != null)
                {
                    if (PartyData.POnePartyCount() < 3)
                    {
                        PartyData.AddToPartyOne(result.gameObject.GetComponent<CharaSprites>().Character);
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);

            m_PointerEventData.position = Input.mousePosition;

            m_Raycaster.blockingObjects = GraphicRaycaster.BlockingObjects.TwoD;
            m_Raycaster.Raycast(m_PointerEventData, results);
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponentInParent<GameObject>().name == "Panel" && result.gameObject.GetComponent<CharaSprites>() != null)
                {
                    if (PartyData.PTwoPartyCount() < 3)
                    {
                        PartyData.AddToPartyTwo(result.gameObject.GetComponent<CharaSprites>().Character);
                    }
                }
            }
        }
    }
}
