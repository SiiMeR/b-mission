using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game instance;
    public GameObject gameOverPanel;    
    
    private float timeSpentLayer1;
    private float timeSpentLayer2;
    
    private float timeSinceSpeedChange;

    public List<GameObject> FlowerPrefabs;
    
    public float speed = 1f;
    private float FLOWER_COOLDOWN = 8.0f;
    private float maxSpeed = 50f;
    private float speedIncrement = 0.5f;
    private float speedChangeInterval = 10f;
    
    private List<GameObject> layer1Flowers;
    private List<GameObject> layer2Flowers;
    
    private bool gameOn;

    private bool layer1Active;

    void Start()
    {
        gameOverPanel.SetActive(false);            
        
        timeSpentLayer1 = 5.0f;
        timeSpentLayer2 = 0f;
        
        Example();

        FLOWER_COOLDOWN /=speed;
        layer1Flowers = new List<GameObject>();
        layer2Flowers = new List<GameObject>();
        instance = this;
        gameOn = true;

    }

    void manageLayer1()
    {
        timeSpentLayer1 += Time.deltaTime;
        
        if (timeSpentLayer1 > FLOWER_COOLDOWN)
        {
            timeSpentLayer1 = 0;
            GameObject newFlower = generateNewFlower();

            if (layer1Active)
            {
                setAlphaAndCollision(newFlower,true);
            }
            else
            {
                setAlphaAndCollision(newFlower,false);
            }
            layer1Flowers.Add(newFlower);
        }

        
        layer1Flowers.ForEach(flower =>
        {
            flower.transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);

            if (flower.transform.position.x <= -15)
            {
                layer1Flowers.Remove(flower);
                DestroyImmediate(flower);
            }
        });
        
        
        
        
        
    }

    private void setAlphaAndCollision(GameObject newFlower, bool active)
    {
        var renderers = newFlower.GetComponentsInChildren<Renderer>();
                    
        foreach (var renderer in renderers)
        {
            var materialColor = renderer.material.color;
            
            materialColor.a = active ? 1.0f : 0.3f;
            
            renderer.material.color = materialColor;
        }
                    
        var bColliders = newFlower.GetComponentsInChildren<BoxCollider2D>();
                    
        foreach (var boxCollider2D in bColliders)
        {
            boxCollider2D.enabled = active;
        }
    }

    void manageLayer2()
    {
        timeSpentLayer2 += Time.deltaTime;
        
        if (timeSpentLayer2 > FLOWER_COOLDOWN)
        {
            timeSpentLayer2 = 0;
            GameObject newFlower = generateNewFlower();
            
            if (layer1Active)
            {
                setAlphaAndCollision(newFlower,false);
            }
            else
            {
                setAlphaAndCollision(newFlower,true);
            }
            
            layer2Flowers.Add(newFlower);
        }
        
        layer2Flowers.ForEach(flower =>
        {
            flower.transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);
            if (flower.transform.position.x <= -15)
            {
                layer2Flowers.Remove(flower);
                DestroyImmediate(flower);
            }
        });
        
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            layer1Active = !layer1Active; // flip the active layer
            
            if (layer1Active)
            {
                
                layer1Flowers.ForEach(flower =>
                {
                    var renderers = flower.GetComponentsInChildren<Renderer>();
                    
                    foreach (var renderer in renderers)
                    {
                        var materialColor = renderer.material.color;
                        materialColor.a = 1.0f;
                        renderer.material.color = materialColor;
                    }
                    
                    var bColliders = flower.GetComponentsInChildren<BoxCollider2D>();
                    
                    foreach (var boxCollider2D in bColliders)
                    {
                        boxCollider2D.enabled = true;
                    }
                    

                });
                layer2Flowers.ForEach(flower =>
                {
                    var renderers = flower.GetComponentsInChildren<Renderer>();
                    
                    foreach (var renderer in renderers)
                    {
                        var materialColor = renderer.material.color;
                        materialColor.a = 0.3f;
                        renderer.material.color = materialColor;
                    }
                    
                    var bColliders = flower.GetComponentsInChildren<BoxCollider2D>();
                    
                    foreach (var boxCollider2D in bColliders)
                    {
                        boxCollider2D.enabled = false;
                    }
                    
                });
            }
            else // layer 2 active
            {
                
                layer1Flowers.ForEach(flower =>
                {
                    var renderers = flower.GetComponentsInChildren<Renderer>();
                    
                    foreach (var renderer in renderers)
                    {
                        var materialColor = renderer.material.color;
                        materialColor.a = 0.3f;
                        renderer.material.color = materialColor;
                    }

                    var bColliders = flower.GetComponentsInChildren<BoxCollider2D>();
                    
                    foreach (var boxCollider2D in bColliders)
                    {
                        boxCollider2D.enabled = false;
                    }


                });
                layer2Flowers.ForEach(flower =>
                {
                    var renderers = flower.GetComponentsInChildren<Renderer>();
                    
                    foreach (var renderer in renderers)
                    {
                        var materialColor = renderer.material.color;
                        materialColor.a = 1.0f;
                        renderer.material.color = materialColor;
                    }
                    
                    var bColliders = flower.GetComponentsInChildren<BoxCollider2D>();
                    
                    foreach (var boxCollider2D in bColliders)
                    {
                        boxCollider2D.enabled = true;
                    }
                    
                    
                });
            }
            
        }
        
        if (gameOn)
        {
            manageLayer1();
            manageLayer2();
            
            timeSinceSpeedChange += Time.deltaTime;
            
            if (timeSinceSpeedChange >= speedChangeInterval && speed < maxSpeed)
            {
                speed += speedIncrement;
                timeSinceSpeedChange = 0f;
            }
        }        

    } 

    GameObject generateNewFlower()
    {
        float multiplier = Random.Range(-5f, 0f);
                    
        GameObject randomFlowerPrefab = FlowerPrefabs[Random.Range(0, FlowerPrefabs.Count)];

        float randomDistance = Random.Range(5, 15);
        
        Vector3 fPos =  new Vector3(15 + randomDistance, multiplier, 0f);
        GameObject flower = Instantiate(randomFlowerPrefab, fPos,Quaternion.identity);

        return flower;
        
    }
    IEnumerator Example()
    {
        print("siin");
        yield return new WaitUntil(() =>Input.GetKeyDown("return"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Restart()
    {
        gameOn = false;
        foreach (GameObject flower in layer1Flowers)
        {
            GameObject.Destroy(flower);
        }
        StartCoroutine(Example());
        gameOverPanel.SetActive(true);
    }


}
