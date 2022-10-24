using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleStateManager : MonoBehaviour
{
	public State currentState;

	private void Start()
	{
		currentState = new WanderState(GetComponent<EnemyController>());
	}

	// Update is called once per frame
	void Update()
	{
		State nextState = currentState?.RunCurrentState();

		if (nextState != currentState)
		{
			currentState = nextState;
		}
	}
}
