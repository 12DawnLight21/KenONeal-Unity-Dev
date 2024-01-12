using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField][Range(1, 20)][Tooltip("Force required to move object")] float force;

	public Rigidbody rb;

	private void Awake() // when the models are loaded in
	{
		//print("awake");
	}

	void Start() // when every component can be used
	{
		//print("start");
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(transform.up * force, ForceMode.VelocityChange);
		}
	}
}