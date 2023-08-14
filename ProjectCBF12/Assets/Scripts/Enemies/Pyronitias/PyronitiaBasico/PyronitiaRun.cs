using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PyronitiaRun : StateMachineBehaviour
{
    private PyronitiaBasico pyronitiaBasico;
    private Transform player;
    Rigidbody2D myRigidbody;
    [SerializeField] float speed = 2f;
    [SerializeField] float meleeRange = 2f;
    private bool hasAttacked = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Console.WriteLine("On State Enter:");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidbody = animator.GetComponent<Rigidbody2D>();
        pyronitiaBasico = animator.GetComponent<PyronitiaBasico>();
        pyronitiaBasico.SetName();
        pyronitiaBasico.SetMeleeAttacks();
        hasAttacked = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, myRigidbody.position.y);
        Vector2 newPos = Vector2.MoveTowards(myRigidbody.position, target, speed * Time.deltaTime);
        myRigidbody.MovePosition(newPos);

        if (IsPlayerInRange() && !hasAttacked)
        {
            animator.SetTrigger(pyronitiaBasico.MeleeAttack());
            hasAttacked = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Run");
    }

    private bool IsPlayerInRange()
    {
        return Vector2.Distance(player.position, myRigidbody.position) < meleeRange;
    }
}
