using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadSceneBehaviour : MonoBehaviour
{
    public void LoadNewScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
