using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoRun : StateMachineBehaviour
{
    Xeno boss;
    XenoController controller;
    Transform player;
    Rigidbody2D myRigidbody;
    [SerializeField] float speed = 2f;
/*     [SerializeField] float meleeRange = 2f;
    [SerializeField] float rangeRange = 5f; */
    public float timer;
    public float minTime;
    public float maxTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidbody = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Xeno>();
        controller = animator.GetComponent<XenoController>();
        boss.SetName();
        boss.SetMeleeAttacks();
        boss.SetRangeAttacks();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, myRigidbody.position.y);
        Vector2 newPos = Vector2.MoveTowards(myRigidbody.position, target, speed * Time.fixedDeltaTime);
        myRigidbody.MovePosition(newPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public void DoMeleeAttack(Animator myAnimator)
    {
        string attackUsed = null;

        if(boss.IsAlive()) {
            attackUsed = boss.MeleeAttack();
            myAnimator.SetTrigger(attackUsed);
        }
        Debug.Log(boss.BossHealth);
        Debug.Log(boss.Log);
    }

    public void DoRangeAttack(Animator myAnimator)
    {
        string attackUsed = null;

        if(boss.IsAlive()) {
            attackUsed = boss.RangeAttack();
            myAnimator.SetTrigger(attackUsed);
        }
        Debug.Log(boss.BossHealth);
        Debug.Log(boss.Log);
    }
}
