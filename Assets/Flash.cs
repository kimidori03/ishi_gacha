using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

	public float rotSpeed;

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (0, 0, rotSpeed * Time.deltaTime);
	}
}
