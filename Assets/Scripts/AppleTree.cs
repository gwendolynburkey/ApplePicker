using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Prefab for making bombs
    public GameObject bombPrefab;

    // Prefab for making zapple
    public GameObject zapplePrefab;

    // speed that the tree moves
    public float speed = 1f;

    // distance where the AppleTree turns around
    public float leftAndRightEdge = 10f;

    //chance the apple tree will change directions
    public float chanceToChangeDirection = 0.1f;

    // rate at which apples will be created
    public float secondsBetweenAppleDrops = 1f;

    // Apples between levels
    public int applesBetweenLevels = 20;

	// Use this for initialization
	void Start () {
        Invoke("DropThing", 2f);
	}
	
	// Update is called once per frame
	void Update () {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move left
        }
	}

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1; // changes direction
        }
    }

    void DropThing()
    {
        int thing = Random.Range(1, 12);
        if (thing == 11)
        {
            DropZapple();
        }
        else if (thing == 10)
        {
            DropBomb();
        }
        else if (thing < 10)
        {
            DropApple();
        }
    }

    void DropZapple()
    {
        GameObject zapple = Instantiate<GameObject>(zapplePrefab);
        zapple.transform.position = transform.position;
        Invoke("DropThing", secondsBetweenAppleDrops);
    }

    void DropBomb()
    {
        GameObject bomb = Instantiate<GameObject>(bombPrefab);
        bomb.transform.position = transform.position;
        Invoke("DropThing", secondsBetweenAppleDrops);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropThing", secondsBetweenAppleDrops);
        applesBetweenLevels--;
        if (applesBetweenLevels == 0)
        {
            applesBetweenLevels = 20;
            if (secondsBetweenAppleDrops >= 1)
            {
                secondsBetweenAppleDrops -= .3f;
            }
        }
    }
}
