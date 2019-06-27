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
        anim.speed = set_animation_speed;
    }

    public void ReturnAnimationSpeed(Animator anim)
    {
        if (!Animators.Contains(anim))
            return;
        anim.speed = 1;
    }

    public void RemoveFromList(Animator anim)
    {
        if (!Animators.Contains(anim))
            return;
        anim.speed = 1;
        Animators.Remove(anim);
    }

    void OnTriggerEnter(Collider other)
    {
        var animator = other.GetComponent<Animator>();
        if (animator != null && !other.CompareTag("Player"))
        {
            AddToList(animator);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //when exiting remove the animator from list
        var anim = other.GetComponent<Animator>();
        if (anim == null) //if the animator component fetch is null then return because it would never be in the list
            return;
        //remove from list checks if it's in the list so we don't need to check
        RemoveFromList(anim);
    }

    void OnDisable()
    {
        foreach (var anim in Animators)
        {
            ReturnAnimationSpeed(anim);
        }
        Animators.Clear();
    }
}
