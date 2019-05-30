using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class Venom : MonoBehaviour
{
    float Timer;
    bool onAttack;
    public GameObject Poison;
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
            Manager.UpdateTilesMat();
            NewPreview(Manager.CellAttackMaterial);
            if (Timer <= 0)
            {
                onAttack = false;
                Manager.Pause = false;
                CleanPreview();
                Timer = 1f;
            }

        }
    }

    public void Ability()
    {
        if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 4 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.forward * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    onAttack = true;
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.forward * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.back, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.back * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    onAttack = true;
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.back * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.left, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.left * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    onAttack = true;
                    Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.left * hit.distance, Color.red);
                    PoisonPower(hit);
                }
            }

            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.right, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.yellow);
                if (hit.transform.tag == "Player" && hit.transform != transform)
                {
                    onAttack = true;
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
        hit.transform.GetComponent<LifeManager>().Damage(1);
        Debug.Log("{0}", hit.transform);
    }

    //public void Preview()
    //{
    //    //Manager.UpdateTilesMat();
    //    if (GetComponent<Agent>().MyTurn && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)

    //    {
    //        //CleanPreview();
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

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.forward, out hit, Mathf.Infinity))
        {
            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        }
        else
        {
            CellsGreenInRay(new Vector3(transform.position.x, 0, GetComponent<Agent>().configGrid.DimY), cells, playerPosition, null, _material);
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.back, out hit, Mathf.Infinity))
        {
            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        }
        else
        {
            CellsGreenInRay(new Vector3(transform.position.x, 0, -1), cells, playerPosition, null, _material);
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.right, out hit, Mathf.Infinity))
        {
            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        }
        else
        {
            CellsGreenInRay(new Vector3(GetComponent<Agent>().configGrid.DimX, 0, transform.position.z), cells, playerPosition, null, _material);
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.left, out hit, Mathf.Infinity))
        {
            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        }
        else
        {
            CellsGreenInRay(new Vector3(-1, 0, transform.position.z), cells, playerPosition, null, _material);
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
        //Manager.UpdateTilesMat();
    }

    void CellsGreenInRay(Vector3 _HitPosition, List<CellPrefScript> _cells, Vector3 _playerPosition, Agent _agent, Material _material)
    {
        foreach (CellPrefScript cell in _cells)
        {
            if (_agent != null)
            {
                if ((((_playerPosition.x < cell.transform.position.x && cell.transform.position.x <= _HitPosition.x)

                  ||

                 (_playerPosition.x > cell.transform.position.x && cell.transform.position.x >= _HitPosition.x)) &&


                 (Mathf.Round(cell.transform.position.z) == Mathf.Round(_HitPosition.z))) ||



                 (((_playerPosition.z < cell.transform.position.z && cell.transform.position.z <= _HitPosition.z) ||
                 (_playerPosition.z > cell.transform.position.z && cell.transform.position.z >= _HitPosition.z)) &&
                 (Mathf.Round(cell.transform.position.x) == Mathf.Round(_HitPosition.x))))
                {
                    cell.GetComponent<MeshRenderer>().material = _material;
                }
            }
            else if ((((_playerPosition.x < cell.transform.position.x && cell.transform.position.x < _HitPosition.x)

  ||

 (_playerPosition.x > cell.transform.position.x && cell.transform.position.x > _HitPosition.x)) &&


 (Mathf.Round(cell.transform.position.z) == Mathf.Round(_HitPosition.z))) ||



 (((_playerPosition.z < cell.transform.position.z && cell.transform.position.z < _HitPosition.z) ||
 (_playerPosition.z > cell.transform.position.z && cell.transform.position.z > _HitPosition.z)) &&
 (Mathf.Round(cell.transform.position.x) == Mathf.Round(_HitPosition.x))))
            {
                cell.GetComponent<MeshRenderer>().material = _material;
            }
        }
    }
}
