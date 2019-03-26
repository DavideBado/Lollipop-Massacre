using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSprites : MonoBehaviour
{
    public Agent Character;
    Sprite Image;
    private void Start()
    {
        Image = Character._Sprites[0];
        GetComponent<Image>().sprite = Image;
    }
}
