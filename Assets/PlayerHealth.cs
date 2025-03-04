using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    private void Update()
    {
        healthText.text = LevelManager.Instance.playerHealth.ToString();
    }
}
