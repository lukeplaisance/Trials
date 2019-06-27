using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour
{
    public List<GameObject> DontDestroyObjects = new List<GameObject>();

    public void LoadNewScene(int scene_index)
    {
        SceneManager.LoadScene(scene_index);
    }

    public void DontDestroy()
    {
        foreach (var obj in DontDestroyObjects)
        {
            DontDestroyOnLoad(obj);
        }
    }
}
