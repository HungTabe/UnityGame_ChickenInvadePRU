using UnityEngine;

public class BulletScipt : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float DistancesDestroy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DistancesDestroy = 10;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Make the bullet move straight up on the Y axis.

        * Vector3.up = (0.1.0), which means moving up to the axis Y.
        * Time.deltatime helps to move smoothly, not affected by the frame speed (FPS).
        * Speed ​​is the velocity of the bullet, which can be changed with Inspector because of using [serialfield]. 
        */
        transform.Translate(Vector3.up * Time.deltaTime * Speed);

        // Call continuously to check and destroy bullet
        DestroyIFReachDistances();
    }

    void DestroyIFReachDistances()
    {
        /*
         Screen.WIDTH / 2, Screen.Height / 2 → Determine the central pixel coordinates.
         Camera.main.scrientowAmindpoint (...) → convert the screen coordinates into the world coordinates (World Space).
        */
        Vector3 CenterScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2), 0);

        // If the object is a bigger distance from the center of the screen, it will be canceled.
        // Calculate the distance between the object and the center of the screen with vector3.distance ().
        if (Vector3.Distance(CenterScreen, transform.position) > DistancesDestroy)
        {
            Destroy(this.gameObject);
        }

    }
}
