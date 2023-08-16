using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PyronitiaAvanzadoRun : StateMachineBehaviour
{
    private PyronitiaAvanzado pyronitiaAvanzado;
    private Transform player;
    Rigidbody2D myRigidbody;
    [SerializeField] float speed = 6f;
    [SerializeField] float meleeRange = 2f;
    private bool hasAttacked = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Console.WriteLine("On State Enter:");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidbody = animator.GetComponent<Rigidbody2D>();
        pyronitiaAvanzado = animator.GetComponent<PyronitiaAvanzado>();
        hasAttacked = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, myRigidbody.position.y);
        Vector2 newPos = Vector2.MoveTowards(myRigidbody.position, target, speed * Time.deltaTime);
        myRigidbody.MovePosition(newPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private bool IsPlayerInRange()
    {
        return Vector2.Distance(player.position, myRigidbody.position) < meleeRange;
    }
}
