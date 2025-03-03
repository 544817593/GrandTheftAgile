using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [Header("References")]
    [SerializeField] private GameObject[] buildingPrefabs;

    private int selectedTurret = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject GetSelectedTurret()
    {
        return buildingPrefabs[selectedTurret];
    }
}
