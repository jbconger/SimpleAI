using UnityEngine;

public abstract class State
{
	protected EnemyController enemy;

	protected State(EnemyController enemy)
	{
		this.enemy = enemy;
	}

	public abstract State RunCurrentState();
}
