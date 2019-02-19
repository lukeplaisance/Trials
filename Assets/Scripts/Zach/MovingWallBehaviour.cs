using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingWallBehaviour : MonoBehaviour
{
    public Vector3 Direction;
    public Vector3 RaycastOffset;
    public float Speed;
    public bool IsMoving = false;
	
	void Update ()
    {
        if(IsMoving)
            transform.position += Direction * Speed * Time.deltaTime;
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + RaycastOffset, Direction * 4, out hit))
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
            IsMoving = false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + RaycastOffset, Direction*4);
    }
}
