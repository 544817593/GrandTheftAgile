using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;

    private GameObject turret;

    private void OnMouseDown()
    {
        if (turret != null) return;

        Tower turretToBuild = BuildManager.instance.GetSelectedTurret();

        if (turretToBuild.cost > LevelManager.Instance.currency)
        {
            Debug.Log("Not enough currency to build that!");
            return;
        }

        LevelManager.Instance.DecreaseCurrency(turretToBuild.cost);

        turret = Instantiate(turretToBuild.prefab, transform.position, Quaternion.identity);
    }
}
