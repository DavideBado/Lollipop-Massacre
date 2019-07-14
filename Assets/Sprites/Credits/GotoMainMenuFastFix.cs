using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GotoMainMenuFastFix : Button
{
    Image MyImage;
    Sprite BaseSprite;
    protected override void Start()
    {
        MyImage = GetComponent<Image>();
        BaseSprite = MyImage.sprite;
    }

    public override void OnSelect(BaseEventData eventData)
    {
        if (GetComponent<OnSelectData>().OnSelectSprite != null)
        {
            MyImage.sprite = GetComponent<OnSelectData>().OnSelectSprite; 
        }
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        MyImage.sprite = BaseSprite;
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        SceneManager.LoadScene(0);
    }
}
