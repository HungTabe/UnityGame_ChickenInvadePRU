using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Grid size var : The size of each grid.
    private float gridSize = 1;
    // Spawner position
    private Vector3 SpawnPos;

    [SerializeField] private GameObject ChickenPrefaps;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
          Camera.main.orthographicSize only give us half the height of the screen in 2D space.
          According to user screen size & height to find out width
        */
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;

        SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0));

        SpawnPos.x += ((gridSize / 2 + (width / 4)));
        SpawnPos.y -= gridSize / 2;
        SpawnPos.z = 0;
        SpawnChicken(Mathf.FloorToInt(height / 2 / gridSize), Mathf.FloorToInt(width / gridSize / 1.5f));

    }

    void SpawnChicken(int row, int numberChicken)
    {
        // x to save origin position of SpawnPos
        float x = SpawnPos.x;

        for (int i = 0; i < row; i++)
        {
            // for to spawn chicken row
            for (int j = 0; i < numberChicken; j++)
            {
                // Increase SpawnPos.x 1 grid size
                SpawnPos.x = SpawnPos.x + gridSize;
                GameObject Chicken = Instantiate(ChickenPrefaps,SpawnPos,Quaternion.identity);
            }
            SpawnPos.x = x;
            SpawnPos.y -= gridSize;
        }

    }
    
}
