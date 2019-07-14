using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    public TutorialController TutorialController;
    private void OnEnable()
    {
        TutorialController.PrevPanel = gameObject; 
    }
}
