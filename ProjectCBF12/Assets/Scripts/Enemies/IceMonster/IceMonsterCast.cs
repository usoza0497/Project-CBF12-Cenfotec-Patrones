using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMonsterCast : StateMachineBehaviour
{
    [SerializeField] private GameObject spellPrefab;
    [SerializeField] private float offsetX = 1f;
    private Transform player;
    private float positionY = -9.008f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 position1 = new Vector2(player.position.x, positionY);
        Vector2 position2 = new Vector2(player.position.x + offsetX, positionY);
        Instantiate(spellPrefab, position1, Quaternion.identity);
        Instantiate(spellPrefab, position2, Quaternion.identity);
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
