using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GirlController : MonoBehaviour {

	public List<Sprite> images;
	public Image girlimage;
	public float interval = 1f;
	private int current;
	private float timer = 0;
	public AudioClip Pickel_sound;
	public AudioSource audiosource;
	public bool animating = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!animating)
			return;
		timer += Time.deltaTime;
		if (timer > interval) {
			timer = 0;
		

			current++;
			if (current >= images.Count) {
				current = 0;
			}

			girlimage.sprite = images [current];
			if (current == 1) {
				audiosource.PlayOneShot(Pickel_sound);
			}

		}

	}


}
