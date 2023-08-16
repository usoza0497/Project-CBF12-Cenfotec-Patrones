﻿using System;
using UnityEngine;

public class PyronitiaKamikaseRun : StateMachineBehaviour
{
    private PyronitiaKamikase pyronitiaKamikase;
    private Transform player;
    Rigidbody2D myRigidbody;
    [SerializeField] float speed = 10f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidbody = animator.GetComponent<Rigidbody2D>();
        pyronitiaKamikase = animator.GetComponent<PyronitiaKamikase>();
        pyronitiaKamikase.SetName();
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
}
