using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : StateMachineBehaviour {

    public AnimEnemy enemyS;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       base.OnStateEnter(animator, stateInfo, layerIndex);
        enemyS = animator.gameObject.GetComponent<AnimEnemy>();
        enemyS.ChangeToPatrolling();
        animator.SetInteger("AnimState", 1);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        enemyS.OnPatrollingUpdate();

    }
}
