using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMonsterRun : StateMachineBehaviour
{
    private IceMonster boss;
    private Transform player;
    Rigidbody2D myRigidbody;
    [SerializeField] float speed = 2f;
    [SerializeField] float meleeRange = 2f;
    private bool hasAttacked = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidbody = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<IceMonster>();
        boss.SetName();
        boss.SetMeleeAttacks();
        boss.SetRangeAttacks();
        hasAttacked = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, myRigidbody.position.y);
        Vector2 newPos = Vector2.MoveTowards(myRigidbody.position, target, speed * Time.fixedDeltaTime);
        myRigidbody.MovePosition(newPos);
        
        if (IsPlayerInRange() && !hasAttacked) {
            animator.SetTrigger(boss.MeleeAttack());
            hasAttacked = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Run");
    }

    private bool IsPlayerInRange() {
        return Vector2.Distance(player.position, myRigidbody.position) < meleeRange;
    }
}
