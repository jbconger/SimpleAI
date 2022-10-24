using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    public WanderState(EnemyController enemy) : base(enemy)
	{ }

	public override State RunCurrentState()
	{
		Wander();
		return this;
	}

	private void Wander()
	{
		Vector3 targetPosition;
		float step = enemy.moveSpeed * 0.5f * Time.deltaTime;
		
		if (Vector3.Distance(enemy.transform.position, enemy.startPosition) < 5f)
		{
			Vector2 randomDir = Random.insideUnitCircle.normalized;
			targetPosition = randomDir * 3f;

		}
		else
		{
			targetPosition = enemy.startPosition;
		}

		while (enemy.transform.position != targetPosition)
		{
			Vector3.MoveTowards(enemy.transform.position, targetPosition, step);
		}
	}
}
