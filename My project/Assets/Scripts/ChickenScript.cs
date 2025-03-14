using System.Collections;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{

    // Make game object for egg prefab
    [SerializeField] private GameObject EggPrefabs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Awake Called as soon as Gamebject is activated, before the Start ().
    private void Awake()
    {
        StartCoroutine(SpawnEgg());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn egg function
    IEnumerator SpawnEgg()
    {
        while (true)
        {
            Instantiate(EggPrefabs, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2, 7));
        }
    }
}
