using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSelectData : MonoBehaviour
{ 
    public EventSystemCustom EventSystemP1, EventSystemP2;
    public RectTransform OnSelectDim;
    public Transform Data_Transform;
    public Image OnSelectImage;
    public GameObject ThisCanvas, NextCanvas;
    public int SceneIndex;
    public GameObject GameProps;
    public SelectMenu SelectMenu;
    public GameObject panelBase, PanelActive;
    public GameObject FirstSelectable;
    public GameObject PointerAudio;
}
