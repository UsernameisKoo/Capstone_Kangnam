using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneInteract : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.UnloadSceneAsync("Town");
        SceneManager.LoadSceneAsync("Room", LoadSceneMode.Additive);
    }
}
