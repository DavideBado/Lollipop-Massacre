using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PoisonVFXController : MonoBehaviour
{
    public int Speed;
    private void OnEnable()
    {
        if (GetComponentInParent<Venom>().Enemy != null)
        {
            Move(GetComponentInParent<Venom>().Enemy.transform); 
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private void Move(Transform _target)
    {
        transform.DOMove(_target.position, (Vector3.Distance(GetComponentInParent<Agent>().transform.position, _target.position) / Speed)).OnComplete(GoHome);
    }

    private void GoHome()
    {
        transform.position = new Vector3(GetComponentInParent<Agent>().transform.position.x, 5, GetComponentInParent<Agent>().transform.position.z);
        GetComponentInParent<Venom>().Enemy = null;
    }
}
