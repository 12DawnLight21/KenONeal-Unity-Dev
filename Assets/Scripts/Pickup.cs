using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField] private Type pickupType;
	[SerializeField] GameObject pickupPrefab = null;
	[SerializeField] AudioClip playNoise;

	//[SerializeField] FloatVariable healthUpPoints;

	public enum Type
	{
		HEALTH,
		SCORE,
		TIME
	}

	void Start()
	{
		
	}

	void Update()
	{

	}

	private void OnCollisionEnter(Collision collision)
	{
		print(collision.gameObject.name);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent<Player>(out Player player))
		{
			switch (pickupType)
			{ 
				case Type.HEALTH:
					player.AddPoints(15);
					AudioSource.PlayClipAtPoint(playNoise, transform.position);
					break;
				case Type.TIME:
					GameManager.Instance.Timer += 5.0f;
					AudioSource.PlayClipAtPoint(playNoise, transform.position);

					break;
				case Type.SCORE: 
					AudioSource.PlayClipAtPoint(playNoise, transform.position);
					player.AddPoints(10);
					break;
			}
		}

		Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}

