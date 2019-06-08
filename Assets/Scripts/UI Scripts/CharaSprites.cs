using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharaSprites : MonoBehaviour
{
    public List<List<Image>> BigCharaSprites = new List<List<Image>>();
    public List<Image> BigP1Characters = new List<Image>();
    public List<Image> BigP2Characters = new List<Image>();
    public GameObject ArrowPOne, ArrowPTwo;
    public Image CharacterImage;
    List<PlayerInMenu> Players = new List<PlayerInMenu>();
    bool PlayerOneOn, PlayerTwoOn, AllPlayersOn;
    public Image RedImage;
    public List<GameObject> Character = new List<GameObject>();
    Texture ThisImage;
    [SerializeField] public List<Texture> OnSelectSprites = new List<Texture>();
    public int SpriteID;

    private void Start()
    {
        BigCharaSprites.Add(BigP1Characters);
        BigCharaSprites.Add(BigP2Characters);
        // ChildImage.sprite = Character[1].GetComponent<Agent>()._Sprites[0];
        CharacterImage.sprite = Character[0].GetComponent<Agent>()._Sprites[0];
        //FindPlayer();
        
    }

    //private void Update()
    //{     
    //    SelectCheck();       
    //}

   
}
