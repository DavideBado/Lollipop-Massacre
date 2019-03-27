using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BigD : MonoBehaviour
{
    GameManager Manager;
    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }
    public void Ability()

    {
        if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 1 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true)

        {

            RaycastHit hit;

            if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))

            {

                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);

                if (hit.transform.tag == "Player" && hit.transform != transform)

                {

                    Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    hit.transform.GetComponent<LifeManager>().Life -= 4;

                }

            }

            if (Physics.Raycast(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))

            {

                Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);

                if (hit.transform.tag == "Player" && hit.transform != transform)

                {

                    Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);

                    hit.transform.GetComponent<LifeManager>().Life -= 4;
                }

            }

            if (Physics.Raycast(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))

            {

                Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);

                if (hit.transform.tag == "Player" && hit.transform != transform)

                {

                    Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);

                    hit.transform.GetComponent<LifeManager>().Life -= 4;

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

    public void Preview()
    {
        float _lookX = GetComponent<Agent>().SavedlookAt.x;
        float _lookY = GetComponent<Agent>().SavedlookAt.z;
        Vector3 playerPosition = transform.position;
        if (GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 1 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true)

        {
            List<CellPrefScript> cells = new List<CellPrefScript>();

            cells = FindObjectsOfType<CellPrefScript>().ToList();

            RaycastHit hit;

            if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))
            {
                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.black);
                CellsGreenInRay(hit, cells, playerPosition);
            }
            else
            {

                if (_lookX != 0)
            {
                if (_lookX > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((((cell.transform.position.x == (transform.position.x + 1) ||
                            cell.transform.position.x == (transform.position.x + 2)))) &&
                            ((cell.transform.position.z == (transform.position.z))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }
                else if (_lookX < 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if (((cell.transform.position.x == (transform.position.x - 1) || cell.transform.position.x == (transform.position.x - 2))) &&
                            ((cell.transform.position.z == (transform.position.z))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }

            }
            else if (_lookY != 0)
            {

                if (_lookY < 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((cell.transform.position.z == (transform.position.z - 1) || cell.transform.position.z == (transform.position.z - 2)) &&
                            ((cell.transform.position.x == (transform.position.x))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }
                else if (_lookY > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((cell.transform.position.z == (transform.position.z + 1) || cell.transform.position.z == (transform.position.z + 2)) &&
                            ((cell.transform.position.x == (transform.position.x))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }

            }
        }

        if (Physics.Raycast(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))
        {
            CellsGreenInRay(hit, cells, playerPosition);
        }
        else
        {

            if (_lookX != 0)
            {
                if (_lookX < 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((cell.transform.position.x == (transform.position.x - 1) || cell.transform.position.x == (transform.position.x - 2)) &&
                            ((cell.transform.position.z == (transform.position.z - 1))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }
                else if (_lookX > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((cell.transform.position.x == (transform.position.x + 1) || cell.transform.position.x == (transform.position.x + 2)) &&
                            ((cell.transform.position.z == (transform.position.z + 1))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }
            }
            else if (_lookY != 0)
            {
                if (_lookY < 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((cell.transform.position.z == (transform.position.z - 1) || cell.transform.position.z == (transform.position.z - 2)) &&
                            ((cell.transform.position.x == (transform.position.x + 1))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }
                else if (_lookY > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((cell.transform.position.z == (transform.position.z + 1) || cell.transform.position.z == (transform.position.z + 2)) &&
                            ((cell.transform.position.x == (transform.position.x - 1))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }
            }
        }

            if (Physics.Raycast(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))
            {
                CellsGreenInRay(hit, cells, playerPosition);
            }
            else
            {

                if (_lookX != 0)
            {
                if (_lookX < 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((cell.transform.position.x == (transform.position.x - 1) || cell.transform.position.x == (transform.position.x - 2)) &&
                            ((cell.transform.position.z == (transform.position.z + 1))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }
                else if (_lookX > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((cell.transform.position.x == (transform.position.x + 1) || cell.transform.position.x == (transform.position.x + 2)) &&
                            ((cell.transform.position.z == (transform.position.z - 1))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }
            }
            else if (_lookY != 0)
            {
                if (_lookY < 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((cell.transform.position.z == (transform.position.z - 1) || cell.transform.position.z == (transform.position.z - 2)) &&
                            ((cell.transform.position.x == (transform.position.x - 1))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }
                else if (_lookY > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if ((cell.transform.position.z == (transform.position.z + 1) || cell.transform.position.z == (transform.position.z + 2)) &&
                            ((cell.transform.position.x == (transform.position.x + 1))))
                        {
                            cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

                        }
                    }
                }
            }
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

    void CellsGreenInRay(RaycastHit hit, List<CellPrefScript> cells, Vector3 playerPosition)
    {
        foreach (CellPrefScript cell in cells)
        {
            if ((((playerPosition.x < cell.transform.position.x && cell.transform.position.x < hit.transform.position.x) ||
               (playerPosition.x > cell.transform.position.x && cell.transform.position.x > hit.transform.position.x)) &&
               (cell.transform.position.z == hit.transform.position.z)) ||
               (((playerPosition.z < cell.transform.position.z && cell.transform.position.z < hit.transform.position.z) ||
               (playerPosition.z > cell.transform.position.z && cell.transform.position.z > hit.transform.position.z)) &&
               (cell.transform.position.x == hit.transform.position.x)))
            {
                cell.GetComponentInParent<CellPrefScript>().Color = Color.green;

            }
        }
    }
}

