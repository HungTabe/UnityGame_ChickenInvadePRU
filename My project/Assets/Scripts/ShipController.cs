using System.Threading;
using UnityEngine;
using System.Collections;
using System.Timers;

public class ShipController : MonoBehaviour
{
    public static ShipController instance;

    [SerializeField] private GameObject ShipPreFaps;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnShip()
    {
       var newShip = Instantiate(ShipPreFaps, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, -0.5f, 0)),Quaternion.identity);
       var point = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.1f,0));
        point.z = 0;
        StartCoroutine(MoveShipToPoint(newShip, point));
    }

    IEnumerator MoveShipToPoint(GameObject ship, Vector3 point)
    {
        float time = 0;

        while (ship && ship.transform.position!=point)
        {
            time += Time.fixedDeltaTime;
            ship.transform.position = Vector3.Lerp(ship.transform.position, point, time);
            yield return new WaitForFixedUpdate();
        }
    }
}
