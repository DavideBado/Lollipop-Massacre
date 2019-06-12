using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Drain : MonoBehaviour
{
    DrainFeed DrainImage;
    float FeedbackTImer;
    float Timer;
    bool onAttack;
    GameManager Manager;
    public Agent agent;
    

    private void Start()
    {
        Timer = 1f;
        Manager = FindObjectOfType<GameManager>();
        agent = GetComponent<Agent>();
        DrainImage = FindObjectOfType<DrainFeed>();
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
                Manager.CleanTiles();
                Manager.UpdateTilesMat();
                Timer = 1f;
            }
        }

        if (DrainImage.GetComponent<Image>().enabled)
        {
            DrainImage.transform.position = (transform.position + new Vector3(0, 2.5f));
            if (FeedbackTImer > 0)
            {
                FeedbackTImer -= Time.deltaTime;
                if (FeedbackTImer <= 0)
                {
                    DrainImage.GetComponent<Image>().enabled = false;
                }
            }
        }
    }

    public void Ability()
    {
        if (GetComponent<Agent>().Mana > 0 && GetComponent<Agent>().MyTurn && GetComponent<Agent>().PlayerType == 2 && GetComponent<Agent>().ImStunned == false && Manager.CanAttack == true && Manager.Pause == false)
        {
            GetComponentInChildren<AnimationController>().Ability();
            //if(GetComponent<LifeManager>().Life == 3)
            //{
            //    ImFullButIWannaDrain();
            //}

            //if (GetComponent<LifeManager>().Life < 3)
            //{
                INeedLifeDrain();
            //}

            GetComponent<Agent>().Mana--;
            Manager.CanAttack = false;
            agent.DrainPS.SetActive(true);
            agent.StartDrain = Manager.Turn;
        }        
    }
    void ImFullButIWannaDrain()
    {
        RaycastHit hit;
        if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.yellow);
            if (hit.transform.tag == "Player" && hit.transform != transform)
            {
                onAttack = true;
                Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                hit.transform.GetComponent<LifeManager>().Damage(GetComponent<Agent>(), 1, false);
                hit.transform.GetComponent<Agent>().imDrained = true;
                hit.transform.GetComponent<Agent>().StartDrain = Manager.Turn;
            }
        }
    }

    void INeedLifeDrain()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.back, out hit, 3))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.back * hit.distance, Color.yellow);
            if (hit.transform.tag == "Player" && hit.transform != transform)
            {
                onAttack = true;
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                if (GetComponent<LifeManager>().Life < 3)
                {
                    GetComponent<LifeManager>().Life++;
                    FeedbackTImer = 1f;
                DrainImage.GetComponent<Image>().enabled = true;
                }
                hit.transform.GetComponent<LifeManager>().Damage(GetComponent<Agent>(), 1, false);
                hit.transform.GetComponent<Agent>().imDrained = true;
                hit.transform.GetComponent<Agent>().StartDrain = Manager.Turn;
            }
        }
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.forward, out hit, 3))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.forward * hit.distance, Color.yellow);
            if (hit.transform.tag == "Player" && hit.transform != transform)
            {
                onAttack = true;
                Debug.DrawRay(GetComponent<Agent>().RayLeft + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                if (GetComponent<LifeManager>().Life < 3)
                {
                    GetComponent<LifeManager>().Life++;
                    FeedbackTImer = 1f;
                DrainImage.GetComponent<Image>().enabled = true;
                }
                hit.transform.GetComponent<LifeManager>().Damage(GetComponent<Agent>(), 1, false);
                hit.transform.GetComponent<Agent>().imDrained = true;
                hit.transform.GetComponent<Agent>().StartDrain = Manager.Turn;
            }
        }
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.left, out hit, 3))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.left * hit.distance, Color.yellow);
            if (hit.transform.tag == "Player" && hit.transform != transform)
            {
                onAttack = true;
                Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                if (GetComponent<LifeManager>().Life < 3)
                {
                    GetComponent<LifeManager>().Life++;
                    FeedbackTImer = 1f;
                DrainImage.GetComponent<Image>().enabled = true;
                }
                hit.transform.GetComponent<LifeManager>().Damage(GetComponent<Agent>(), 1, false);
                hit.transform.GetComponent<Agent>().imDrained = true;
                hit.transform.GetComponent<Agent>().StartDrain = Manager.Turn;
            }
        }
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.right, out hit, 3))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.yellow);
            if (hit.transform.tag == "Player" && hit.transform != transform)
            {
                onAttack = true;
                Debug.DrawRay(GetComponent<Agent>().RayRight + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.red);
                if (GetComponent<LifeManager>().Life < 3)
                {
                    GetComponent<LifeManager>().Life++;
                    FeedbackTImer = 1f;
                DrainImage.GetComponent<Image>().enabled = true;
                }
                hit.transform.GetComponent<LifeManager>().Damage(GetComponent<Agent>(), 1, false);
                hit.transform.GetComponent<Agent>().imDrained = true;
                hit.transform.GetComponent<Agent>().StartDrain = Manager.Turn;
            }
        }

    }

    //public void Preview()
    //{
    //    Manager.UpdateTilesMat();
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

        //if (GetComponent<LifeManager>().Life == 6)
        //{
        //    if (Physics.Raycast(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt, out hit, Mathf.Infinity))
        //    {
        //        Debug.DrawRay(GetComponent<Agent>().RayCenter + new Vector3(0, 0.5f), GetComponent<Agent>().SavedlookAt * hit.distance, Color.black);
        //        if (_lookX != 0)
        //        {
        //            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        //        }
        //        else if (_lookY != 0)
        //        {
        //            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        //        }

        //    }
        //    else
        //    {
        //        if (_lookX != 0)
        //        {
        //            if (_lookX > 0)
        //            {
        //                CellsGreenInRay(new Vector3(GetComponent<Agent>().configGrid.DimX, 0, transform.position.z), cells, playerPosition, null, _material);
        //            }
        //            else if (_lookX < 0)
        //            {
        //                CellsGreenInRay(new Vector3(-1, 0, transform.position.z), cells, playerPosition, null, _material);
        //            }

        //        }
        //        else if (_lookY != 0)
        //        {

        //            if (_lookY < 0)
        //            {
        //                CellsGreenInRay(new Vector3(transform.position.x, 0, -1), cells, playerPosition, null, _material);
        //            }
        //            else if (_lookY > 0)
        //            {
        //                CellsGreenInRay(new Vector3(transform.position.x, 0, GetComponent<Agent>().configGrid.DimY), cells, playerPosition, null, _material);
        //            }

        //        }
        //    }
        //}

        //if (GetComponent<LifeManager>().Life < 6)
        //{
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.forward, out hit, 3))
        {
            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        }
        else
        {
            CellsGreenInRay(new Vector3(transform.position.x, 0, (transform.position.z + 4)), cells, playerPosition, null, _material);
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.back, out hit, 3))
        {
            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        }
        else
        {
            CellsGreenInRay(new Vector3(transform.position.x, 0, (transform.position.z - 4)), cells, playerPosition, null, _material);
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.right, out hit, 3))
        {
            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        }
        else
        {
            CellsGreenInRay(new Vector3((transform.position.x + 4), 0, transform.position.z), cells, playerPosition, null, _material);
        }

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f), Vector3.left, out hit, 3))
        {
            CellsGreenInRay(hit.transform.position, cells, playerPosition, hit.transform.GetComponent<Agent>(), _material);
        }
        else
        {
            CellsGreenInRay(new Vector3((transform.position.x - 4), 0, transform.position.z), cells, playerPosition, null, _material);
        }
        //}  
    }

    public void CleanPreview()
    {
        List<CellPrefScript> cells = new List<CellPrefScript>();
        cells = FindObjectsOfType<CellPrefScript>().ToList();

        foreach (CellPrefScript cell in cells)
        {
            cell.GetComponent<MeshRenderer>().material = cell.Materials[0];
        }
        Manager.UpdateTilesMat();
    }

    void CellsGreenInRay(Vector3 HitPosition, List<CellPrefScript> cells, Vector3 playerPosition, Agent _agent, Material _material)
    {
        foreach (CellPrefScript cell in cells)
        {
            if (_agent != null)
            {
                if ((((playerPosition.x < cell.transform.position.x && cell.transform.position.x <= HitPosition.x)

                  ||

                 (playerPosition.x > cell.transform.position.x && cell.transform.position.x >= HitPosition.x)) &&


                 (cell.transform.position.z == HitPosition.z)) ||



                 (((playerPosition.z < cell.transform.position.z && cell.transform.position.z <= HitPosition.z) ||
                 (playerPosition.z > cell.transform.position.z && cell.transform.position.z >= HitPosition.z)) &&
                 (cell.transform.position.x == HitPosition.x)))
                {
                    cell.GetComponent<MeshRenderer>().material = _material;
                }
            }
            else if (((playerPosition.x < cell.transform.position.x && cell.transform.position.x < HitPosition.x)

                  ||

                 (playerPosition.x > cell.transform.position.x && cell.transform.position.x > HitPosition.x)) &&


                 (Mathf.Round(cell.transform.position.z) == Mathf.Round((HitPosition.z))) ||



                 (((playerPosition.z < cell.transform.position.z && cell.transform.position.z < HitPosition.z) ||
                 (playerPosition.z > cell.transform.position.z && cell.transform.position.z > HitPosition.z)) &&
                 (Mathf.Round(cell.transform.position.x) == Mathf.Round(HitPosition.x))))
            {
                cell.GetComponent<MeshRenderer>().material = _material;
            }
        }
    }

}
