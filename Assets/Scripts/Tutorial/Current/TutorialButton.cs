using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialButton : MainMenuButton
{
    TutorialController tutorialController;
    Image MyImage;
    Sprite BaseSprite;
   // private List<TutorialButton> tutorialButtons = new List<TutorialButton>();

    protected override void Start()
    {
        tutorialController = FindObjectOfType<TutorialController>();
        MyImage = GetComponent<Image>();
        BaseSprite = MyImage.sprite;
        //tutorialButtons = FindObjectsOfType<TutorialButton>().ToList();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        MyImage.sprite = GetComponent<OnSelectData>().OnSelectSprite;
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        MyImage.sprite = BaseSprite;
    }
    public override void OnSubmit(BaseEventData eventData)
    {
        //foreach (TutorialButton _tutorialButton in tutorialButtons)
        //{
        //    _tutorialButton.GetComponent<OnSelectData>().ThisCanvas = GetComponent<OnSelectData>().NextCanvas;
        //}
        //base.OnSubmit(eventData);

        if (tutorialController.PrevPanel != null)
        {
            tutorialController.PrevPanel.SetActive(false); 
        }
        GetComponent<OnSelectData>().NextCanvas.SetActive(true);
    }
}
