using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject EggPreFaps;
    [SerializeField] private int health = 100; // mau Boss
    [SerializeField] private GameObject VFX; //  hieu ung khi Boss die

    public static Boss instance;

    void Start()
    {
        StartCoroutine(Spawnegg());
        StartCoroutine(MoveBossToRandomPoint());
    }

    private void Awake()
    {
        instance = this;
    }


    public void PutDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            var vfx = Instantiate(VFX, transform.position,Quaternion.identity);
            Destroy(vfx, 1);
        }
    }


    IEnumerator Spawnegg()
    {
        while (true)
        {
            Instantiate(EggPreFaps, transform.position, Quaternion.identity);   
            yield return new WaitForSeconds(Random.Range(0.0f, 1.0f));
        }
    }


    IEnumerator MoveBossToRandomPoint()
    {
        Vector3 point = getRandomPoint();

       while(transform.position != point)
        {
            transform.position = Vector3.MoveTowards(transform.position, point, 0.1f);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
       StartCoroutine(MoveBossToRandomPoint()); 
    }


    Vector3 getRandomPoint()
    {
        Vector3 posRandom = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0.5f, 1)));
        posRandom.z = 0;
        return posRandom;
    }
}
