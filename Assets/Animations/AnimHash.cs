using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHash : MonoBehaviour
{
    private Animator anim;
    public static int IdleHash = Animator.StringToHash("Idle");
    public static int RunHash = Animator.StringToHash("Run");
    public static int AttackHash = Animator.StringToHash("Attack");
    public static int DangerHash = Animator.StringToHash("Danger");
    public static int WalkingHash = Animator.StringToHash("Walking");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }




}
