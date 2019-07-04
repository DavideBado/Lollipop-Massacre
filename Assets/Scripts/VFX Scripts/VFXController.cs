using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public List<GameObject> BaseAttackVFX = new List<GameObject>();
    public List<GameObject> AbilityVFX = new List<GameObject>();
    public List<GameObject> BloodVFX = new List<GameObject>();

    public void ActiveVFX(List<GameObject> _VFXgameObjects)
    {
        foreach (GameObject _VFXgameObject in _VFXgameObjects)
        {
            _VFXgameObject.SetActive(true);
        }
    }

    public void DeactivateVFX(List<GameObject> _VFXgameObjects)
    {
        foreach (GameObject _VFXgameObject in _VFXgameObjects)
        {
            _VFXgameObject.SetActive(false);
        }
    }
}
