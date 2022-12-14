using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Manager : MonoBehaviour
{
    public GameManager gm;

    public GameObject[] textContent;
    public Image[] statusImages;
   
    public TMP_InputField ageInputField;
    public TMP_Text statusText;

    //public Slider happySad;
    //public Slider healthinesSlider;
    //public Slider FoodSlider;
    //public Slider WaterSlider;
    //public Slider TirednessSlider;

    private void Start()
    {
        //GetTimer();
        SetSliderValues();
        InvokeRepeating("DecreaseSliderValues", 1, 1);
    }
    
    public void TestingPurposes()
    {
        
        switch (int.Parse(ageInputField.text))
        {
            case <=15: LoadEasierQuestions(); break;
            case >15: LoadHarderQuestions(); Debug.Log("Test") ; break;
        }
    }//as it say, testing purposes
    #region Questions & Age
    void LoadEasierQuestions()
    {
        for (int i = 0; i < textContent.Length; i++)
        {
            textContent[i].SetActive(false);
            textContent[0].SetActive(true);
        }
    }//If the age is below 15, easier questions are laoded
    void LoadHarderQuestions()
    {
        for (int i = 0; i < textContent.Length; i++)
        {
            textContent[i].SetActive(false);
            textContent[1].SetActive(true);
        }
    } //If the age is above 15, harder questions are loaded
    #endregion
    #region TamaKurac status
    void DecreaseSliderValues()
    {

        //happySad.value -= .01f;
        //healthinesSlider.value -= .01f;
    }//Constantly decreases value of both sliders
    void SetSliderValues()
    {
        //happySad.maxValue = 100;
        //healthinesSlider.maxValue = 100;
    }
    #endregion
    #region BackgroundTimer
    //public void Test()
    //{
    //    float date = DateTime.UtcNow.Ticks;
    //    PlayerPrefs.SetFloat("lastDate", date);
    //    PlayerPrefs.Save();
    //}
    //public void QuitMOde()
    //{
    //    Test();
    //}
    //public void GetTimer()
    //{
    //    long last = Convert.ToInt64(PlayerPrefs.GetFloat("lastDate"));
    //    DateTime oldDate = DateTime.FromBinary(last);
    //    DateTime currentDate = DateTime.Now;

    //    TimeSpan difference = currentDate.Subtract(oldDate);

    //    Debug.Log(oldDate.ToString("dd-MM-yyyy-hh-mm-ss"));
    //    Debug.Log(currentDate.ToString("dd-MM-yyyy-hh-mm-ss"));
    //    Debug.Log(difference.TotalSeconds);
        
        
    //}
    #endregion 


}