using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LifeManager : MonoBehaviour
{
    public bool OnShield = false;
    public int Life = 3;
    GameManager GameManager;   
    bool CanRespawn = true;
    // Start is called before the first frame update
    private void Start()
    {
        Life = 3;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        DieNow();
    }

    void DieNow()
    {
        if (Life <= 0) // Se la vita è minore o uguale a 0
        {
            Destroy(this.gameObject, 0.5f); // Lascia il tempo alla UI di aggiornare la vita e poi elimina il cadavere
            if (CanRespawn == true)
            {
                GameManager.NextPlease(this.gameObject);
                CanRespawn = false;               
            }
        }
    }
}
