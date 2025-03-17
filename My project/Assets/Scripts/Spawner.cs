using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float gridSize = 1;
    private Vector3 SpawnPos;
    private int ChickenCurrent; // bien de dem nhung chu ga tren man hinh

    [SerializeField] private GameObject ChickenPreFaps;
    [SerializeField] private Transform GirdChicken;
    [SerializeField] private GameObject Boss;

    public static Spawner instance;
    private void Awake()
    {
        instance = this;
    }

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
                Chicken.transform.parent = GirdChicken;
                ChickenCurrent++; // tang bien them 1dvi khi moi chu ga dc tao ra
            }
            SpawnPos.x = x;
            SpawnPos.y -= gridSize;
        }
    }

    public void DecreaChicken()// kiem tra so ga` con lai tren Screen
    {
        ChickenCurrent--;
        if (ChickenCurrent <= 0)
        {
            Boss.gameObject.SetActive(true);
        }
    }
}
