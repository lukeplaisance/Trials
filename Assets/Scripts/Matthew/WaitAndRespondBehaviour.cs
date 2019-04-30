using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitAndRespondBehaviour : MonoBehaviour
{
    [SerializeField]
    private UnityEvent Response;
    public void WaitAndRespond(float time)
    {
        StartCoroutine(WaitAndDo(time));
    }
    private IEnumerator WaitAndDo(float time)
    {
        yield return new WaitForSeconds(time);
        Response.Invoke();
    }
}
