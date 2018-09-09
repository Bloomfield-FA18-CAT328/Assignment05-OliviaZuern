using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : StateMachineBehaviour
{

    public AnimEnemy enemyS;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
       enemyS = animator.gameObject.GetComponent<AnimEnemy>();
        enemyS.ChangeToChasing();
        animator.SetInteger("AnimState", 2);
    }
}