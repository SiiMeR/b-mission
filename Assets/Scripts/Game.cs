using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{

    public static Game instance;

    public GameObject Flower;
    public float treeDistance = 1f;
    public float speed = 1f;

    private List<GameObject> trees;

    private bool stop;

    void Start()
    {
        stop = false;
        instance = this;
        trees = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject tree = GameObject.Instantiate(Flower); 
            trees.Add(tree);
            float multiplier = Random.Range(0.5f, 2f);
            float vahe = tree.transform.localScale.y * multiplier;
            tree.transform.localScale = new Vector3(tree.transform.localScale.x, tree.transform.localScale.y* multiplier,0);
            tree.transform.position = new Vector3(treeDistance * 7f* i, -1.9f, 0f);
        }
    }

    void Update()
    {
        if (!stop)
        {
            foreach (GameObject tree in trees)
            {
                tree.transform.position -= new Vector3(Time.deltaTime + speed, 0f, 0f);
                if (tree.transform.position.x < -10)
                {
                    tree.transform.position = new Vector3(10f, -1.9f, 0f);
                }
            }
        }
    }

    public void Restart()
    {
        foreach (GameObject tree in trees)
        {
            GameObject.Destroy(tree);
        }
        Start();
    }

    public void StopGame()
    {
        stop = true;
    }
}
