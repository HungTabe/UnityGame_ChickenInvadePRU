using UnityEngine;

public class BulletScipt : MonoBehaviour
{
    [SerializeField] private float Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
}
