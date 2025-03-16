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
            yield return new WaitForSeconds(Random.Range(4, 20));

            Instantiate(EggPrefabs, transform.position, Quaternion.identity);
        }
    }

    // OnTriggerEnter2D of chicken
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
