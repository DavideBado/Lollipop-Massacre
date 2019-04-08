using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharaSprites : MonoBehaviour
{
    public GameObject ArrowPOne, ArrowPTwo;
    public RawImage CharacterImage;
    List<PlayerInMenu> Players = new List<PlayerInMenu>();
    bool PlayerOneOn, PlayerTwoOn, AllPlayersOn;
    public RawImage RedImage;
    public List<GameObject> Character = new List<GameObject>();
    Texture ThisImage;
    [SerializeField] public List<Texture> OnSelectSprites = new List<Texture>();
    public int SpriteID;

    private void Start()
    {
        // ChildImage.sprite = Character[1].GetComponent<Agent>()._Sprites[0];
        CharacterImage.texture = Character[0].GetComponent<Agent>()._Sprites[0];
        //FindPlayer();
        
    }

    //private void Update()
    //{     
    //    SelectCheck();       
    //}

   
}
