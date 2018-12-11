using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour {

    public float threshold = 1;

    private GameObject parent;
    private Vector3 target;

    void SetTarget()
    {
        Vector3 direction = (Vector3)Random.insideUnitSphere * parent.GetComponent<Enemy>().patrolRadius;
        direction.y = 0;
        target = parent.GetComponent<Enemy>().patrolPoint.position + direction;
        parent.GetComponent<Enemy>().agent.SetDestination(target);

    }



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        parent = animator.gameObject.transform.parent.gameObject;
        parent.GetComponent<Enemy>().weapon.StopFiring();
        SetTarget();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(parent.transform.position, target) < threshold)
        {
            SetTarget();
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
