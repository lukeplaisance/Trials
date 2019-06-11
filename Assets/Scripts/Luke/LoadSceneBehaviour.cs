using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadSceneBehaviour : MonoBehaviour
{
    public void LoadNewScene(int scene_index)
    {
        SceneManager.LoadScene(scene_index, LoadSceneMode.Additive);
    }
}
