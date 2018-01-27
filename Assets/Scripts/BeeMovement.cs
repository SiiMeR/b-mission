using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {
    private float move_x = 0.0f;
    private float move_y = 0.0f;
    private Rigidbody2D rb2d;

    private float pos_x;
    private float pos_y;
    private float leftBorder;
    private float rightBorder;
    private float topBorder;
    private float bottomBorder;

    public float bee_speed = 10.0f;
    

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        CalcScreenBorders();
    }
	
	// Update is called once per frame
	void Update () {
        float move_x = Input.GetAxis("Horizontal");
        float move_y = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(bee_speed * move_x, bee_speed * move_y);
/*        transform.position = (new Vector3(
    Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
    Mathf.Clamp(transform.position.y, bottomBorder, topBorder),
    transform.position.z)
);*/
        /*        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
                pos.x = Mathf.Clamp(pos.x, leftBorder, rightBorder);
                pos.y = Mathf.Clamp(pos.y, bottomBorder, topBorder);
                transform.position = Camera.main.ViewportToWorldPoint(pos);*/
    }

    void CalcScreenBorders ()
    {
        Vector3 beeSize = GetComponent<SpriteRenderer>().bounds.size;

        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x + (beeSize.x / 2);
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x - (beeSize.x / 2);
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).x + (beeSize.y / 2);
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x - (beeSize.y / 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.transform.position = new Vector3(-8    , 3, 0);
        GetComponent<Animator>().SetTrigger("Deadth");
        AudioManager.instance.StopAllMusic();
        AudioManager.instance.Play("Death Sound");
        Game.instance.Restart();

    }
}
