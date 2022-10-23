using System.Collections;
using UnityEngine;

public class ChargeAttackState : State
{
	private GameObject target;
	private float chargeForce = 75f;
	private bool hasCharged = false;

	public ChargeAttackState(EnemyController enemy, GameObject target) : base(enemy)
	{
		this.target = target;
	}

	public override State RunCurrentState()
	{
		if (!hasCharged)
			ChargeAttack();

		if (enemy.rb2D.velocity.sqrMagnitude > 0.0f && Vector3.Distance(enemy.transform.position, target.transform.position) < 3f)
			return this;

		if (enemy.target != null)
		{
			return new FollowState(enemy, target);
		}
		else
		{
			return new IdleState(enemy);
		}
	}

	private void ChargeAttack()
	{
		hasCharged = true;

		Vector2 attackDirection = target.transform.position - enemy.transform.position;
		attackDirection.Normalize();

		enemy.rb2D.AddForce(attackDirection * chargeForce);
	}
}
