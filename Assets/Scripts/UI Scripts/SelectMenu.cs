using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectMenu : MonoBehaviour
{
    public bool ReadyPlayerOne = false, ReadyPlayerTwo = false;
    public GameObject ConfirmP1, ConfirmP2, PreviewP1, PreviewP2;
    public GameObject CurrentCanvas, NextCanvas;
    public GameObject POnePaty, PTwoParty;
    //public GameObject PlayButton;
    private void OnEnable()
    {
        PartyData.ClearData();
    }
   

    // Update is called once per frame
    void Update()
    {
        //BenchCheck();
        UpdateSelected();
    }

    //void BenchCheck()
    //{
    //    if (PartyData.PartyCount(1) == 3 && PartyData.PartyCount(2) == 3)
    //    {
    //        PlayButton.SetActive(true);
    //    }
    //    else PlayButton.SetActive(false);
    //}

    void UpdateSelected()
    {
        if (PartyData.PartyCount(1) == 0)
        {
            //POnePaty.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        }
            if (PartyData.PartyCount(1) == 1)
        {
            POnePaty.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            //POnePaty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = PartyData.POnePart[0].GetComponent<Agent>()._Sprites[1];
            POnePaty.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.POnePart[0].GetComponent<Agent>().CharacterName;
        }
        if (PartyData.PartyCount(1) == 2)
        {
            POnePaty.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            //POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = PartyData.POnePart[1].GetComponent<Agent>()._Sprites[1];
            POnePaty.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.POnePart[1].GetComponent<Agent>().CharacterName;
        }
        if (PartyData.PartyCount(1) == 3)
        {
            POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            POnePaty.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = PartyData.POnePart[2].GetComponent<Agent>()._Sprites[1];
            POnePaty.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.POnePart[2].GetComponent<Agent>().CharacterName;
        }

        if (PartyData.PartyCount(2) == 0)
        {
            //PTwoParty.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);            
        }
        if (PartyData.PartyCount(2) == 1)
        {
            PTwoParty.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            //PTwoParty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = PartyData.PTwoPart[0].GetComponent<Agent>()._Sprites[1];
            PTwoParty.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.PTwoPart[0].GetComponent<Agent>().CharacterName;
        }
        if (PartyData.PartyCount(2) == 2)
        {
            PTwoParty.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            //PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = PartyData.PTwoPart[1].GetComponent<Agent>()._Sprites[1];
            PTwoParty.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.PTwoPart[1].GetComponent<Agent>().CharacterName;
        }
        if (PartyData.PartyCount(2) == 3)
        {
            PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            PTwoParty.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = PartyData.PTwoPart[2].GetComponent<Agent>()._Sprites[1];
            PTwoParty.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.PTwoPart[2].GetComponent<Agent>().CharacterName;
        }

        if ((PartyData.PartyCount(2) == 3) && (PartyData.PartyCount(1) == 3) && ReadyPlayerOne && ReadyPlayerTwo)
        {
            NextCanvas.SetActive(true);
            CurrentCanvas.SetActive(false);
        }

        if(PartyData.PartyCount(1) == 3)
        {
            PreviewP1.SetActive(false);
            ConfirmP1.SetActive(true);
        }
        else
        {
            ConfirmP1.SetActive(false);
            PreviewP1.SetActive(true);
        }

        if (PartyData.PartyCount(2) == 3)
        {
            PreviewP2.SetActive(false);
            ConfirmP2.SetActive(true);
        }
        else
        {
            ConfirmP2.SetActive(false);
            PreviewP2.SetActive(true);
        }
    }

    public void RemoveCharacter(int _PlayerID)
    {
        if(_PlayerID == 1)
        {
            PartyData.POnePart.Remove(PartyData.POnePart[(PartyData.POnePart.Count -1)]);
        }
        else if (_PlayerID == 2)
        {
            PartyData.PTwoPart.Remove(PartyData.PTwoPart[(PartyData.PTwoPart.Count - 1)]);
        }
    }
}
