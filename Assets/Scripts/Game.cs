using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private const float FLOWER_COOLDOWN = 5.0f;
    private float timeSpent;
    
    public List<GameObject> FlowerPrefabs;
    
    public float flowerDistance = 1f;
    public float speed = 1f;

    private List<GameObject> flowers;

    void Start()
    {
        flowers = new List<GameObject>();
        
        for (int i = 0; i < 3; i++)
        {
            float multiplier = Random.Range(-5f, 0f);
            
            GameObject randomFlowerPrefab = FlowerPrefabs[Random.Range(0, FlowerPrefabs.Count)];
            Vector3 pos =  new Vector3(5 + flowerDistance * 7f* i, multiplier, 0f);
            
            GameObject flower = Instantiate(randomFlowerPrefab, pos,Quaternion.identity); 
            flowers.Add(flower);
            
            float vahe = flower.transform.localScale.y * multiplier;
            //tree.transform.localScale = new Vector3(tree.transform.localScale.x, tree.transform.localScale.y* multiplier,0);
            
        }
    }

    void Update()
    {
        timeSpent += Time.deltaTime;
        
        foreach (GameObject flower in flowers)
        {
            flower.transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);
            if (flower.transform.position.x < -10 && timeSpent > FLOWER_COOLDOWN)
            {
                timeSpent = 0;
                float multiplier = Random.Range(-5f, 0f);
                flower.transform.position = new Vector3(10f, multiplier, 0f);
            }
        }

    }


}
