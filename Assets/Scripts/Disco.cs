using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour
{
	public Light discoLight;
	public float minIntensity = 0.5f;
	public float maxIntensity = 2.0f;
	public float minRange = 5.0f;
	public float maxRange = 10.0f;

	void Start()
	{
		StartCoroutine(ChangeLightProperties());
	}

	IEnumerator ChangeLightProperties()
	{
		while (true)
		{
			// Generate random color in the orange range
			Color randomColor = Random.ColorHSV(0.04f, 0.1f, 0.8f, 1.0f, 0.8f, 1.0f);

			// Assign the generated color
			discoLight.color = randomColor;

			// Adjust intensity and range
			discoLight.intensity = Random.Range(minIntensity, maxIntensity);
			discoLight.range = Random.Range(minRange, maxRange);

			// Wait for a short duration before changing properties again
			yield return new WaitForSeconds(0.1f);
		}
	}
}