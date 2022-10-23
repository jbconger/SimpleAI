using UnityEngine;
using UnityEngine.Events;

public class MapToggle : MonoBehaviour
{
	public static UnityEvent onMapToggle;

	private void Awake()
	{
		if (onMapToggle == null)
			onMapToggle = new UnityEvent();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.M))
			onMapToggle.Invoke();
		else if (Input.GetKeyUp(KeyCode.M))
			onMapToggle.Invoke();
	}
}
