using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BigD : MonoBehaviour
{
    float Timer;
    bool onAttack;
    GameManager Manager;
    private void Start()
    {
        Timer = 1f;
        Manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (onAttack == true)
        {
            Timer -= Time.deltaTime;
            Manager.Pause = true;
            //Manager.UpdateTilesMat();
            NewPreview(Manager.CellAttackMaterial);
            if (Timer <= 0)
            {
                onAttack = false;
                Manager.Pause = false;
                Manager.CleanTiles();
                Manager.UpdateTilesMat();
                Timer = 1f;
            }

        }
    }

    public void Ability()

    {
        if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 1 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)

        {
            GetComponentInChildren<AnimationController>().Ability();
            //FindObjectOfType<SliderBehaviour>().GetComponentInChildren<AbilityIcon>().OnAbility(1);
            RaycastHit hit;

            if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))

            {
                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);

                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    onAttack = true;
                    Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    //FindObjectOfType<PointerSpritePosition>().GetComponentInChildren<AbilityIcon>().OnAbility(1);
                    hit.transform.GetComponent<LifeManager>().DamageAmount = 2;
                    hit.transform.GetComponent<LifeManager>().Enemy = GetComponent<Agent>();
                    hit.transform.GetComponent<LifeManager>().BaseAttack = false;
                    GetComponentInChildren<AnimationController>().Enemy = hit.transform.GetComponent<LifeManager>();
                }

            }

            if (Physics.Raycast(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))

            {

                Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);

                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    onAttack = true;
                    Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    //FindObjectOfType<PointerSpritePosition>().GetComponentInChildren<AbilityIcon>().OnAbility(1);
                    hit.transform.GetComponent<LifeManager>().DamageAmount = 2;
                    hit.transform.GetComponent<LifeManager>().Enemy = GetComponent<Agent>();
                    hit.transform.GetComponent<LifeManager>().BaseAttack = false;
                    GetComponentInChildren<AnimationController>().Enemy = hit.transform.GetComponent<LifeManager>();
                }

            }

            if (Physics.Raycast(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))
            {
                Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);

                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    onAttack = true;
                    Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                    //FindObjectOfType<PointerSpritePosition>().GetComponentInChildren<AbilityIcon>().OnAbility(1);
                    hit.transform.GetComponent<LifeManager>().DamageAmount = 2;
                    hit.transform.GetComponent<LifeManager>().Enemy = GetComponent<Agent>();
                    hit.transform.GetComponent<LifeManager>().BaseAttack = false;
                    GetComponentInChildren<AnimationController>().Enemy = hit.transform.GetComponent<LifeManager>();
                }
            }          

            GetComponent<Agent>().Mana--;
            Manager.CanAttack = false;
        }

    }

    //public void Preview()
    //{
    //    Manager.UpdateTilesMat();
    //    if (GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 1 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)

    //    {
    //        CleanPreview();
    //        Material PrevMaterial = FindObjectOfType<CellPrefScript>().Materials[3];
    //        NewPreview(PrevMaterial);
    //    }
    //}

    void NewPreview(Material _material)
    {
        float _lookX = GetComponent<Agent>().SavedlookAt.x;
        float _lookY = GetComponent<Agent>().SavedlookAt.z;
        Vector3 playerPosition = transform.position;

        List<CellPrefScript> cells = new List<CellPrefScript>();

        cells = FindObjectsOfType<CellPrefScript>().ToList();

        RaycastHit hit;

        if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))
        {
            Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.black);
            CellsGreenInRay(hit, cells, playerPosition, _material);
        }
        else
        {
            if (_lookX != 0)
            {
                if (_lookX > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if (((Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x + 1)) ||
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x + 2))) &&
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;
                        }
                    }
                }
                else if (_lookX < 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if (((Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x - 1)) || 
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x - 2))) &&
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;
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
                        if (((Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z - 1)) ||
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z - 2))) &&
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;

                        }
                    }
                }
                else if (_lookY > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if (((Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z + 1)) || 
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z + 2))) &&
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;
                        }
                    }
                }
            }
        }

        if (Physics.Raycast(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))
        {
            CellsGreenInRay(hit, cells, playerPosition, _material);
        }
        else
        {
            if (_lookX != 0)
            {
                if (_lookX < 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if (((Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x - 1)) || 
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x - 2))) &&
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z - 1)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;

                        }
                    }
                }
                else if (_lookX > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if (((Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x + 1)) || 
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x + 2))) &&
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z + 1)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;

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
                        if (((Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z - 1)) || 
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z - 2))) &&
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x + 1)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;

                        }
                    }
                }
                else if (_lookY > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if (((Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z + 1)) || 
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z + 2))) &&
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x - 1)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;

                        }
                    }
                }
            }
        }

        if (Physics.Raycast(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, 2))
        {
            CellsGreenInRay(hit, cells, playerPosition, _material);
        }
        else
        {

            if (_lookX != 0)
            {
                if (_lookX < 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if (((Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x - 1)) || 
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x - 2))) &&
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z + 1)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;

                        }
                    }
                }
                else if (_lookX > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if (((Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x + 1)) || 
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x + 2))) &&
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z - 1)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;

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
                        if (((Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z - 1)) || 
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z - 2))) &&
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x - 1)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;

                        }
                    }
                }
                else if (_lookY > 0)
                {
                    foreach (CellPrefScript cell in cells)
                    {
                        if (((Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z + 1)) || 
                            (Mathf.Round(cell.transform.position.z) == Mathf.Round(transform.position.z + 2))) &&
                            (Mathf.Round(cell.transform.position.x) == Mathf.Round(transform.position.x + 1)))
                        {
                            cell.GetComponent<MeshRenderer>().material = _material;
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

    void CellsGreenInRay(RaycastHit hit, List<CellPrefScript> cells, Vector3 playerPosition, Material _material)
    {
        foreach (CellPrefScript cell in cells)
        {
            if (hit.transform.GetComponent<Agent>() != null)
            {
                if ((((playerPosition.x < cell.transform.position.x && cell.transform.position.x <= hit.transform.position.x) ||
                 (playerPosition.x > cell.transform.position.x && cell.transform.position.x >= hit.transform.position.x)) &&
                 (cell.transform.position.z == hit.transform.position.z)) ||
                 (((playerPosition.z < cell.transform.position.z && cell.transform.position.z <= hit.transform.position.z) ||
                 (playerPosition.z > cell.transform.position.z && cell.transform.position.z >= hit.transform.position.z)) &&
                 (cell.transform.position.x == hit.transform.position.x)))
                {
                    cell.GetComponent<MeshRenderer>().material = _material;

                }
            }
            else

    {
                if ((((playerPosition.x < cell.transform.position.x && cell.transform.position.x < hit.transform.position.x) ||
                        (playerPosition.x > cell.transform.position.x && cell.transform.position.x > hit.transform.position.x)) &&
                        (Mathf.Round(cell.transform.position.z) == Mathf.Round(hit.transform.position.z))) ||
                        (((playerPosition.z < cell.transform.position.z && cell.transform.position.z < hit.transform.position.z) ||
                        (playerPosition.z > cell.transform.position.z && cell.transform.position.z > hit.transform.position.z)) &&
                        (Mathf.Round(cell.transform.position.x) == Mathf.Round(hit.transform.position.x))))
                {
                    cell.GetComponent<MeshRenderer>().material = _material;

                } 
            }
        }
    }
}
