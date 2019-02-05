using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingWallBehaviour : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;
    public bool IsMoving = false;
	
	void Update ()
    {
        if(IsMoving)
            transform.position += Direction * Speed * Time.deltaTime;
        
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward * 4, out hit))
            {
                if (hit.collider.gameObject.tag == "Terrain")
                {
                    SceneManager.LoadScene("GameOver");
                    Debug.Log("Player is dead.");
                }
            }
        }
        if (other.tag == "Terrain")
        {
            Direction = -Direction;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward*4);
    }
}
