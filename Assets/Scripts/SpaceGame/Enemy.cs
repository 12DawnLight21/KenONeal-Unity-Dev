using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] protected float health;
    [SerializeField] protected int pointsGained;
    [SerializeField] protected IntEvent scoreEvent;
                     
    [SerializeField] protected GameObject hitPrefab;
    [SerializeField] protected GameObject destroyPrefab;


	public void ApplyDamage(float damage)
	{
		health -= damage;

        if (health <= 0)
        {
            scoreEvent?.RaiseEvent(pointsGained);
            if (destroyPrefab != null)
            {
                Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        else
        { 
            if (hitPrefab != null)
            {
                Instantiate(hitPrefab, gameObject.gameObject.transform.position, Quaternion.identity);
            }
        }
	}

}
