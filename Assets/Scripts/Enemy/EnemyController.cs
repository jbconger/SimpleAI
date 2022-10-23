using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public float health = 10f;

    [Header("Movement")]
    [SerializeField] public float moveSpeed = 5f;

    [HideInInspector] public CircleCollider2D detectionCollider;
    [HideInInspector] public Rigidbody2D rb2D;
    [HideInInspector] public GameObject target;

	private void Awake()
	{
        rb2D = GetComponent<Rigidbody2D>();
        detectionCollider = GetComponent<CircleCollider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
            target = collision.gameObject;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
            target = null;
	}

    public void Wait(float time)
	{
        StartCoroutine(WaitFor(time));
	}

    private IEnumerator WaitFor(float time)
	{
        yield return new WaitForSeconds(time);
	}
}
