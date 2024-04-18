using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class AchMenu : MonoBehaviour
{
    
    public int money;
    [SerializeField] GameObject prefab;
    [System.Serializable]
    public struct Achivements
    {
        public string content;
        public float reward;
        public bool alreadyTaken;
        public float requirements;
    }
    private float score;
    public Achivements[] objects;
    public GameObject placeAchivements;

    public void Awake()
    {
        
        foreach (var obj in objects)
        {
            GameObject achive = Instantiate(prefab, placeAchivements.transform);
            achive.GetComponentInChildren<TextMeshProUGUI>().text = obj.content;
            if (!obj.alreadyTaken && obj.requirements >= PlayerPrefs.GetFloat("money"))
            {
                achive.GetComponentInChildren<Button>().interactable = true;
                
            }
            else
            {
                achive.GetComponentInChildren<Button>().interactable = false;
            }
        }
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GetReward()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
