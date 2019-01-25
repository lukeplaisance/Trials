using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLockBehaviour : MonoBehaviour
{
    private List<int> answer = new List<int> { 2, 3, 1,};
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;
    private bool isLocked = true;
	
	// Update is called once per frame
	void Update ()
    {
        CheckValues();
	}

    public void CheckValues()
    {
       foreach(var value in answer)
        {
            if (slot1.current_value == answer[0])
                if (slot2.current_value == answer[1])
                    if (slot3.current_value == answer[2])
                        isLocked = false;
        }
    }

    [ContextMenu("Rot")]
    void Test()
    {
        slot1.Rotate_Slot();
    }
}
