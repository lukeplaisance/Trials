using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PressPressurePlayeController : MonoBehaviour
{
    public float speed;
    public void MovePressurePlate()
    {
        var a = GetComponent<Animator>();
        a.SetBool("isMoving", true);
        StartCoroutine("Move");
        transform.position += new Vector3(0, -.5f, 0) * speed * Time.deltaTime; 
    }

    IEnumerator Move()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            var a = GetComponent<Animator>();
            a.SetBool("isMoving", false);
            break;
        }
    }
}
