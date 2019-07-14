using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GotoMainMenuFastFix : Button
{
    public override void OnSubmit(BaseEventData eventData)
    {
        SceneManager.LoadScene(0);
    }
}
