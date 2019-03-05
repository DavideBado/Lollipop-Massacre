using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;
using System.Linq;

public class Agent : MonoBehaviour {
    //************Variabili per test abilità***********
    public KeyCode BigD1, Drain2, Stun3, Venom4;
    public int PlayerType = 0;
    //*************************************************
    public Vector3 lookAt;
    public bool _Round, OnTheRoad = false;
    public int x, x2;
    public int y, y2;   
    public BaseGrid grid;
    public Collider BasicAtt;
    public Text Lifetext;
    public GameObject respawn;
    public GridConfigData configGrid;
    public RespawnController RespawnController;
    List<PlayerData> Players = new List<PlayerData>();
    List<Wall> Walls = new List<Wall>();
    public GameManager GameManager;
    public bool RotUp = false, RotDown = false, RotLeft = false, RotRight = false;
    public int Mana = 0;
    private void Start()
    {
        InStart();
    }
    // Update is called once per frame
    void Update()
    {
        InUpdate();
    }

    void InStart()
    {
        Spawn(); // Posiziona il giocatore
        FirstSaveXY(); // Salvo le coordinate della mia posizione
    }

    public void InUpdate()
    {
        RoundCheck(); // Controlla i round       
        Movement(); // Muove il giocatore
        APlayerTypeSelector();
    }

    #region Start
    
    void FirstSaveXY()
    {
        // x2 && y2 Start = null, the next code lines change x2 && y2 != null
        x2 = x;
        y2 = y;
    }

    void Spawn()
    {
        if (GameManager.Spawn1 == true) // Se il gioco è appena iniziato
        {
            transform.position = respawn.transform.position; // Posiziona il giocatore nella posizione di partenza            
        }

        x = (int)(transform.position.x);
        y = (int)(transform.position.z);
        //else
        //{
        //    transform.position = RespawnController.FindAGoodPoint();
        //    x = (int)(transform.position.x);
        //    y = (int)(transform.position.z);
        //}
    }
    #endregion

    #region Update
    void RoundCheck()
    {
        _Round = GameObject.Find("GameManager").GetComponent<GameManager>().Round;
    }
    void APlayerTypeSelector()
    {
        if (Input.GetKeyDown(BigD1))
        {
            PlayerType = 1;
        }
        if (Input.GetKeyDown(Drain2))
        {
            PlayerType = 2;
        }
        if (Input.GetKeyDown(Stun3))
        {
            PlayerType = 3;
        }
        if (Input.GetKeyDown(Venom4))
        {
            PlayerType = 4;
        }
    }
    void Movement() // Muove il giocatore
    {
        if (grid) // Check if we have a grid
        {

            if (checkIfPosEmpty()) // Now if the cell is free
            { // Move the player && save x && y
                BasicAtt.enabled = false; // Assicurati di avere le armi nel fodero
                 // Spostati verso la casella selezionata alla velocità di Speed unità al secondo
                transform.position = Vector3.MoveTowards(transform.position, grid.GetWorldPosition(x, y),
                GameObject.Find("GameManager").GetComponent<GameManager>().Speed * Time.deltaTime);
                if (transform.position == grid.GetWorldPosition(x, y)) // Se hai raggiunto la tua destinazione
                {
                    // Salva le coordinate della posizione attuale
                    x2 = x;
                    y2 = y;
                    OnTheRoad = false;
                }
            }
            else // Load the old values of x && y
            {
                x = x2;
                y = y2;
                OnTheRoad = false;
            }
        }
    }
    #endregion

    

    public bool checkIfPosEmpty() // This check if the cell is free
    {
        GetAllInterestingData(); // Trova tutti gli oggetti che potrebbero interferire con il movimento
        foreach (var item in Players)
        {
            if (grid.GetWorldPosition(x, y) == item.transform.position) // Controlla se la cella è occupata da un altro giocatore
            {
                return false;
            }
        }
        foreach (var item in Walls)
        {
            if (grid.GetWorldPosition(x, y) == item.transform.position) // Controlla se la cella è occupata da un muro
            {
                return false;
            }
        }
        return true; // Se invece è libera posso andarci
    }

    public void GetAllInterestingData()
    {
        // Creo una lista di tutti i Player presenti nel livello.
        Players = FindObjectsOfType<PlayerData>().ToList();

        // Creo una lista di tutti i Wall presenti nel livello.
        Walls = FindObjectsOfType<Wall>().ToList();

    }

    public void Rotation()
    {
        lookAt = grid.GetWorldPosition(x,y);

        float AngleRad = Mathf.Atan2(lookAt.x - this.transform.position.x, lookAt.z - this.transform.position.z);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        transform.rotation = Quaternion.Euler(0, AngleDeg, 0);
    }
}