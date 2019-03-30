using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInMenu : MonoBehaviour
{
    public int PlayerID;
    public int SpriteID = 1;
    List<CharaSprites> Sprites = new List<CharaSprites>();
    List<CharaSprites> CharaSprites = new List<CharaSprites>();


    private void OnEnable()
    {
        CharaSprites = FindObjectsOfType<CharaSprites>().ToList();       
    }

    public void Up()
    {
        if(SpriteID != 1 && SpriteID != 2 && SpriteID != 3)
        {
            SpriteID -= 3;
        }
    }

    public void Down()
    {
        if(SpriteID != 4 && SpriteID != 5 && SpriteID != 6)
        {
            SpriteID += 3;
        }
    }

    public void Left()
    {
        if(SpriteID != 1 && SpriteID != 4)
        {
            SpriteID--;
        }

    }

    public void Right()
    {
        if (SpriteID != 3 && SpriteID != 6)
        {
            SpriteID++;
        }
    }

    public void BasicAttack()
    {
        // Aggiungi alla lista e visualizza sprite grande nella preview del party --------> prima bisogna risolvere il bug del setactive con la lista in game
        foreach(CharaSprites charaSprite in CharaSprites)
        {
            if (PartyData.PartyCount(PlayerID) != -1 && PartyData.PartyCount(PlayerID) < 3)
            {
                if (charaSprite.SpriteID == SpriteID)
                {
                    PartyData.AddToParty(PlayerID, charaSprite.Character);
                }
            }
        }
    }
        
}
