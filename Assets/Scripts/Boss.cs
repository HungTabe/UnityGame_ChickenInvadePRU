using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject EggPreFaps;
    void Start()
    {
        StartCoroutine(Spawnegg());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Spawnegg()
    {
        while (true)
        {
            Instantiate(EggPreFaps, transform.position, Quaternion.identity);   
            yield return new WaitForSeconds(Random.Range(0.0f, 1.0f));
        }
    }
}
