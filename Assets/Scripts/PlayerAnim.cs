using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnim : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int JumpTrigger = Animator.StringToHash("jumpTrigger");
    [SerializeField] private Animator animator;

    public void ToRun()
    {
        animator.SetFloat(IsRunning, 1);
    }

    public void ToIdle()
    {
        animator.SetFloat(IsRunning, 0);
    }

    public void ToJump()
    {
        animator.SetTrigger(JumpTrigger);
    }
}
