using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;
using UnityEngineInternal;

[RequireComponent(typeof(SphereCollider))]
public class AnimatorVacuumBehaviour : MonoBehaviour
{
    public List<Animator> Animators = new List<Animator>();
    public float set_animation_speed;

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
        if (animator != null && !other.CompareTag("Player"))
        {
            AddToList(animator);
            animator.speed = set_animation_speed;
        }
    }

    void OnTriggerExit(Collider other)
    {
        var animator = other.GetComponent<Animator>();
        RemoveFromList(animator);
        animator.speed = 1;
    }

    void OnDisable()
    {
        foreach (var anim in Animators)
        {
            var animator = anim.GetComponent<Animator>();
            RemoveFromList(animator);
            animator.speed = 1;
        }
    }
}
