using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;

public class PushPullBehaviour : MonoBehaviour
{
    public float speed;
    public NewPlayerMovementBehaviour player;
    public GameObject front_col;
    public GameObject back_col;
    public GameObject left_col;
    public GameObject right_col;

	void Update ()
    {
        var v = Input.GetAxis("Vertical");
        if (player.transform.position.x == front_col.transform.position.x || 
            player.transform.position.x == back_col.transform.position.x)
        {
            Move(new Vector3(0,0,v));
        }

        if (player.transform.position.x == left_col.transform.position.x ||
            player.transform.position.x == right_col.transform.position.x)
        {
            Move(new Vector3(v,0,0));
        }
    }

    public void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            transform.position += direction * Time.deltaTime * speed;
        }
    }
}
