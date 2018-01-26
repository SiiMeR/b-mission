using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public static Game instance;
    
    public List<GameObject> FlowerPrefabs;
    
    public float flowerDistance = 1f;
    public float speed = 1f;

    private List<GameObject> flowers;

    void Start()
    {
        flowers = new List<GameObject>();
        instance = this;
        
        
        for (int i = 0; i < 3; i++)
        {
            GameObject randomFlowerPrefab = FlowerPrefabs[Random.Range(0, FlowerPrefabs.Count)];
            GameObject flower = Instantiate(randomFlowerPrefab); 
            flowers.Add(flower);
            float multiplier = Random.Range(-5f, 0f);
            float vahe = flower.transform.localScale.y * multiplier;
            //tree.transform.localScale = new Vector3(tree.transform.localScale.x, tree.transform.localScale.y* multiplier,0);
            flower.transform.position = new Vector3(flowerDistance * 7f* i, multiplier, 0f);
        }
    }

    void Update()
    {

        foreach (GameObject flower in flowers)
        {
            flower.transform.position -= new Vector3(Time.deltaTime + speed, 0f, 0f);
            if (flower.transform.position.x < -10)
            {
                float multiplier = Random.Range(-5f, 0f);
                flower.transform.position = new Vector3(10f, multiplier, 0f);
            }
        }

    }

    public void Restart()
    {
        foreach (GameObject tree in flowers)
        {
            Destroy(tree);
        }
        Start();
    }

}
