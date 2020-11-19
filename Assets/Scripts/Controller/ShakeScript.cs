using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
	// References to controlled game objects that will fall
	// when you shake the mobile device hard enough
	public GameObject PanelOne, PanelTwo;

	// variable to hold shaking acceleration value
	Vector3 accelerationDir;

	// Update is called once per frame
	void Update()
	{
		// Read new acceleration Input from mobile device
		accelerationDir = Input.acceleration;

		// If you shake the mobile device hard enough
		// (accelerations Square Magnitude greater then 5 for example)
		if (accelerationDir.sqrMagnitude >= 5f)
		{
			PanelOne.SetActive(true);
			PanelTwo.SetActive(false);
		}
	}
}