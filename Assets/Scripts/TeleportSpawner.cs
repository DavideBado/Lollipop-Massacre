using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TeleportSpawner : MonoBehaviour
{
    public GameObject Teleport1, Teleport2;
    public List<GameObject> teleports = new List<GameObject>();
    public List<GameObject> Areas;
    public List<int> ExAreas = new List<int>();

    //private void Start()
    //{
    //    foreach (int _exID in ExAreas)
    //    {
    //        foreach (GameObject _area in Areas)
    //        {
    //            if(_area.GetComponent<GridArea>().AreaID == _exID)
    //            {
    //                Areas.Remove(_area);
    //            }
    //        } 
    //    }
    //}

    public void Telespawn()
    {
        if(teleports.Count == 2)
        {
            GridArea _Area = OrdinarySpawnArea();
            teleports[0].transform.position = new Vector3(_Area.TeleportSpawnPoint_X, 0, _Area.TeleportSpawnPoint_Z);
            teleports[0].GetComponent<TelePortal>().MyArea = _Area.gameObject;
            GameObject _teleport = teleports[0]; 
            teleports.Remove(_teleport);
            teleports.Add(_teleport);
        }
        else if(teleports.Count == 0)
        {
           GameObject _Area = Areas[Random.Range(0, Areas.Count)];
           GameObject _Teleport = Instantiate(Teleport1, new Vector3(_Area.GetComponent<GridArea>().TeleportSpawnPoint_X, 0, _Area.GetComponent<GridArea>().TeleportSpawnPoint_Z), Quaternion.identity);
            _Teleport.GetComponent<TelePortal>().MyArea = _Area;
            teleports.Add(_Teleport);
            _Teleport.SetActive(true);
        }
        else if (teleports.Count == 1)
        {
            GridArea _Area = OrdinarySpawnArea();
            GameObject _Teleport = Instantiate(Teleport2, new Vector3(_Area.TeleportSpawnPoint_X, 0, _Area.TeleportSpawnPoint_Z), Quaternion.identity);
            _Teleport.GetComponent<TelePortal>().MyArea = _Area.gameObject;
            teleports.Add(_Teleport);
            _Teleport.SetActive(true);
        }       
    }

    GameObject BaseSpawnArea()
    {
        return Areas[10 - (teleports[teleports.Count - 1].GetComponent<TelePortal>().MyArea.GetComponent<GridArea>().AreaID + 1)];
    }

    GridArea OrdinarySpawnArea()
    {
        GameObject _BaseArea = BaseSpawnArea();
        List<GameObject> _SpawnAreas = new List<GameObject>();
        if(_BaseArea != teleports[0].GetComponent<TelePortal>().MyArea && _BaseArea.GetComponent<GridArea>().AreaID != 5)
        {
            _SpawnAreas.Add(_BaseArea);
        }

        if(_BaseArea.GetComponent<GridArea>().AreaID + 3 < 10 && _BaseArea.GetComponent<GridArea>().AreaID + 3 != 5)
        {
            if (Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) + 3] != teleports[0].GetComponent<TelePortal>().MyArea)
            {
                _SpawnAreas.Add(Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) + 3]);
            }
        }
        else
        {
            if((_BaseArea.GetComponent<GridArea>().AreaID % 3 != 0)  && _BaseArea.GetComponent<GridArea>().AreaID + 1 != 5)
            {
                if (Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) + 1] != teleports[0].GetComponent<TelePortal>().MyArea)
                {
                    _SpawnAreas.Add(Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) + 1]);
                }
            }

            if (((_BaseArea.GetComponent<GridArea>().AreaID) % 3 != 1) && _BaseArea.GetComponent<GridArea>().AreaID - 1 != 5)
            {
                if (Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) - 1] != teleports[0].GetComponent<TelePortal>().MyArea)
                {
                    _SpawnAreas.Add(Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) - 1]);
                }
            }
        }

        if (_BaseArea.GetComponent<GridArea>().AreaID - 3 > 0 && _BaseArea.GetComponent<GridArea>().AreaID - 3 != 5)
        {
            if (Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) - 3] != teleports[0].GetComponent<TelePortal>().MyArea)
            {
                _SpawnAreas.Add(Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) - 3]);
            }
        }
        else
        {
            if (((_BaseArea.GetComponent<GridArea>().AreaID) % 3 != 0) && _BaseArea.GetComponent<GridArea>().AreaID + 1 != 5)
            {
                if (Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) + 1] != teleports[0].GetComponent<TelePortal>().MyArea)
                {
                    _SpawnAreas.Add(Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) + 1]);
                }
            }

            if (((_BaseArea.GetComponent<GridArea>().AreaID) % 3 != 1) && _BaseArea.GetComponent<GridArea>().AreaID - 1 != 5)
            {
                if (Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) - 1] != teleports[0].GetComponent<TelePortal>().MyArea)
                {
                    _SpawnAreas.Add(Areas[(_BaseArea.GetComponent<GridArea>().AreaID - 1) - 1]);
                }             
            }
        }
        GridArea _SpawnArea = _SpawnAreas[Random.Range(0, _SpawnAreas.Count)].GetComponent<GridArea>();
        return _SpawnArea;         
    }
}
