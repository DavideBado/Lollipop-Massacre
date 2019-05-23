using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellPrefScript : MonoBehaviour
{
    public List<Material> Materials;
    List<Agent> agents = new List<Agent>();
    int area;
    GameManager m_GameManager;
   
    public ItemData GetData()
    {
        ItemData itemData = new ItemData()
        {
            GridPosition = transform.position,
            ItemType = ItemData.Type.Player,
        };

        return itemData;
    }

    private void OnEnable()
    {
        m_GameManager = FindObjectOfType<GameManager>();
        m_GameManager.CleanTiles += CleanTile;
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.GetComponent<PlayerData>() != null)
    //    {
    //        other.transform.parent = transform.parent;
    //        //if (other.GetComponent<Agent>().PlayerID == 1)
    //        //{
    //        //    GetComponent<MeshRenderer>().material = Materials[1];
    //        //}
    //        //else if (other.GetComponent<Agent>().PlayerID == 2)
    //        //{
    //        //    GetComponent<MeshRenderer>().material = Materials[2];
    //        //}
    //    }
    //    //else
    //    //{
    //    //    GetComponent<MeshRenderer>().material = Materials[0];
    //    //}
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.GetComponent<PlayerData>() != null)
    //    {
    //        GetComponent<MeshRenderer>().material = Materials[0];

    //    }
    //}

    public void CleanTile()
    {
        FindPlayers();

        bool m_agentHere = false;

        foreach (Agent _agent in agents)
        {
            if(_agent.transform.position == transform.position)
            {
				_agent.transform.parent = transform.parent;
				m_agentHere = true;
                if(_agent.PlayerID == 1)
                {
                    GetComponent<MeshRenderer>().material = Materials[1];
                }
                else if (_agent.PlayerID == 2)
                {
                    GetComponent<MeshRenderer>().material = Materials[2];
                }
            }            
        }
        if (m_agentHere == false)
        {
            GetComponent<MeshRenderer>().material = Materials[0];
        }
    }

    void FindPlayers()
    {
        agents = FindObjectsOfType<Agent>().ToList();
    }
}