using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Healthscript : MonoBehaviour
{ 
    public int PickupArea;
    float endvalue = 1;
    private void Start()
    {
        Rotate(endvalue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<LifeManager>() != null)
            {
                other.GetComponent<LifeManager>().Life += 1;
            }
            FindObjectOfType<GameManager>().HealtTurnCount = 0;
            Destroy(gameObject);          
           
        }

    }

    void Rotate(float _end)
    {
        transform.DORotate(new Vector3 (0, _end), 0.01f).OnComplete(UpdateEndValue);
    }

    void UpdateEndValue()
    {
        endvalue ++;
        Rotate(endvalue);
    }
}
