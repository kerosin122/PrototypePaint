using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Attack : State
{
    [SerializeField] private float _delayBetweenAttack;
    private bool _attack = true;
    private TimeCounting _timer = new();

    private void OnEnable()
    {
        _attack = true;
        _timer.TimeIsUp += ControllerAnimations;
    }

    private void FixedUpdate()
    {
        Agent.SetDestination(Target.transform.position);
        if (enabled && _attack)
        {
            Animator.SetTrigger("Attacks");
            StartCoroutine(_timer.TimerCounting(_delayBetweenAttack));
            Target.TakeDamage(1);
            _attack = false;
        }
    }

    private void ControllerAnimations(bool value)
    {
        _attack = value;
    }

    private void OnDisable()
    {
        _timer.TimeIsUp -= ControllerAnimations;
        StopAllCoroutines();
    }
}
