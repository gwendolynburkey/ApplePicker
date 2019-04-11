using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
	// Use this for initialization
	void Start () {
        basketList = new List<GameObject>();

		for(int i=0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
	}

    public void AppleDestroyed()
    {
        //Destroy all the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        // Destroy all bombas
        GameObject[] tBombArray = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject tGO in tBombArray)
        {
            Destroy(tGO);
        }

        // Destroy all zapples
        GameObject[] tZappleArray = GameObject.FindGameObjectsWithTag("Zapple");
        foreach (GameObject tGO in tZappleArray)
        {
            Destroy(tGO);
        }

        //Destroy one of the baskets
        //Get the index of the last basket in basketlist
        int basketIndex = basketList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];
        // Removes the basket from the list and destroys the object
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        // if there are no Baskets left, restart game.
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
