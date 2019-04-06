using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsData : MonoBehaviour
{
    public Material TransparencyMat, Material;
    // Start is called before the first frame update
    void Start()
    {
        Material = GetComponent<MeshRenderer>().material;
    }

}
