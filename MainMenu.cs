using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    

  
    void Start()
    {
        
        
        //StartCoroutine(IdleFarm());
    }

    public  void ToAchive()
    {
        SceneManager.LoadScene(2);
    }
    //IEnumerator IdleFarm()
    //{
    //    yield return new WaitForSeconds(1);
    //    money = PlayerPrefs.GetInt("money");
    //    money++;
        
    //    PlayerPrefs.SetInt("money", money);
    //    StartCoroutine(IdleFarm());
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
