using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharaSprites : MonoBehaviour
{
    List<PlayerInMenu> Players = new List<PlayerInMenu>();
    bool PlayerOneOn, PlayerTwoOn, AllPlayersOn;
    public Image ChildImage;
    public Agent Character;
    Sprite Image;
    [SerializeField] public List<Sprite> OnSelectSprites = new List<Sprite>();
    public int SpriteID;

    private void Start()
    {
        Image = GetComponent<Image>().sprite;
        ChildImage.sprite = Character._Sprites[0];
        FindPlayer();
        
    }

    private void Update()
    {     
        SelectCheck();       
    }

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
            Image = OnSelectSprites[0];
        }
        else if (PlayerOneOn == true && PlayerTwoOn == false)
        {
            Image = OnSelectSprites[1];
        }
        else if (PlayerTwoOn == true && PlayerOneOn == false)
        {
            Image = OnSelectSprites[2];
        } else if (PlayerOneOn == true && PlayerTwoOn == true)
        {
            Image = OnSelectSprites[3];
        }

        GetComponent<Image>().sprite = Image;
    }

    void FindPlayer()
    {
        Players = FindObjectsOfType<PlayerInMenu>().ToList();
    }
}
