using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneLoading : MonoBehaviour
{
    public static int SceneIndex;
    public int SceneIndexPerCazzoBuildVeloce;
    private void OnEnable()
    {
        SceneManager.LoadScene(SceneIndexPerCazzoBuildVeloce);
        FindObjectOfType<StarterController>().SelectPlayer();
    }
}
