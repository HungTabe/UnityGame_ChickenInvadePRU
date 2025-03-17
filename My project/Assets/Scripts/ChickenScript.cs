using UnityEngine;
using System.Collections;

public class ChickenScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject EggPreFaps;
    [SerializeField] private int score;
    [SerializeField] private GameObject chickenLePreFaps;

    private void Awake()
    {
        StartCoroutine(SpamEgg());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpamEgg()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4, 20));
            Instantiate(EggPreFaps, transform.position, Quaternion.identity);

            

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            ScoreController.instance.GetScore(score);
            Instantiate(chickenLePreFaps, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Spawner.instance.DecreaChicken();
    }

}
