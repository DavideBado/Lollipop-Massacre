using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject CharacterSelection, MainMenu, Loading;
    private void OnEnable()
    {
        if(PartyData.CharacterSelection == true)
        {
            CharacterSelection.SetActive(true);
            MainMenu.SetActive(false);
            Loading.SetActive(false);
            PartyData.CharacterSelection = false;
        }
    }
}
