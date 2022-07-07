using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    // counter for the remaining collectibles in the scene
    public int counter;

    public GameObject bonusObject;

    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.FindGameObjectsWithTag("Pick Up").Length;    
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Pickup()
    {
        print("Pickup message has been received");
        counter--;

        if (counter == 0)
            SpawnBonus();
    }

    public void SpawnBonus()
    {
        // Instantiate our Prefab!
        GameObject.Instantiate(bonusObject, transform);

    }
}
