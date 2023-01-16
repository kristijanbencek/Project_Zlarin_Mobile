using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Manager : MonoBehaviour
{
    [Header("Other scripts references")]
    [SerializeField] GameManager gm;
    [SerializeField] CoralState coralState;

    [Header("MainMenuSettings")]
    public GameObject ageAndLanguageSettings;//Change age or language while in main menu
    bool ageAndLang = false;
    public GameObject deactivateMechanicButtons;
    bool mechanicButtonsActive = true;

    public GameObject[] textContent;
    public Image[] statusImages;
   
    public TMP_InputField ageInputField;
    public TMP_Text statusText;

    //FirstLoadOnly
    public GameObject[] activeOnFirstLoadOnly;

    //public Slider happySad;
    //public Slider healthinesSlider;
    //public Slider FoodSlider;
    //public Slider WaterSlider;
    //public Slider TirednessSlider;

    private void Start()
    {
        if(gm.firstLoad == true)
        {
            activeOnFirstLoadOnly[0].SetActive(false);
        }
        else
        {
            activeOnFirstLoadOnly[0].SetActive(true);
        }
        
        //GetTimer();
        //SetSliderValues(); Not currently needed
        InvokeRepeating("DecreaseSliderValues", 1, 1);
    }
    
    public void AgeVerification(string age)
    {
        string choice = age;
        switch (choice)
        {
            case "younger": LoadEasierQuestions(); break;
            case "older": LoadHarderQuestions(); Debug.Log("Test") ; break;
        }
    }//Method that verifies user's age and gives them questions based on them being younger or older than 15
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
    public void ActivateDeactivateSettingsMenu()
    {
        coralState.coralVisible = !coralState.coralVisible;
        coralState.modelMesh.enabled = coralState.coralVisible;
        coralState.eyesRender[0].enabled = coralState.coralVisible;
        coralState.eyesRender[1].enabled = coralState.coralVisible;

        ageAndLang = !ageAndLang;
        ageAndLanguageSettings.SetActive(ageAndLang);

        mechanicButtonsActive = !mechanicButtonsActive;
        deactivateMechanicButtons.SetActive(mechanicButtonsActive);
    }
    #endregion
    #region TamaKurac stats
    void DecreaseSliderValues()
    {

        //happySad.value -= .01f;
        //healthinesSlider.value -= .01f;
    }//Constantly decreases value of both sliders
    void SetSliderValues()
    {
        //happySad.maxValue = 100;
        //healthinesSlider.maxValue = 100;
    }//Sets the starting values on application start
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
