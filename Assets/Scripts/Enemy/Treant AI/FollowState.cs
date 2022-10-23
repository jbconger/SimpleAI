using UnityEngine;

public class FollowState : State
{
	private GameObject target;

	public FollowState(EnemyController enemy, GameObject target) : base(enemy)
	{
		this.target = target;
	}

	public override State RunCurrentState()
	{
		if (enemy.target == null)
		{
			return new IdleState(enemy);
		}
		else if (Vector3.Distance(enemy.transform.position, target.transform.position) < 4f)
		{
			return new ChargeAttackState(enemy, target);
		}
		else
		{
			Follow();
			return this;
		}
	}

	private void Follow()
	{
		float step = enemy.moveSpeed * Time.deltaTime;
		enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, target.transform.position, step);
	}
}
