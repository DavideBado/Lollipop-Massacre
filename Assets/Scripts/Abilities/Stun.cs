using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stun : MonoBehaviour
{
    GameManager Manager;
    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }
    public void Ability()
    {
        if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 3 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
            {
                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    hit.transform.GetComponent<Agent>().ImStunned = true;
                    hit.transform.GetComponent<LifeManager>().Damage(2);
                }
            }
            if (Physics.Raycast(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
            {
                Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    hit.transform.GetComponent<Agent>().ImStunned = true;
                    hit.transform.GetComponent<LifeManager>().Damage(2);
                }
            }
            if (Physics.Raycast(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
            {
                Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    hit.transform.GetComponent<Agent>().ImStunned = true;
                    hit.transform.GetComponent<LifeManager>().Damage(2);
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
      
        if (GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 3 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)

        {
            CleanPreview();
            float _lookX = GetComponent<Agent>().SavedlookAt.x;
            float _lookY = GetComponent<Agent>().SavedlookAt.z;
            Vector3 playerPosition = transform.position;

            List<CellPrefScript> cells = new List<CellPrefScript>();

            cells = FindObjectsOfType<CellPrefScript>().ToList();

            RaycastHit hit;

            if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
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
                            if ((cell.transform.position.x > transform.position.x &&
                                cell.transform.position.x <= (transform.position.x + 3)) &&
                                ((cell.transform.position.z == (transform.position.z))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

                            }
                        }
                    }
                    else if (_lookX < 0)
                    {
                        foreach (CellPrefScript cell in cells)
                        {
                            if ((cell.transform.position.x < transform.position.x &&
                                cell.transform.position.x >= (transform.position.x - 3)) &&
                                ((cell.transform.position.z == (transform.position.z))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

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
                            if ((cell.transform.position.z < transform.position.z &&
                                cell.transform.position.z >= (transform.position.z - 3)) &&
                                ((cell.transform.position.x == (transform.position.x))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

                            }
                        }
                    }
                    else if (_lookY > 0)
                    {
                        foreach (CellPrefScript cell in cells)
                        {
                            if ((cell.transform.position.z > transform.position.z &&
                                cell.transform.position.z <= (transform.position.z + 3)) &&
                                ((cell.transform.position.x == (transform.position.x))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

                            }
                        }
                    }

                }
            }

            if (Physics.Raycast(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
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
                            if ((cell.transform.position.x < transform.position.x &&
                                cell.transform.position.x >= (transform.position.x - 3)) &&
                                ((cell.transform.position.z == (transform.position.z - 1))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

                            }
                        }
                    }
                    else if (_lookX > 0)
                    {
                        foreach (CellPrefScript cell in cells)
                        {
                            if ((cell.transform.position.x > transform.position.x &&
                                cell.transform.position.x <= (transform.position.x + 3)) &&
                                ((cell.transform.position.z == (transform.position.z + 1))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

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
                            if ((cell.transform.position.z < transform.position.z &&
                                cell.transform.position.z >= (transform.position.z - 3)) &&
                                ((cell.transform.position.x == (transform.position.x + 1))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

                            }
                        }
                    }
                    else if (_lookY > 0)
                    {
                        foreach (CellPrefScript cell in cells)
                        {
                            if ((cell.transform.position.z > transform.position.z &&
                                cell.transform.position.z <= (transform.position.z + 3)) &&
                                ((cell.transform.position.x == (transform.position.x - 1))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

                            }
                        }
                    }
                }
            }

            if (Physics.Raycast(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 3))
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
                            if ((cell.transform.position.x < transform.position.x &&
                                cell.transform.position.x >= (transform.position.x - 3)) &&
                                ((cell.transform.position.z == (transform.position.z + 1))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

                            }
                        }
                    }
                    else if (_lookX > 0)
                    {
                        foreach (CellPrefScript cell in cells)
                        {
                            if ((cell.transform.position.x > transform.position.x &&
                                cell.transform.position.x <= (transform.position.x + 3)) &&
                                ((cell.transform.position.z == (transform.position.z - 1))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

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
                            if ((cell.transform.position.z < transform.position.z &&
                                cell.transform.position.z >= (transform.position.z - 3)) &&
                                ((cell.transform.position.x == (transform.position.x - 1))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

                            }
                        }
                    }
                    else if (_lookY > 0)
                    {
                        foreach (CellPrefScript cell in cells)
                        {
                            if ((cell.transform.position.z > transform.position.z &&
                                cell.transform.position.z <= (transform.position.z + 3)) &&
                                ((cell.transform.position.x == (transform.position.x + 1))))
                            {
                                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

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
            cell.GetComponent<MeshRenderer>().material = cell.Materials[0];


        }
    }

    void CellsGreenInRay(RaycastHit hit, List<CellPrefScript> cells, Vector3 playerPosition)
    {
        foreach (CellPrefScript cell in cells)
        { if (hit.transform.GetComponent<Agent>() != null)
            {
                if ((((playerPosition.x < cell.transform.position.x && cell.transform.position.x <= hit.transform.position.x) ||
                 (playerPosition.x > cell.transform.position.x && cell.transform.position.x >= hit.transform.position.x)) &&
                 (cell.transform.position.z == hit.transform.position.z)) ||
                 (((playerPosition.z < cell.transform.position.z && cell.transform.position.z <= hit.transform.position.z) ||
                 (playerPosition.z > cell.transform.position.z && cell.transform.position.z >= hit.transform.position.z)) &&
                 (cell.transform.position.x == hit.transform.position.x)))
                {
                    cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

                }
            }
        else if ((((playerPosition.x < cell.transform.position.x && cell.transform.position.x < hit.transform.position.x) ||
                 (playerPosition.x > cell.transform.position.x && cell.transform.position.x > hit.transform.position.x)) &&
                 (cell.transform.position.z == hit.transform.position.z)) ||
                 (((playerPosition.z < cell.transform.position.z && cell.transform.position.z < hit.transform.position.z) ||
                 (playerPosition.z > cell.transform.position.z && cell.transform.position.z > hit.transform.position.z)) &&
                 (cell.transform.position.x == hit.transform.position.x)))
            {
                cell.GetComponent<MeshRenderer>().material = cell.Materials[3];

            }
        }
    }
}
