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
    List<Player> Players = new List<Player>();
    // Start is called before the first frame update

    public Vector3 FindAGoodPoint()
    {
        FindAllThePoints();
        FindAllThePlayers(); // trova tutti i player vivi
        foreach (Player player in Players) // Per ogni giocatore in scena
        {
            foreach (SpawnPoint point in SpawnPoints) // E per ogni punto di possibile spawn
            {
                distance = Vector3.Distance(player.transform.position, point.transform.position); // Confronta la posizione del punto con quella del player

                if (distance > longestDistance) // Se la distanza attuale è la maggiore tra quelle misurate fino ad ora
                {
                    longestDistance = distance; // Salvala come distanza maggiore
                    farthestSpawnPoint = point.transform.position; // Salva anche il vettore
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
        Players = FindObjectsOfType<Player>().ToList(); // Trova tutti i player nella scena
    }

}
