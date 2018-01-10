using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kira2InTitle : MonoBehaviour {

	private float speed;
	private Vector2 dir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( dir * speed * Time.deltaTime );
		if( transform.localPosition.y < -(Screen.height / 2) )
		{
			gameObject.SetActive( false );
		}
	}

	public void Init( Vector2 dir, float speed )
	{
		this.dir = dir;
		this.speed = speed;
	}
}
