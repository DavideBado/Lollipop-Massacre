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


    public Vector3 FindAGoodPoint(PlayerData _player)
    {
        FindAllThePoints();
        longestDistance = 0.0f;
        farthestSpawnPoint = Vector3.zero;
        FindAllThePlayers(); // trova tutti i player vivi
       
                foreach (SpawnPoint point in SpawnPoints) // E per ogni punto di possibile spawn
                {
                    distance = Vector3.Distance(point.transform.position, _player.transform.position); // Confronta la posizione del punto con quella del player
            Debug.Log("Player:" + _player.name + " Player X:" + _player.transform.position.x + ", Player Y:" + _player.transform.position.z
                + ", Point" + point.name + ", PointX:" + point.transform.position.x + ", PointY:" + point.transform.position.z
                + ", Distance:" + distance);

                    if (distance > longestDistance) // Se la distanza attuale è la maggiore tra quelle misurate fino ad ora
                    {
                        longestDistance = distance; // Salvala come distanza maggiore
                        farthestSpawnPoint = point.transform.position; // Salva anche il vettore                    
                    }
                   //Debug.Log("Player:" + player.name + "Player position:" + player.transform.position + " point:" + point.name + ", distance:" + distance + ", longestD:" + longestDistance);
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
