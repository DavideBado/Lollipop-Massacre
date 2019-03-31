using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    public GameObject POnePaty, PTwoParty;
    public GameObject PlayButton;
    private void OnEnable()
    {
        PartyData.ClearData();
    }
   

    // Update is called once per frame
    void Update()
    {
        BenchCheck();
        UpdateSelected();
    }

    void BenchCheck()
    {
        if (PartyData.PartyCount(1) == 3 && PartyData.PartyCount(2) == 3)
        {
            PlayButton.SetActive(true);
        }
        else PlayButton.SetActive(false);
    }

    void UpdateSelected()
    {
        if (PartyData.PartyCount(1) > 0)
        {
            POnePaty.transform.GetChild(0).GetComponent<Image>().sprite = PartyData.POnePart[0].GetComponent<Agent>()._Sprites[1];
        }
        if (PartyData.PartyCount(1) > 1)
        {
            POnePaty.transform.GetChild(1).GetComponent<Image>().sprite = PartyData.POnePart[1].GetComponent<Agent>()._Sprites[1];
        }
        if (PartyData.PartyCount(1) > 2)
        {
            POnePaty.transform.GetChild(2).GetComponent<Image>().sprite = PartyData.POnePart[2].GetComponent<Agent>()._Sprites[1];
        }

        if (PartyData.PartyCount(2) > 0)
        {
            PTwoParty.transform.GetChild(0).GetComponent<Image>().sprite = PartyData.PTwoPart[0].GetComponent<Agent>()._Sprites[1];
        }
        if (PartyData.PartyCount(2) > 1)
        {
            PTwoParty.transform.GetChild(1).GetComponent<Image>().sprite = PartyData.PTwoPart[1].GetComponent<Agent>()._Sprites[1];
        }
        if (PartyData.PartyCount(2) > 2)
        {
            PTwoParty.transform.GetChild(2).GetComponent<Image>().sprite = PartyData.PTwoPart[2].GetComponent<Agent>()._Sprites[1];
        }


    }
}
