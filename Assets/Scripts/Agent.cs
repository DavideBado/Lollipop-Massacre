using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;


public class Agent : MonoBehaviour {
    //************Variabili per test abilità***********
    public KeyCode BigD1, Drain2, Stun3, Venom4, Charge5;
    public int PlayerType = 0;
    //*************************************************
    public Vector3 SavedlookAt, RayCenter, RayLeft, RayRight;
    public bool MyTurn, OnTheRoad = false;
    public int x, x2;
    public int y, y2;   
    public BaseGrid grid;
    public Collider BasicAtt;
    public TMPro.TextMeshProUGUI Lifetext;
    public GameObject respawn;
    public GridConfigData configGrid;
    public RespawnController RespawnController;
    List<PlayerData> Players = new List<PlayerData>();
    List<Wall> Walls = new List<Wall>();
    public GameManager GameManager;
    public bool RotUp = false, RotDown = false, RotLeft = false, RotRight = false, ImStunned = false, imDrained = false, StartDrain;
    public int Mana = 0;
    public bool OhStunnedShit;
    public float AgentSpeed;
    public Rigidbody rg;
    public GameObject StunPS, PoisonPS, DrainPS;

    private void Start()
    {
        InStart();
        rg = GetComponent<Rigidbody>();
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
		Sicura();
		Movement(); // Muove il giocatore
        APlayerTypeSelector();
        RayDirections();
        Stunname();
        ImDrained();
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
        AgentSpeed = GameObject.Find("GameManager").GetComponent<GameManager>().Speed;
        Mana = 1;
        if (GameManager.Spawn1 == true) // Se il gioco è appena iniziato
        {
            transform.position = respawn.transform.position; // Posiziona il giocatore nella posizione di partenza            
        }

        x = (int)(transform.position.x);
        y = (int)(transform.position.z);
      
    }
	#endregion

	#region Update
	void Sicura()
	{
		if (MyTurn == false) // Se non è il tuo turno
		{
			BasicAtt.enabled = false; // Metti via le armi
		}
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
        if (Input.GetKeyDown(Charge5))
        {
            PlayerType = 5;
        }
    }
    void Movement() // Muove il giocatore
    {
        if (grid) // Check if we have a grid
        {

            if (checkIfPosEmpty() && ImStunned == false) // Now if the cell is free
            { // Move the player && save x && y
                BasicAtt.enabled = false; // Assicurati di avere le armi nel fodero
                 // Spostati verso la casella selezionata alla velocità di Speed unità al secondo
                transform.position = Vector3.MoveTowards(transform.position, grid.GetWorldPosition(x, y),
                AgentSpeed * Time.deltaTime);
                if (transform.position == grid.GetWorldPosition(x, y)) // Se hai raggiunto la tua destinazione
                {
                    AgentSpeed = GameObject.Find("GameManager").GetComponent<GameManager>().Speed;
                    // Salva le coordinate della posizione attuale
                    x2 = x;
                    y2 = y;
                    OnTheRoad = false;
                    FindObjectOfType<GameManager>().TimerOn = true;
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

    void RayDirections()
    {
        if(RotUp == true)
        {
            SavedlookAt = new Vector3(0, 0, 1);
            RayLeft = transform.position + new Vector3(-1, 0, 0.5f);
            RayCenter = transform.position + new Vector3(0, 0, 0.5f);
            RayRight = transform.position + new Vector3(1, 0, 0.5f);
        }
        if(RotLeft == true)
        {
            SavedlookAt = new Vector3(-1, 0, 0);
            RayLeft = transform.position + new Vector3(-0.5f, 0, -1);
            RayCenter = transform.position + new Vector3(-0.5f, 0, 0);
            RayRight = transform.position + new Vector3(-0.5f, 0, 1);
        }
        if(RotDown == true)
        {
            SavedlookAt = new Vector3(0, 0, -1);
            RayLeft = transform.position + new Vector3(-1, 0, -0.5f);
            RayCenter = transform.position + new Vector3(0, 0, -0.5f);
            RayRight = transform.position + new Vector3(1, 0, -0.5f);
        }
        if(RotRight == true)
        {
            SavedlookAt = new Vector3(1, 0, 0);
            RayLeft = transform.position + new Vector3(0.5f, 0, 1);
            RayCenter = transform.position + new Vector3(0.5f, 0, 0);
            RayRight = transform.position + new Vector3(0.5f, 0, -1);
        }
    }

    void Stunname()
    {
        if(ImStunned == true)
        {
            StunPS.SetActive(true);
        }
        else
        {
            StunPS.SetActive(false);
        }
        if (ImStunned == true && MyTurn == true)
        {
            OhStunnedShit = true;
        }
        if (OhStunnedShit == true && MyTurn == false)
        {
            OhStunnedShit = false;
            ImStunned = false;
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
        Vector3 lookAt = grid.GetWorldPosition(x,y);
        
        float AngleRad = Mathf.Atan2(lookAt.x - this.transform.position.x, lookAt.z - this.transform.position.z);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        transform.rotation = Quaternion.Euler(0, AngleDeg, 0);
    }
	#region Input

	public void Up() //Trasforma la chiamata del manager in una richiesta di movimento
	{

		if (y < (configGrid.DimY - 1) && OnTheRoad == false && MyTurn == true && ImStunned == false)
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
		if (x > 0 && OnTheRoad == false && MyTurn == true && ImStunned == false)
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
		if (y > 0 && OnTheRoad == false && MyTurn == true && ImStunned == false)
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
		if (x < (configGrid.DimX - 1) && OnTheRoad == false && MyTurn == true && ImStunned == false)
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
		if (MyTurn == true && ImStunned == false && GameManager.CanAttack == true) // Se è il mio turno
		{
			BasicAtt.enabled = true; // Attiva il collider di attacco
            GameManager.CanAttack = false; // Non posso più attaccare
            rg.transform.DOMove(transform.position + SavedlookAt * 0.1f, 0.1f)
                .SetAutoKill();
               



        }
		else BasicAtt.enabled = false;
	}

    public void Poisoned()
    {
        if(GetComponentInChildren<Poison>() != null)
        {
            PoisonPS.SetActive(true);
        }
        else
        {
            PoisonPS.SetActive(false);
        }
    }

    #endregion

    public void ImDrained()
    {        
        if (imDrained == true && StartDrain == GameManager.Turn)
        {
            DrainPS.SetActive(true);
        }
        else 
        { if (StartDrain != GameManager.Turn)
            {
                imDrained = false;
                DrainPS.SetActive(false);
            }
        }
    }
}