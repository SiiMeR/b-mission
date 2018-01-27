using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float scaleMultiplier = worldScreenHeight / GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, 1f);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
