﻿using System;
using UnityEngine;

public class PyronitiaAvanzadoAttack2 : StateMachineBehaviour
{
    private Transform player;
    private Transform attack;
    public float attackRadio;
    public float desiredNormalizedTime;  // El tiempo normalizado en el que deseas que se active el if
    private float timeThreshold = 0.01f;   // Un umbral de tiempo para ajustar la precisión
    private bool hasExecutedIf = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        attack = GameObject.FindGameObjectWithTag("PyronitiaMeleeAttack2").transform;
        hasExecutedIf = false;  // Reinicializar la variable cuando entra a un nuevo estado
        Console.WriteLine("OnStateEnter Attack1");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!hasExecutedIf && stateInfo.normalizedTime >= desiredNormalizedTime - timeThreshold &&
            stateInfo.normalizedTime <= desiredNormalizedTime + timeThreshold)
        {
            if ((player.position.x - attack.position.x) > attackRadio &&
                (player.position.y - attack.position.y) > attackRadio)
            {
                player.GetComponent<PlayerController>().GetHurt();
                GameManager.instance.LoseHealth();
            }

            hasExecutedIf = true;  // Marcar que el if se ha ejecutado
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}