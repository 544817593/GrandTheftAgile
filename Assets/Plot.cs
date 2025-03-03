using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;

    private GameObject turret;

    private void OnMouseDown()
    {
        if (turret != null) return;

        GameObject turretToBuild = BuildManager.instance.GetSelectedTurret();
        turret = Instantiate(turretToBuild, transform.position, Quaternion.identity);
    }
}
