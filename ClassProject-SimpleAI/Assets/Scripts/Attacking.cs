using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : StateMachineBehaviour {

    public AnimEnemy enemyS;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        enemyS = animator.gameObject.GetComponent<AnimEnemy>();
        enemyS.ChangeToAttacking();
        animator.SetInteger("AnimState", 3);
    }
}
