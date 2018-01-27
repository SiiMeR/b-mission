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
    private float worldScreenWidth;
    private float halfScreenWidth;
    private float scaleMultiplier;

    private float scrollSpeed;

	// Use this for initialization
	void Start () {
        worldScreenHeight = Camera.main.orthographicSize * 2;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        scaleMultiplier = worldScreenHeight / backgroundTiles[0].bounds.size.y;
        tileSize = new Vector2(backgroundTiles[0].bounds.size.x * scaleMultiplier, backgroundTiles[0].bounds.size.y * scaleMultiplier);
        tilesToScreenX = (int)Mathf.Ceil(worldScreenWidth / tileSize.x) + 1;

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
            if (newX < -tileSize.x - worldScreenWidth / 2.0f)//child.GetComponent<SpriteRenderer>().sprite.bounds.size.x * worldScreenHeight / child.GetComponent<SpriteRenderer>().sprite.bounds.size.y - child.GetComponent<SpriteRenderer>().sprite.bounds.size.x)
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
        go.transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, 1f);
        float posX = (int)((x * tileSize.x - worldScreenWidth / 2.0f) * 1000.0f) / 1000.0f;//x * tileSize.x - worldScreenWidth / 2f * 1000f; //Mathf.Round(x * tileSize.x - worldScreenWidth / 2f);
        go.transform.position = new Vector3(posX, 0f, 100f);

        go.transform.parent = gameObject.transform;
    }
}
