using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : State
{
	public FleeState(EnemyController enemy) : base(enemy)
	{

	}

	public override State RunCurrentState()
	{
		Flee();

		if (enemy.target != null && Vector3.Distance(enemy.transform.position, enemy.target.transform.position) > 5f)
			return new RangedAttackState(enemy);
		else if (enemy.target == null)
			return new WanderState(enemy);
		else
			return this;
	}

	private void Flee()
	{
		float step = -1 * enemy.moveSpeed * Time.deltaTime;
		enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.target.transform.position, step);
	}
}
