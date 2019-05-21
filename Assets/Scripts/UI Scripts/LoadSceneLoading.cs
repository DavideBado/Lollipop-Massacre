using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneLoading : MonoBehaviour
{
    public int SceneIndex;
    private void OnEnable()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
