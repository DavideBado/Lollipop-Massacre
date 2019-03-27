using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class RespawnController : MonoBehaviour
{
    float longestDistance = 0.0f;
    float distance = 0.0f;
    Vector3 farthestSpawnPoint;
    List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();
    List<PlayerData> Players = new List<PlayerData>();

    // Start is called before the first frame update
    private void Start()
    {
        FindAllThePoints();
        foreach (SpawnPoint point in SpawnPoints)
        {
            //Debug.Log(point.name);
        }
    }
    public Vector3 FindAGoodPoint()
    {
        longestDistance = 0.0f;
        FindAllThePlayers(); // trova tutti i player vivi
        foreach (PlayerData player in Players) // Per ogni giocatore in scena
        {
            if (player.GetComponent<LifeManager>().Life > 0)
            {
                foreach (SpawnPoint point in SpawnPoints) // E per ogni punto di possibile spawn
                {
                    distance = Vector3.Distance(point.transform.position, player.transform.position); // Confronta la posizione del punto con quella del player

                    if (distance > longestDistance) // Se la distanza attuale è la maggiore tra quelle misurate fino ad ora
                    {
                        longestDistance = distance; // Salvala come distanza maggiore
                        farthestSpawnPoint = point.transform.position; // Salva anche il vettore                    
                    }
                   //Debug.Log("Player:" + player.name + "Player position:" + player.transform.position + " point:" + point.name + ", distance:" + distance + ", longestD:" + longestDistance);
                }
            }
        }
        return farthestSpawnPoint;
    }

    void FindAllThePoints()
    {
        SpawnPoints = FindObjectsOfType<SpawnPoint>().ToList(); // Trova tutti i punti nella scena
    }

    void FindAllThePlayers()
    {
        Players = FindObjectsOfType<PlayerData>().ToList(); // Trova tutti i player nella scena
    }

}
