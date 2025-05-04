using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isHeroModeMouse = true; 
    public int enemiesTouched = 0;
    public int eggCount = 0;     
    public int enemyCount = 0;          
    public int enemiesDestroyed = 0;

    public TextMeshProUGUI heroModeText;
    public TextMeshProUGUI eggCountText;
    public TextMeshProUGUI enemyText;

    public bool isPaused = false;
    public GameObject pauseOverlay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  
        }
        DontDestroyOnLoad(gameObject);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            if (pauseOverlay != null) pauseOverlay.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            if (pauseOverlay != null) pauseOverlay.SetActive(false);
        }
    }

    public void SwitchHeroMode()
    {
        isHeroModeMouse = !isHeroModeMouse;
        UpdateUI();
    }

    public void IncreaseEggCount()
    {
        eggCount++;
        UpdateUI();
    }

    public void DecreaseEggCount()
    {
        eggCount--;
        UpdateUI();
    }


    public void UpdateEnemyCount(int change)
    {
        enemyCount += change;
        UpdateUI();
    }

    public void IncreaseEnemiesDestroyed()
    {
        enemiesDestroyed++;
        UpdateUI();
    }

    public void IncreaseEnemiesTouched()
    {
        enemiesTouched++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        heroModeText.text = "Hero: Drive(" + (isHeroModeMouse ? "Mouse" : "Keyboard")+ ")" + " TouchedEnemy(" + enemiesTouched + ")";

        eggCountText.text = "Egg: OnScreen(" + eggCount + ")";

        enemyText.text = "Enemy: Count(" + enemyCount + ")" + " Destroyed(" + enemiesDestroyed + ")";

      
    }

}
