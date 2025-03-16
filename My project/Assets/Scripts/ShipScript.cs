using UnityEngine;

public class ShipScript : MonoBehaviour
{
    // Ship speed var and only this script can access - private and can adjust
    [SerializeField] private float Speed;
    // List store bullet prefabs
    [SerializeField] private GameObject[] BulletList;
    // Var store tier of bullet
    [SerializeField] private int CurrentTierBullet;
    // Game object make VFX HieuUng
    [SerializeField] private GameObject VFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Fire();

    }

    void Move()
    {
        // This value of GetAxisRaw include -1,0,1 according to x and y movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Var - Next direction ship will move
        Vector3 direction = new Vector3(x, y, 0);

        // Normalize to down length of direction to 1 - so min speed change when move
        transform.position += direction.normalized * Time.deltaTime * Speed;

        // Convert coordinates from the screen to the world to know the limit of the screen in the 3D coordinate system by TopLeftPoint
        Vector3 TopLeftPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        /*
         🔹 Keep the ship in the screen by limiting X and Y within the range of Topleftpoint.
         🔹 Use mathf.clamp () to make sure the ship does not go out to the play area.
         */
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, TopLeftPoint.x * -1, TopLeftPoint.x),
            Mathf.Clamp(transform.position.y, TopLeftPoint.y * -1, TopLeftPoint.y));
    }

    // Shoot function
    void Fire()
    {
        // Condition to avoid continuous shooting
        if (Input.GetMouseButtonDown(0)) {
            /*
            Instantiate (Bulletlist [curletierbullet], Transform.position, Quatnion.Itentity);

            Bulletlist [curlentiierbullet]
                Bulletlist is a list (list or array) containing bullets.
                CurrentTiierbullet is the index (Index) to select the current type of ammunition from the list.
                For example, if curlentiierbullet = 1, the second bullet in the Bulletlist list will be fired.

            Transform.position
                The location of the object calls the Fire () function (usually the position of the gun or ship).
                The bullet will appear correctly at the position of this object.

            Quatnion.Dentity
                Quatnion is the type of data that shows the rotating angle in 3D space.
                Quatnion.Dentity means not rotating (rotation angle of 0).
                The bullet will be created without being rotated. 

            */
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(BulletList[CurrentTierBullet], transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check tag to determine case destroy ship
        if (collision.CompareTag("Chicken") || collision.CompareTag("Egg"))
        {
            Destroy(gameObject);
        }

    }

    // OnDestroy run when this gameObj is destroyed
    private void OnDestroy()
    {
        // Check scene still running or not to show VFX
        if(gameObject.scene.isLoaded)
        {
            /* Make gameObj of Explosion base on prefabs VFX, location is ship location, no z round */
            // make var of explosion then destroy after 1s

            var vfx = Instantiate(VFX, transform.position, Quaternion.identity);

            Destroy(vfx, 1f);
        }

    }
}
