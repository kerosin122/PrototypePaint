using UnityEngine;
using UnityEngine.UI;

public class Attack : State
{
    private void OnEnable()
    { Animator.SetBool("Attack",true);

    }
    private void  OnDisable()
    {Animator.SetBool("Attack",false);
        
    }
}
