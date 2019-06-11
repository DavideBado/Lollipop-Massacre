using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SelectMenu : MonoBehaviour
{
    public float YImageTarget;
    public float ImageSpeed;
    public bool ReadyPlayerOne = false, ReadyPlayerTwo = false;
    public GameObject ConfirmP1, ConfirmP2, PreviewP1, PreviewP2;
    public GameObject CurrentCanvas, NextCanvas;
    public GameObject POnePaty, PTwoParty;
    public List<Image> P1PreviewBackground = new List<Image>(); 
    public List<Image> P2PreviewBackground = new List<Image>();
    public List<Image> P1PreviewBackgroundEndPos = new List<Image>(); 
    public List<Image> P2PreviewBackgroundEndPos = new List<Image>();
    List<Vector3> P1StartingPos = new List<Vector3>();
    List<Vector3> P2StartingPos = new List<Vector3>();
    public List<Sprite> P1Backgrounds = new List<Sprite>(); 
    public List<Sprite> P2Backgrounds = new List<Sprite>(); 
    //public GameObject PlayButton;
    private void OnEnable()
    {
        PartyData.ClearData();
    }

    private void Start()
    {
        P1StartingPos.Clear();
        P2StartingPos.Clear();
        P1StartingPos.Add(P1PreviewBackground[0].transform.position);
        P1StartingPos.Add(P1PreviewBackground[1].transform.position);
        P1StartingPos.Add(P1PreviewBackground[2].transform.position);
        P2StartingPos.Add(P2PreviewBackground[0].transform.position);
        P2StartingPos.Add(P2PreviewBackground[1].transform.position);
        P2StartingPos.Add(P2PreviewBackground[2].transform.position);
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
            P1PreviewBackground[0].sprite = P1Backgrounds[1];
            MoveBackground(P1PreviewBackground[0].transform, P1PreviewBackgroundEndPos[0].transform.position);
            P1PreviewBackground[1].sprite = P1Backgrounds[0];
            P1PreviewBackground[2].sprite = P1Backgrounds[0];
            //POnePaty.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        }
        if (PartyData.PartyCount(1) == 1)
        {
            MoveBackground(P1PreviewBackground[0].transform, P1StartingPos[0]);
            P1PreviewBackground[0].sprite = P1Backgrounds[2];
            P1PreviewBackground[1].sprite = P1Backgrounds[1];
            MoveBackground(P1PreviewBackground[1].transform, P1PreviewBackgroundEndPos[1].transform.position);
            P1PreviewBackground[2].sprite = P1Backgrounds[0];
            POnePaty.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            //POnePaty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = PartyData.POnePart[0].GetComponent<Agent>()._Sprites[1];
            POnePaty.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.POnePart[0].GetComponent<Agent>().CharacterName;
        }
        if (PartyData.PartyCount(1) == 2)
        {
            MoveBackground(P1PreviewBackground[1].transform, P1StartingPos[1]);
            P1PreviewBackground[0].sprite = P1Backgrounds[2];
            P1PreviewBackground[1].sprite = P1Backgrounds[2];
            P1PreviewBackground[2].sprite = P1Backgrounds[1];
            MoveBackground(P1PreviewBackground[2].transform, P1PreviewBackgroundEndPos[2].transform.position);
            POnePaty.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            //POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            POnePaty.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = PartyData.POnePart[1].GetComponent<Agent>()._Sprites[1];
            POnePaty.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.POnePart[1].GetComponent<Agent>().CharacterName;
        }
        if (PartyData.PartyCount(1) == 3)
        {
            MoveBackground(P1PreviewBackground[2].transform, P1StartingPos[2]);
            P1PreviewBackground[0].sprite = P1Backgrounds[2];
            P1PreviewBackground[1].sprite = P1Backgrounds[2];
            P1PreviewBackground[2].sprite = P1Backgrounds[2];
            POnePaty.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            POnePaty.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = PartyData.POnePart[2].GetComponent<Agent>()._Sprites[1];
            POnePaty.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.POnePart[2].GetComponent<Agent>().CharacterName;
        }

        if (PartyData.PartyCount(2) == 0)
        {
            P2PreviewBackground[0].sprite = P2Backgrounds[1];
            MoveBackground(P2PreviewBackground[0].transform, P2PreviewBackgroundEndPos[0].transform.position);
            P2PreviewBackground[1].sprite = P2Backgrounds[0];
            P2PreviewBackground[2].sprite = P2Backgrounds[0];
            //PTwoParty.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);            
        }
        if (PartyData.PartyCount(2) == 1)
        {
            MoveBackground(P2PreviewBackground[0].transform, P2StartingPos[0]);
            P2PreviewBackground[0].sprite = P2Backgrounds[2];
            P2PreviewBackground[1].sprite = P2Backgrounds[1];
            MoveBackground(P2PreviewBackground[1].transform, P2PreviewBackgroundEndPos[1].transform.position);
            P2PreviewBackground[2].sprite = P2Backgrounds[0];
            PTwoParty.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            //PTwoParty.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = PartyData.PTwoPart[0].GetComponent<Agent>()._Sprites[1];
            PTwoParty.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.PTwoPart[0].GetComponent<Agent>().CharacterName;
        }
        if (PartyData.PartyCount(2) == 2)
        {
            MoveBackground(P2PreviewBackground[1].transform, P2StartingPos[1]);
            P2PreviewBackground[0].sprite = P2Backgrounds[2];
            P2PreviewBackground[1].sprite = P2Backgrounds[2];
            P2PreviewBackground[2].sprite = P2Backgrounds[1];
            MoveBackground(P2PreviewBackground[2].transform, P2PreviewBackgroundEndPos[2].transform.position);
            PTwoParty.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            //PTwoParty.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            PTwoParty.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = PartyData.PTwoPart[1].GetComponent<Agent>()._Sprites[1];
            PTwoParty.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PartyData.PTwoPart[1].GetComponent<Agent>().CharacterName;
        }
        if (PartyData.PartyCount(2) == 3)
        {
            MoveBackground(P2PreviewBackground[2].transform, P2StartingPos[2]);
            P2PreviewBackground[0].sprite = P2Backgrounds[2];
            P2PreviewBackground[1].sprite = P2Backgrounds[2];
            P2PreviewBackground[2].sprite = P2Backgrounds[2];
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

    private void MoveBackground(Transform _image, Vector3 _target)
    {
        _image.position = Vector3.MoveTowards(_image.position, _target, ImageSpeed * Time.deltaTime);
        //_image.DOMove(_target, 1f);
    }
}
