using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;

    private void OnGUI()
    {
        currencyUI.text = LevelManager.Instance.currency.ToString();
    }

    public void SetSelected()
    {

    }
}
