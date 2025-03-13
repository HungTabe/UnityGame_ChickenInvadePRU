using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float Speed;
    [SerializeField] private GameObject[] Bulletlist;
    [SerializeField] private int CurrentTierBullet;
    [SerializeField] private GameObject VFX;
    [SerializeField] private GameObject Shield;
    [SerializeField] private int ScoreOfChickenLeg;



    private void Start()
    {
        StartCoroutine(DisableSheild ());
    }
    // Update is called once per frame
    void Update()
    {

        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y, 0);

        transform.position += direction.normalized * Time.deltaTime * Speed;

        Vector3 TopLeftPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, TopLeftPoint.x * -1, TopLeftPoint.x)
            , Mathf.Clamp(transform.position.y, TopLeftPoint.y * -1, TopLeftPoint.y));

        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    

    void Shot()
    {
         
        Instantiate(Bulletlist[CurrentTierBullet], transform.position, Quaternion.identity);
    }

    IEnumerator DisableSheild()
    {
        yield return new WaitForSeconds(8);
        Shield.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Shield.activeSelf && (collision.CompareTag("Chicken") || collision.CompareTag("Egg")))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Chicken leg"))
        {
            Destroy(collision.gameObject);
            ScoreController.instance.GetScore(ScoreOfChickenLeg);
        }
        
        
    }

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded)
        {
           var vfx = Instantiate(VFX, transform.position, Quaternion.identity);
            Destroy(vfx, 1f);
            ShipController.instance.SpawnShip();
        }
    }

}
