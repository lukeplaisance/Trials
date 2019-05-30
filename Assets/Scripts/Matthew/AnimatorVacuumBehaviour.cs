using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AnimatorVacuumBehaviour : MonoBehaviour
{
    public List<Animator> Animators = new List<Animator>();

    public void AddToList(Animator anim)
    {
        if (Animators.Contains(anim))
            return;
        Animators.Add(anim);
    }

    public void RemoveFromList(Animator anim)
    {
        if (!Animators.Contains(anim))
            return;
        Animators.Remove(anim);
    }
    void OnTriggerEnter(Collider other)
    {
        var animator = other.GetComponent<Animator>();
        if (animator != null)
        {
            AddToList(animator);
        }
    }
}
