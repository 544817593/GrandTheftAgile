using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [Header("References")]
    [SerializeField] private Tower[] towers;

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

    public Tower GetSelectedTurret()
    {
        return towers[selectedTurret];
    }

    public void SetSelectedTurret(int selectedTurret)
    {
        this.selectedTurret = selectedTurret;
    }
}
