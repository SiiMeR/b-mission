using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    public GameObject gameStateVar;
    public Vector2 tileSize;
    public Sprite[] backgroundTiles;
    public float speedMultiplier = 0.5f;

    private int tilesToScreenX;
    private int tilesToScreenY;

    private float scrollSpeed;

	// Use this for initialization
	void Start () {
        scrollSpeed = gameStateVar.GetComponent<Game>().speed * speedMultiplier;
        tilesToScreenX = (int)Mathf.Ceil(Screen.width / tileSize.x) + 1;

        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float halfScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;//    Screen.width / 2;

        for (int x = 0; x < tilesToScreenX; x++)
        {
            GameObject go = new GameObject("BG Tile");
            SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
            renderer.sprite = backgroundTiles[Random.Range(0, backgroundTiles.Length)];
            renderer.sortingLayerName = "Background";
            //                Camera.main.ScreenToWorldPoint(new Vector3(x * tileSize.x, y * tileSize.y, -100f));
            float scaleMultiplier = worldScreenHeight / renderer.sprite.bounds.size.y;
            go.transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, 1f);
            go.transform.position = new Vector3(x * (tileSize.x / renderer.sprite.pixelsPerUnit) * scaleMultiplier - halfScreenWidth, 0f, 100f);//Camera.main.ScreenToWorldPoint(new Vector3(x * tileSize.x, y * tileSize.y, 11f)); //new Vector2(x * tileSize.x, y * tileSize.y);
            go.layer = 8;

            go.transform.parent = gameObject.transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        foreach (Transform child in transform)
        {
            //child is your child transform
            child.position = new Vector3(child.position.x - scrollSpeed * Time.deltaTime, child.position.y, child.position.z);
        }
    }
}
