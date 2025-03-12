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
    }
}
