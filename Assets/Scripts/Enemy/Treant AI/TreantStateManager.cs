using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantStateManager : MonoBehaviour
{
    public State currentState;

	private void Start()
	{
		currentState = new IdleState(GetComponent<EnemyController>());
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
