using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GMcontroller : MonoBehaviour
{
    public GameObject EnergyUp;
    public bool CanSpawnEnergy = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InUpdate();
    }

    void InUpdate()
    {
        GMInput();
    }

    void GMInput()
    {
        if(Input.GetAxis("R2") != 0)
        {
            EditorApplication.isPaused = !EditorApplication.isPaused;
        }

        transform.position += new Vector3(1 * Input.GetAxis("GP_HorizontalArrow1") / 10, 0, 1 * Input.GetAxis("GP_VerticalArrow1") / 10);

        if (Input.GetAxis("CrossButton") != 0 && CanSpawnEnergy == true)
        {
            Instantiate(EnergyUp, transform);
            CanSpawnEnergy = false;
        }
    }
}
