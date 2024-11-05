using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnim : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    [SerializeField] private Animator animator;

    public void ToRun()
    {
        animator.SetFloat(IsRunning, 1);
    }

    public void ToIdle()
    {
        animator.SetFloat(IsRunning, 0);

    }
}
