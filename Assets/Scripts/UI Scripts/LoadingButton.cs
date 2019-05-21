using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingButton : MonoBehaviour
{
    public GameObject Button;
    // Update is called once per frame
    private void OnEnable()
    {
        SceneManager.sceneLoaded += ButtonOn;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ButtonOn;

    }

    void ButtonOn(Scene _scene, LoadSceneMode _sceneMode)
    {
        Button.SetActive(true);
    }
}
