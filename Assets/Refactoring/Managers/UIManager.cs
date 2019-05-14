using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject MainMenu, CharacterSelection, Tutorial, Options, Loading;
    public GameObject CurrentPanel;

    private void Awake()
    {
        if(CurrentPanel == null)
        {
            CurrentPanel = MainMenu;
        }
    }

    public void ActivatePanel(GameObject _gobj)
    {
        _gobj.SetActive(true);
        CurrentPanel = _gobj;
    }

    public void DeactivatePanel(GameObject _gobj)
    {
        if (_gobj != null)
            _gobj.SetActive(false);
    }

    public void ChangeMenu(MenuType _menuType)
    {
        if (CurrentPanel != null)
        {
            switch (_menuType)
            {
                case MenuType.MainMenu:
                    CurrentPanel = MainMenu;
                    break;
                case MenuType.Options:
                    CurrentPanel = Options;
                    break;
                case MenuType.CharacterSelection:
                    CurrentPanel = CharacterSelection;
                    break;
                case MenuType.Tutorial:
                    CurrentPanel = Tutorial;
                    break;
                case MenuType.Loading:
                    CurrentPanel = Loading;
                    break;
            }
            ActivatePanel(CurrentPanel);

        }
        else Debug.LogWarning("Scemoddimmerda, il currentpanel è vuoto");
    }
}

public enum MenuType
{
    MainMenu,
    Options,
    CharacterSelection,
    Tutorial,
    Loading,
  

}
