using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharaSprites : MonoBehaviour
{
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
        FindPlayer();
        
    }

    //private void Update()
    //{     
    //    SelectCheck();       
    //}

    void SelectCheck()
    {
        foreach(PlayerInMenu player in Players)
        {
            if(player.PlayerID == 1)
            {
                if(player.SpriteID == SpriteID)
                {
                    PlayerOneOn = true;
                }
                else
                {
                    PlayerOneOn = false;
                }               
            }
            else if (player.PlayerID == 2)
            {
                if (player.SpriteID == SpriteID)
                {
                    PlayerTwoOn = true;
                }
                else
                {
                    PlayerTwoOn = false;
                }
            }
        }
        UpdateOnSelectImage();
    }

    void UpdateOnSelectImage()
    {
        if (PlayerOneOn == false && PlayerTwoOn == false)
        {
            ThisImage = OnSelectSprites[0];
        }
        else if (PlayerOneOn == true && PlayerTwoOn == false)
        {
            ThisImage = OnSelectSprites[1];
        }
        else if (PlayerTwoOn == true && PlayerOneOn == false)
        {
            ThisImage = OnSelectSprites[2];
        } else if (PlayerOneOn == true && PlayerTwoOn == true)
        {
            ThisImage = OnSelectSprites[3];
        }

        GetComponent<RawImage>().texture = ThisImage;
    }

    void FindPlayer()
    {
        Players = FindObjectsOfType<PlayerInMenu>().ToList();
    }
}
