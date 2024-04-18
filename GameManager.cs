using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
    public float gameSpeed {  get; private set; }
    public float initialGameSpeed = 3f;
    public float gameSpeedIncrease = 0.1f;

    private PlayerMovement player;
    private Spawner spawner;

    public TextMeshProUGUI restartText;
    public Button retryButton;

    public TextMeshProUGUI scoreText;

    private float score;

    [SerializeField] int money;
    [SerializeField] TextMeshProUGUI moneyText;

    public GameObject enemy;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        money = PlayerPrefs.GetInt("money");
        
        
    }
    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        spawner = FindObjectOfType<Spawner>();
        NewStart();
    }

    public void NewStart()
    {
        
        gameSpeed = initialGameSpeed;
        enabled = true;
        player.gameObject.transform.position = new Vector3(0.15f, 0.022f, 0);
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        
        restartText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        score = PlayerPrefs.GetFloat("score");
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");

        Instantiate(enemy);
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        PlayerPrefs.SetFloat("score", score);
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
        moneyText.text = money.ToString();
    }

    public void GetButton()
    {

        money++;
        PlayerPrefs.SetInt("money", money);

    }

    public void GameOver() 
    { 
    
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);

        restartText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        GameObject enemyAsset = GameObject.FindGameObjectWithTag("Enemy");
        Destroy(enemyAsset);
        PlayerPrefs.SetFloat("score", 0);
    }
}
