using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WallTransparency : MonoBehaviour
{
    public Texture texture;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "EnergyUp")
        {
            foreach(GameObject _object in GetComponentInParent<Wall>().Models)
            {
                //Renderer rend = GetComponent<Renderer>();

                ////Set the main Color of the Material to green
                //rend.material.shader = Shader.Find("_Color");
                //rend.material.SetColor("_Color", Color.green);
                //_object.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
                Renderer rend = _object.GetComponent<Renderer>();

                rend.material.shader = Shader.Find("_Color");
                rend.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 0.2f));
            }

        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player" || other.gameObject.tag == "EnergyUp")
    //    {
    //        GetComponentInParent<MeshRenderer>().material.color = new Color(1.0f, 0f, 0.7611f, 1f);
    //    }
    //}
}
