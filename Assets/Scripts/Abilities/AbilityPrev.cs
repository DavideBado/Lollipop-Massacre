using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AbilityPrev : MonoBehaviour
{
    List<CellPrefScript> cells = new List<CellPrefScript>();

   public void Preview(RaycastHit _hit, Vector3 _playerPosition)
    {
        cells = FindObjectsOfType<CellPrefScript>().ToList();

        foreach (CellPrefScript cell in cells)
        {
            if((((_playerPosition.x < cell.transform.position.x && cell.transform.position.x <= _hit.transform.position.x )||
               (_playerPosition.x > cell.transform.position.x && cell.transform.position.x >= _hit.transform.position.x )) &&
               (cell.transform.position.z == _hit.transform.position.z))                                                  ||               
               (((_playerPosition.z < cell.transform.position.z && cell.transform.position.z <= _hit.transform.position.z )||
               (_playerPosition.z > cell.transform.position.z && cell.transform.position.z >= _hit.transform.position.z)) &&
               (cell.transform.position.x == _hit.transform.position.x)))
            {
                
                
                    cell.GetComponentInParent<CellPrefScript>().Color = Color.green;
               
            }
        }

    }
}
