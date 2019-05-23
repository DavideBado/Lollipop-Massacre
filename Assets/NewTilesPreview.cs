using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTilesPreview : MonoBehaviour
{
    GameManager m_GameManager;
    public CellPrefScript _Cell;
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<CellPrefScript>() != null)
        {
            _Cell = other.GetComponent<CellPrefScript>();
            GetComponent<Collider>().enabled = false;
        }
    }

    private void OnEnable()
    {
        m_GameManager = FindObjectOfType<GameManager>();
        m_GameManager.UpdateTilesMat += UpdateMaterial;
    }

    private void UpdateMaterial()
    {
        if (_Cell != null)
            GetComponent<MeshRenderer>().material = _Cell.GetComponent<MeshRenderer>().material;
    }
}
