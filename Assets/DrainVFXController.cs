using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DrainVFXController : MonoBehaviour
{
    public int Speed;
    private void OnEnable()
    {
        if (GetComponentInParent<Drain>().Enemy != null)
        {
            Move(GetComponentInParent<Agent>().transform);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private void Move(Transform _target)
    {
        transform.DOMove(_target.position, (Vector3.Distance(GetComponentInParent<Drain>().Enemy.transform.position, _target.position) / Speed)).OnComplete(GoHome);
    }

    private void GoHome()
    {
        transform.position = new Vector3(GetComponentInParent<Agent>().transform.position.x, 5, GetComponentInParent<Agent>().transform.position.z);
        GetComponentInParent<Drain>().Enemy = null;
    }
}
