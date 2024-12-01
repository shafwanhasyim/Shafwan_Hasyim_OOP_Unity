using UnityEngine;
using TMPro;

public class UIControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemiesText;

    private CombatManager combatManager;
    private HealthComponent playerHealth;

    void Start()
    {
        combatManager = FindObjectOfType<CombatManager>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<HealthComponent>();
        }
    }

    void Update()
    {
        UpdatePoints();
        UpdateHealth();
        UpdateWave();
        UpdateEnemies();
    }

    private void UpdatePoints()
    {
        if (pointsText != null && combatManager != null)
        {
            pointsText.text = $"Points: {combatManager.totalPoints}";
        }
    }

    private void UpdateHealth()
    {
        if (healthText != null && playerHealth != null)
        {
            healthText.text = $"Health: {playerHealth.getHealth()}";
        }
    }

    private void UpdateWave()
    {
        if (waveText != null && combatManager != null)
        {
            waveText.text = $"Wave: {combatManager.waveNumber}";
        }
    }

    private void UpdateEnemies()
    {
        if (enemiesText != null && combatManager != null)
        {
            enemiesText.text = $"Enemies: {combatManager.totalEnemies}";
        }
    }
}