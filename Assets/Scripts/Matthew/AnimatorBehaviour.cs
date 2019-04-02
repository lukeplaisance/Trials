using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBehaviour : MonoBehaviour
{
    Animator _animator;
    [System.Serializable]
    public struct AnimatorParameterFloatVariable
    {
        public string Name;
        public Zach.FloatVariable Var;
    }
    public AnimatorParameterFloatVariable param;
	// Update is called once per frame
	void Update ()
    {
        if (_animator == null)
            return;
        _animator.SetFloat(param.Name, (float)param.Var.Value);
		
	}
}
