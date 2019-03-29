using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Matthew;


namespace Luke
{
    public class PushPullBehaviour : MonoBehaviour
    {
        public float speed;
        public GameObjectVariable player;
        public GameObject front_col;
        public GameObject back_col;
        public GameObject left_col;
        public GameObject right_col;

        void Update()
        {
            var v = Input.GetAxis("Vertical");
            if (player.ReferenceGameObject.transform.position.x == front_col.transform.position.x)
            {
                Move(new Vector3(0, 0, -v));
            }

            if (player.ReferenceGameObject.transform.position.x == back_col.transform.position.x)
            {
                Move(new Vector3(0, 0, v));
            }

            if (player.ReferenceGameObject.transform.position.x == left_col.transform.position.x)
            {
                Move(new Vector3(v, 0, 0));
            }

            if (player.ReferenceGameObject.transform.position.x == right_col.transform.position.x)
            {
                Move(new Vector3(-v, 0, 0));
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
}
