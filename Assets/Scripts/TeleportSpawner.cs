using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TeleportSpawner : MonoBehaviour
{
    public GameObject Teleport1, Teleport2;
    List<GameObject> teleports = new List<GameObject>();
    public List<GameObject> Areas;

    private void Update()
    {
        Telespawn();
    }
    void Telespawn()
    {
        if(teleports.Count == 2)
        {

        }
        else if(teleports.Count == 0)
        {
           GameObject _Area = Areas[Random.Range(0, Areas.Count)];
           GameObject _Teleport = Instantiate(Teleport1, new Vector3(_Area.GetComponent<GridArea>().TeleportSpawnPoint_X, 0, _Area.GetComponent<GridArea>().TeleportSpawnPoint_Z), Quaternion.identity);
            _Teleport.GetComponent<TestRapidoTeleport>().MyArea = _Area;
            teleports.Add(_Teleport);
            _Teleport.SetActive(true);
        }
        else if (teleports.Count == 1)
        {
            GameObject _Area = BaseSpawnArea();
            GameObject _Teleport = Instantiate(Teleport1, new Vector3(_Area.GetComponent<GridArea>().TeleportSpawnPoint_X, 0, _Area.GetComponent<GridArea>().TeleportSpawnPoint_Z), Quaternion.identity);
            _Teleport.GetComponent<TestRapidoTeleport>().MyArea = _Area;
            teleports.Add(_Teleport);
            _Teleport.SetActive(true);
        }
       
    }

    GameObject BaseSpawnArea()
    {
        return Areas[10 - (teleports[teleports.Count - 1].GetComponent<TestRapidoTeleport>().MyArea.GetComponent<GridArea>().AreaID + 1)];
    }

    GameObject OrdinarySpawnArea()
    {
        GameObject _BaseArea = BaseSpawnArea();
        List<GameObject> _SpawnAreas = new List<GameObject>();
        if(_BaseArea.GetComponent<GridArea>().AreaID + 3 < 10 && _BaseArea.GetComponent<GridArea>().AreaID + 3 != 5)
        {
            _SpawnAreas.Add(Areas[(teleports[teleports.Count - 1].GetComponent<TestRapidoTeleport>().MyArea.GetComponent<GridArea>().AreaID - 1) + 3]);
        }
        else
        {

        }

        if (_BaseArea.GetComponent<GridArea>().AreaID - 3 > 0 && _BaseArea.GetComponent<GridArea>().AreaID - 3 != 5)
        {
            _SpawnAreas.Add(Areas[(teleports[teleports.Count - 1].GetComponent<TestRapidoTeleport>().MyArea.GetComponent<GridArea>().AreaID - 1) - 3]);
        }
        else
        {

        }

        return _SpawnAreas[Random.Range(0, _SpawnAreas.Count)];
    }
}
