using UnityEngine;
using System.Collections;

public class AnimateBonus : MonoBehaviour {

	// Use this for initialization
	public float startPosition = 0;
	float coolDown = 0.5f;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		startPosition += 15;
		GetComponent<GUIText>().pixelOffset = new Vector2 (-50, startPosition);
		coolDown -= Time.deltaTime;
		if (coolDown < 0) {
			Destroy(this.gameObject);
				}
				}
	}
