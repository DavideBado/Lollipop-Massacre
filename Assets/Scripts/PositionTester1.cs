using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;
using System.Linq;

public class PositionTester1 : MonoBehaviour {
    bool _Round, OnTheRoad = false;
    public int x, x2;
    public int y, y2;
    public BaseGrid grid;
    public Collider BasicAtt;
    public Text Lifetext;
    public GameObject respawn;
    public GridConfigData configGrid;
    public RespawnController RespawnController;
    List<Player> Players = new List<Player>();
    List<Wall> Walls = new List<Wall>();
    public GameManager GameManager;
    bool RotUp = false, RotDown = false, RotLeft = false, RotRight = false;
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
        Spawn(); // Posizionati nella tua posizione iniziale
        FirstSaveXY(); // Salva le coordinate della tua posizione
    }

    void InUpdate()
    {
        RoundCheck(); // Controlla se è il tuo turno
        TextUpdate(); // Aggiorna i testi a schermo
        Sicura(); // Evita attacchi scorretti
        Movement(); // Sposta il player
    }

    #region START
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

    #region UPDATE
    void RoundCheck()
    {
        _Round = GameObject.Find("GameManager").GetComponent<GameManager>().Turn; // Controlla i round contati dal manager
    }

    void TextUpdate() // Aggiorna i testi a schermo
    {
        Lifetext.text = "P2 Life:" + GetComponent<LifeManager>().Life.ToString(); // Life on screen
    }

    void Sicura() // Assicura che il collider per l'attacco base non sia attivo durante il turno avversario
    {
        if (_Round == true)
        {

            BasicAtt.enabled = false;
        }
    }

    void Movement()
    {

        if (grid) // Check if we have a grid
        {
          
            if (checkIfPosEmpty()) // Now if the cell is free
            { // Move the player && save x && y
                BasicAtt.enabled = false; // Assicurati che l'attacco base non sia attivo

                // Muove il player verso la casella selezionata alla velocità di Speed unità/s
                transform.position = Vector3.MoveTowards(transform.position, grid.GetWorldPosition(x, y),
                GameObject.Find("GameManager").GetComponent<GameManager>().Speed * Time.deltaTime);
                if (transform.position == grid.GetWorldPosition(x, y)) // Se sono arrivato a destinazione
                {
                    // Aggiorna i valori di x e y salvati
                    x2 = x;
                    y2 = y;
                    OnTheRoad = false;
                }
            }
            else // Se invece non mi sono potuto spostare
            { // Carica i vecchi valori di x e y
                x = x2;
                y = y2;
                OnTheRoad = false;
            }
        }
    }
    #endregion

    #region INPUT // Ascoltano le chiamate del inputmanager
    public void Up() //Trasforma la chiamata del manager in una richiesta di movimento
    {
        if (y < (configGrid.DimY - 1) && OnTheRoad == false && _Round == false)
        {
            RotDown = false; RotLeft = false; RotRight = false;
            OnTheRoad = true;
            y++;
            Rotation();
            if (RotUp == false)
            {
                y--;
                RotUp = true;
            }
        }
    }
    public void Left()
    {
        if (x > 0 && OnTheRoad == false && _Round == false)
        {
            RotUp = false; RotDown = false; RotRight = false;
            OnTheRoad = true;
            x--;
            Rotation();
            if (RotLeft == false)
            {
                x++;
                RotLeft = true;
            }
        }
    }
    public void Down()
    {
        if (y > 0 && OnTheRoad == false && _Round == false)
        {
            RotUp = false; RotLeft = false; RotRight = false;
            OnTheRoad = true;
            y--;
            Rotation();
            if (RotDown == false)
            {
                y++;
                RotDown = true;
            }
        }
    }
    public void Right()
    {
        if (x < (configGrid.DimX - 1) && OnTheRoad == false && _Round == false)
        {
            RotUp = false; RotDown = false; RotLeft = false;
            OnTheRoad = true;
            x++;
            Rotation();
            if (RotRight == false)
            {
                x--;
                RotRight = true;
            }
        }
    }
    public void BasicAttack()
    {
        if (_Round == false) // Se è il mio turno
        {
            BasicAtt.enabled = true; // Attiva il collider di attacco
        }
        else BasicAtt.enabled = false;
    }
    #endregion 

    public bool checkIfPosEmpty() // This check if the cell is free
    {
        GetAllInterestingData(); // Trova tutti gli oggetti che potrebbero interferire con il movimento
        foreach (var item in Players)
        {
           if(grid.GetWorldPosition(x, y) == item.transform.position) // Controlla se la cella è occupata da un altro giocatore
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
        Players = FindObjectsOfType<Player>().ToList();

        // Creo una lista di tutti i Wall presenti nel livello.
        Walls = FindObjectsOfType<Wall>().ToList();

    }

    void Rotation()
    {
        Vector3 lookAt = grid.GetWorldPosition(x, y);

        float AngleRad = Mathf.Atan2(lookAt.x - this.transform.position.x, lookAt.z - this.transform.position.z);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        transform.rotation = Quaternion.Euler(0, AngleDeg, 0);
    }
}

