using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float gridSize = 1;
    private Vector3 SpawnPos;
    [SerializeField] private GameObject ChickenPreFaps;
    //[SerializeField] private Transform GirdChicken;
    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;

        SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));

        SpawnPos.x += ((gridSize / 2 + (width / 4)));
        SpawnPos.y -= gridSize;
        SpawnPos.z = 0;
        SpawnChicken(Mathf.FloorToInt(height / 2 / gridSize), Mathf.FloorToInt(width / gridSize / 1.5f));
    }

    void SpawnChicken(int row, int numberChicken)
    {
        float x = SpawnPos.x;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < numberChicken; j++)
            {
                SpawnPos.x = SpawnPos.x + gridSize;
                GameObject Chicken = Instantiate(ChickenPreFaps, SpawnPos, Quaternion.identity);
                // Chicken.transform.parent = GirdChicken;
            }
            SpawnPos.x = x;
            SpawnPos.y -= gridSize;
        }
    }

}
