using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This class defines the behavior of the attack state in the state machine
public class AttackState : StateMachineBehaviour
{
	// The NavMeshAgent component attached to the animator
	UnityEngine.AI.NavMeshAgent agent;

	// The transform of the player
	Transform player;

	// This method is called when the state machine enters the attack state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// Get the NavMeshAgent component from the animator
		agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();

		// Find the player's transform by its tag
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// This method is called at each update frame while the state machine is in the attack state
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// Calculate the distance between the player and the animator
		float distance = Vector3.Distance(player.position, animator.transform.position);

		// If the distance is greater than or equal to 3 units
		if (distance >= 3f)
		{
			// Set the "isAttacking" boolean of the animator to false
			animator.SetBool("isAttacking", false);
		}
	}

	// This method is called when the state machine exits the attack state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// Set the agent's destination to the animator's current position
		agent.SetDestination(animator.transform.position);
	}
}
