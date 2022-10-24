using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public AudioClip throwSound;
    [SerializeField] public AudioClip hitSound;


	// Start is called before the first frame update
	void Start()
    {
        audioSource.clip = throwSound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        audioSource.clip = hitSound;
        audioSource.Play();
        Destroy(this.gameObject);
	}
}
