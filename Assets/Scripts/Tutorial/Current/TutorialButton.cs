using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class TutorialButton : MainMenuButton
{
    private List<TutorialButton> tutorialButtons = new List<TutorialButton>();

    protected override void Start()
    {
        tutorialButtons = FindObjectsOfType<TutorialButton>().ToList();
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        foreach (TutorialButton _tutorialButton in tutorialButtons)
        {
            _tutorialButton.GetComponent<OnSelectData>().ThisCanvas = GetComponent<OnSelectData>().NextCanvas;
        }
        base.OnSubmit(eventData);
    }
}
