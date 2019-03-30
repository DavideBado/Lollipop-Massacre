using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class Venom : MonoBehaviour
{   
    public GameObject Poison;
    GameManager Manager;
    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }
    public void Ability()
    { if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 4 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.forward * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.forward * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.back, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.back * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.back * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.left, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.left * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.left * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }

            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.right, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }
            if (FindObjectOfType<PickUpsSpawner>().AllManaFull == true)
            {
                FindObjectOfType<GameManager>().PickUpTurnCount = 0;
                FindObjectOfType<PickUpsSpawner>().AllManaFull = false;
            }
            GetComponent<Agent>().Mana--;
            Manager.CanAttack = false;
        }
    }

    void PoisonPower(RaycastHit hit)
    {
        Instantiate(Poison, hit.transform);
        hit.transform.GetComponent<LifeManager>().Life -= 2;
        Debug.Log("{0}", hit.transform);
    }

    public void Preview()
    {
       
        if (GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 4 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)

        {
            CleanPreview();
            float _lookX = GetComponent<Agent>().SavedlookAt.x;
            float _lookY = GetComponent<Agent>().SavedlookAt.z;
            Vector3 playerPosition = transform.position;

            List<CellPrefScript> cells = new List<CellPrefScript>();

            cells = FindObjectsOfType<CellPrefScript>().ToList();

            RaycastHit hit;

            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.forward, out hit, Mathf.Infinity))
            {
                CellsGreenInRay(hit.transform.position, cells, playerPosition);
            }
            else
            {
                CellsGreenInRay(new Vector3(transform.position.x, 0, GetComponent<Agent>().configGrid.DimY), cells, playerPosition);
            }

            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.back, out hit, Mathf.Infinity))
            {
                CellsGreenInRay(hit.transform.position, cells, playerPosition);
            }
            else
            {
                CellsGreenInRay(new Vector3(transform.position.x, 0, -1), cells, playerPosition);
            }

            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.right, out hit, Mathf.Infinity))
            {
                CellsGreenInRay(hit.transform.position, cells, playerPosition);
            }
            else
            {
                CellsGreenInRay(new Vector3(GetComponent<Agent>().configGrid.DimX, 0, transform.position.z), cells, playerPosition);
            }

            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.left, out hit, Mathf.Infinity))
            {
                CellsGreenInRay(hit.transform.position, cells, playerPosition);
            }
            else
            {
                CellsGreenInRay(new Vector3(-1, 0, transform.position.z), cells, playerPosition);
            }
        }
    }

    public void CleanPreview()
    {
        List<CellPrefScript> cells = new List<CellPrefScript>();

        cells = FindObjectsOfType<CellPrefScript>().ToList();

        foreach (CellPrefScript cell in cells)
        {
            cell.GetComponentInParent<CellPrefScript>().Color = cell.GetComponentInParent<CellPrefScript>().BaseColor;
        }
    }

    void CellsGreenInRay(Vector3 HitPosition, List<CellPrefScript> cells, Vector3 playerPosition)
    {
        foreach (CellPrefScript cell in cells)
        {
            if ((((playerPosition.x < cell.transform.position.x && cell.transform.position.x < HitPosition.x)

                ||

               (playerPosition.x > cell.transform.position.x && cell.transform.position.x > HitPosition.x)) &&


               (cell.transform.position.z == HitPosition.z)) ||



               (((playerPosition.z < cell.transform.position.z && cell.transform.position.z < HitPosition.z) ||
               (playerPosition.z > cell.transform.position.z && cell.transform.position.z > HitPosition.z)) &&
               (cell.transform.position.x == HitPosition.x)))
            {
                cell.GetComponentInParent<CellPrefScript>().Color = Color.green;
            }
        }
    }
}
