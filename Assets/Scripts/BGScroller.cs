using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    public GameObject gameStateVar;
    public Vector2 tileSize;
    public Sprite[] backgroundTiles;
    public float speedMultiplier = 0.5f;
    public int layerNumber = 8;
    public string sortingLayer;

    private int tilesToScreenX;
    private int tilesToScreenY;
    private Vector2 resolution;
    private float worldScreenHeight;
    private float halfScreenWidth;

    private float scrollSpeed;

	// Use this for initialization
	void Start () {
        resolution = new Vector2(Screen.width, Screen.height);
        tilesToScreenX = (int)Mathf.Ceil(Screen.width / tileSize.x) + 1;

        worldScreenHeight = Camera.main.orthographicSize * 2;
        halfScreenWidth = Camera.main.orthographicSize * resolution.x / resolution.y;

        for (int x = 0; x < tilesToScreenX; x++)
        {
            CreateTile(x);
        }
    }
	
    void FixedUpdate()
    {
        foreach (Transform child in transform)
        {
            float newX = child.position.x - scrollSpeed * Time.deltaTime;
            if (newX < -child.GetComponent<SpriteRenderer>().sprite.bounds.size.x * worldScreenHeight / child.GetComponent<SpriteRenderer>().sprite.bounds.size.y - (child.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2))
            {
                Destroy(child.gameObject);

                CreateTile(tilesToScreenX - 1);
            }
            scrollSpeed = gameStateVar.GetComponent<Game>().speed * speedMultiplier;
            child.position = new Vector3(child.position.x - scrollSpeed * Time.deltaTime, child.position.y, child.position.z);
            
        }
    }

    void CreateTile(int x)
    {
        GameObject go = new GameObject("BG Tile");
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer.sprite = backgroundTiles[Random.Range(0, backgroundTiles.Length)];
        renderer.sortingLayerName = sortingLayer;
        go.layer = layerNumber;
        float scaleMultiplier = worldScreenHeight / renderer.sprite.bounds.size.y;
        go.transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, 1f);
        float posX = x * renderer.sprite.bounds.size.x * scaleMultiplier - (renderer.sprite.bounds.size.x / 2);
        go.transform.position = new Vector3(posX, 0f, 100f);

        go.transform.parent = gameObject.transform;
    }
}
