using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int Life;
    // Start is called before the first frame update
    void Start()
    {
        Life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Life <= 0)
        {
            Destroy(this.gameObject, 0.5f);
        }
    }
}
