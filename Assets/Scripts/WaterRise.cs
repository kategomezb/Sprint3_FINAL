using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaterRise : MonoBehaviour
{
    public float riseSpeed = 0.1f;
    public Transform bessie;

    public int bessieMaxHealth = 100;
    public int bessieCurrentHealth;
    public Slider waterLevelSlider;
    public Slider healthSlider;
    public Image fill;
    public Gradient gradient;

    public float damagePerSecond = 10f;
    public float waterStartY = 5.54f;
    public float waterStopY = 7.37f;

    private bool hasWaterTouchedBessie = false;
    private Vector3 startPosition;
    private bool isRising = true;

    public GameObject deathMessagePanel; 
    public float restartDelay = 3f;

    void Start()
    {
        startPosition = new Vector3(536.41f, -0.13f, 600.16f);
        transform.position = startPosition;

        bessieCurrentHealth = bessieMaxHealth;

        healthSlider.maxValue = bessieMaxHealth;
        healthSlider.value = bessieCurrentHealth;
        fill.color = gradient.Evaluate(1f);

        if (waterLevelSlider != null)
        {
            waterLevelSlider.minValue = startPosition.y;
            waterLevelSlider.maxValue = waterStopY;
            waterLevelSlider.value = transform.position.y;
        }

        if (deathMessagePanel != null)
        {
            deathMessagePanel.SetActive(false); 
        }
    }

    void Update()
    {
        if (isRising && transform.position.y < waterStopY)
        {
            transform.position += new Vector3(0, riseSpeed * Time.deltaTime, 0);

            if (waterLevelSlider != null)
            {
                waterLevelSlider.value = transform.position.y;
            }
        }

        if (transform.position.y >= waterStartY && !hasWaterTouchedBessie)
        {
            hasWaterTouchedBessie = true;
            Debug.Log("Water touched Bessie!");
        }

        if (hasWaterTouchedBessie && bessieCurrentHealth > 0)
        {
            ApplyDamageToBessie();
        }
    }

    void ApplyDamageToBessie()
    {
        float damage = damagePerSecond * Time.deltaTime;
        bessieCurrentHealth -= Mathf.RoundToInt(damage);
        if (bessieCurrentHealth < 0) bessieCurrentHealth = 0;

        Debug.Log($"Damage applied: {damage}, Current health: {bessieCurrentHealth}");

        UpdateHealthBar();

        if (bessieCurrentHealth <= 0)
        {
            Debug.Log("Bessie died. Displaying message and restarting...");
            ShowDeathMessage();
        }
    }

    void UpdateHealthBar()
    {
        healthSlider.value = bessieCurrentHealth;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

    void ShowDeathMessage()
    {
        if (deathMessagePanel != null)
        {
            deathMessagePanel.SetActive(true); 
        }

        Invoke("RestartGame", restartDelay);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
