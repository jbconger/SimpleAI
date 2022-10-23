using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
	public IdleState(EnemyController enemy) : base(enemy)
	{ }

	public override State RunCurrentState()
	{
		if (enemy.target != null)
		{
			return new FollowState(enemy, enemy.target);
		}
		else
		{
			return this;
		}
	}
}
