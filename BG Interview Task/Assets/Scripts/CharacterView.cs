using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public void StopAnimation(string animationName)
    {
        animator.StopPlayback();
    }

    public bool IsPlayingAnimation(string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }

}
