using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurStomp : StateMachineBehaviour
{
    [SerializeField] private GameObject spellPrefab;
    [SerializeField] private float offsetX = 1f;
    private MinotaurController minotaurController;
    private Transform player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        minotaurController = animator.GetComponent<MinotaurController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 position = new Vector2(player.position.x, -8.576f);
        Instantiate(spellPrefab, position, Quaternion.identity);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
