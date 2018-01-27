using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    public GameObject gameStateVar;
    public Vector2 tileSize;
    public Sprite[] backgroundTiles;

    private int tilesToScreenX;
    private int tilesToScreenY;

    private float scrollSpeed;

	// Use this for initialization
	void Start () {
        scrollSpeed = gameStateVar.GetComponent<Game>().speed * 0.5f;
        tilesToScreenX = (int)Mathf.Ceil(Screen.width / tileSize.x) + 1;
        tilesToScreenY = (int)Mathf.Ceil(Screen.height / tileSize.y) + 1;

        for (int x = 0; x < tilesToScreenX; x++)
        {
            for (int y = 0; y < tilesToScreenY; y++)
            {
                GameObject go = new GameObject("BG Tile");
                SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
                renderer.sprite = backgroundTiles[Random.Range(0, backgroundTiles.Length)];
                renderer.sortingLayerName = "Background";
//                Camera.main.ScreenToWorldPoint(new Vector3(x * tileSize.x, y * tileSize.y, -100f));
                go.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x * tileSize.x, y * tileSize.y, 100f)); //new Vector2(x * tileSize.x, y * tileSize.y);
                go.layer = 8;

                go.transform.parent = gameObject.transform;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
