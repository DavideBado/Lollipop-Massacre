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
        GameManager.singleton.ClearData();
    }
   

    // Update is called once per frame
    void Update()
    {
        //BenchCheck();
        UpdateSelected();
    }

    void BenchCheck()
    {
        if (GameManager.singleton.PartyCount(1) == 3 && GameManager.singleton.PartyCount(2) == 3)
        {
            PlayButton.SetActive(true);
        }
        else PlayButton.SetActive(false);
    }

    void UpdateSelected()
    {
        if (GameManager.singleton.PartyCount(1) == 0)
        {
            POnePaty.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        }
            if (GameManager.singleton.PartyCount(1) == 1)
        {
            POnePaty.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            POnePaty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = GameManager.singleton.POnePart[0].GetComponent<Agent>()._Sprites[1];
        }
        if (GameManager.singleton.PartyCount(1) == 2)
        {
            POnePaty.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(1).GetChild(0).GetComponent<RawImage>().texture = GameManager.singleton.POnePart[1].GetComponent<Agent>()._Sprites[1];
        }
        if (GameManager.singleton.PartyCount(1) == 3)
        {
            POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            POnePaty.transform.GetChild(2).GetChild(0).GetComponent<RawImage>().texture = GameManager.singleton.POnePart[2].GetComponent<Agent>()._Sprites[1];
        }

        if (GameManager.singleton.PartyCount(2) == 0)
        {
            PTwoParty.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);            
        }
        if (GameManager.singleton.PartyCount(2) == 1)
        {
            PTwoParty.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            PTwoParty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = GameManager.singleton.PTwoPart[0].GetComponent<Agent>()._Sprites[1];
        }
        if (GameManager.singleton.PartyCount(2) == 2)
        {
            PTwoParty.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(1).GetChild(0).GetComponent<RawImage>().texture = GameManager.singleton.PTwoPart[1].GetComponent<Agent>()._Sprites[1];
        }
        if (GameManager.singleton.PartyCount(2) == 3)
        {
            PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            PTwoParty.transform.GetChild(2).GetChild(0).GetComponent<RawImage>().texture = GameManager.singleton.PTwoPart[2].GetComponent<Agent>()._Sprites[1];
        }
    }

    public void RemoveCharacter(int _PlayerID)
    {
        if(_PlayerID == 1)
        {
            GameManager.singleton.POnePart.Remove(GameManager.singleton.POnePart[(GameManager.singleton.POnePart.Count -1)]);
        }
        else if (_PlayerID == 2)
        {
            GameManager.singleton.PTwoPart.Remove(GameManager.singleton.PTwoPart[(GameManager.singleton.PTwoPart.Count - 1)]);
        }
    }
}
