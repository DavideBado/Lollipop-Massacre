using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public bool OnShield = false;
    public int Life = 3;
    // Start is called before the first frame update
    
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
        }
    }
}
