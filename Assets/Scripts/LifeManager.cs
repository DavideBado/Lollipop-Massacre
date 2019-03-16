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
        Life = 6;
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
            if (CanRespawn == true)
            {
                GameManager.NextPlease(gameObject);
                CanRespawn = false;
            }
            Destroy(gameObject); // Lascia il tempo alla UI di aggiornare la vita e poi elimina il cadavere
           
        }
    }
}
