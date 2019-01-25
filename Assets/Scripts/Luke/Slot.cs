using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slot : MonoBehaviour
{
    public int current_value = 1;
    public Transform transform;

    public void Rotate_Slot()
    {
        StartCoroutine("Rotate");

        current_value++;
        if(current_value > 4)
        {
            current_value = 1;
        }
    }

    IEnumerator Rotate()
    {
        int c = 0;
        while(c != 50)
        {
            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
            c++;
        }
        yield return null;
    }
}
