using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : State
{
    private float attackInterval = 1.5f;
    private float lastAttackTime = 0.0f;

	private GameObject projectile;

	public RangedAttackState(EnemyController enemy) : base(enemy)
	{
		projectile = Resources.Load("RockProjectile") as GameObject;
	}

	public override State RunCurrentState()
	{
		if (enemy.target != null && Vector3.Distance(enemy.transform.position, enemy.target.transform.position) < 4f)
			return new FleeState(enemy);
		else if (enemy.target == null)
			return new WanderState(enemy);
		else
		{
			RangedAttack();
			return this;
		}
	}

	private void RangedAttack()
	{
		if(Time.time > lastAttackTime + attackInterval)
		{
			//launch attack
			Vector3 projectileDirection = (enemy.target.transform.position - enemy.transform.position).normalized;
			Vector3 spawnLocation = (enemy.transform.position + (projectileDirection * 2));
			GameObject rock = Object.Instantiate(projectile);
			rock.transform.position = spawnLocation;
			rock.GetComponent<Rigidbody2D>().AddForce(projectileDirection * 250f);

			lastAttackTime = Time.time;

			Object.Destroy(rock, 3f);
		}
	}
}
