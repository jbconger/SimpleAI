using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
	private float wanderDuration = 1.5f;
	private float wanderStartTime = 0.0f;
	private Vector3 targetPosition;

    public WanderState(EnemyController enemy) : base(enemy)
	{
		//targetPosition = new Vector3(enemy.startPosition.x, enemy.startPosition.y - 5);
	}

	public override State RunCurrentState()
	{
		if (enemy.target != null)
		{
			return new RangedAttackState(enemy);
		}
		else
		{
			Wander();
			return this;
		}
	}

	private void Wander()
	{
		float step = enemy.moveSpeed * 0.75f * Time.deltaTime;

		if (Time.time > wanderStartTime + wanderDuration && Vector3.Distance(enemy.transform.position, enemy.startPosition) < 5f)
		{
			Vector2 randomDir = Random.insideUnitCircle.normalized;
			targetPosition = randomDir * 3f;
			wanderStartTime = Time.time;
		}
		else if (Vector3.Distance(enemy.transform.position, enemy.startPosition) > 5f)
		{
			targetPosition = enemy.startPosition;
		}

		enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition, step);
	}
}
