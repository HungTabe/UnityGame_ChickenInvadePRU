using UnityEngine;

public class ShipScript : MonoBehaviour
{
    // Ship speed var and only this script can access - private and can adjust
    [SerializeField] private float Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This value of GetAxisRaw include -1,0,1 according to x and y movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Var - Next direction ship will move
        Vector3 direction = new Vector3(x, y, 0);

        // Normalize to down length of direction to 1 - so min speed change when move
        transform.position += direction.normalized * Time.deltaTime * Speed;

        // Convert coordinates from the screen to the world to know the limit of the screen in the 3D coordinate system by TopLeftPoint
        Vector3 TopLeftPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));

        /*
         🔹 Keep the ship in the screen by limiting X and Y within the range of Topleftpoint.
         🔹 Use mathf.clamp () to make sure the ship does not go out to the play area.
         */
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,TopLeftPoint.x*-1,TopLeftPoint.x),
            Mathf.Clamp(transform.position.y,TopLeftPoint.y*-1,TopLeftPoint.y));


    }
}
