using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {
    private float move_x = 0.0f;
    private float move_y = 0.0f;
//    private Rigidbody2D rb2d;

    private float pos_x;
    private float pos_y;
    private float bee_width;
    private float bee_height;

    public float bee_speed = 10.0f;
    

	// Use this for initialization
	void Start () {
//        rb2d = GetComponent<Rigidbody2D>();
//        bee_width = 
	}
	
	// Update is called once per frame
	void Update () {
        float move_x = Input.GetAxis("Horizontal");
        float move_y = Input.GetAxis("Vertical");
        if (move_x > 0.0f)
        {
            transform.position = new Vector3(transform.position.x + bee_speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (move_x < 0.0f)
        {
            transform.position = new Vector3(transform.position.x - bee_speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (move_y > 0.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + bee_speed * Time.deltaTime, transform.position.z);
        }
        if (move_y < 0.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - bee_speed * Time.deltaTime, transform.position.z);
        }
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
