using System;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [Header("Other scripts references")]
    [SerializeField] UI_Manager ui;
    [SerializeField] SceneManagment sceneManager;
    [SerializeField] GameData gameData;

    [SerializeField] string output = "";
    [SerializeField] float max = 100;
    [SerializeField] float timer = 2;
    [SerializeField] float min = 0;

    //Save system
    //public Text saveDataTest;
    public int test;
    public GameObject coralState;
    public float secondsPassedSinceLastQuit;


    [TextArea]
    public string myTextArea;
    //Hrana
    public float hunger;
    //Voda
    public float thirst = 100;
    //�etnja
    public float walking = 100;
    //Igra
    public float boredness = 100;
    //Spavanje
    public float energy = 100;

    private DateTime currentDate;
    public Text testingTextForTime;
    public bool firstLoad = true;
    //private DateTime lastDateOnAppQuit;
    //private TimeSpan difference;

    private void Awake()
    {
        gameData = SaveSystem.Load();
        LoadData();
    }
    void Start()
    {
        LoadDateAndTime();
        BackgroundValuesChange();
        InvokeRepeating("UpdateMethod", 0, 1);
    }
    private void Update()
    {
        if (gameData.firstLoad == true)
        {
            coralState.SetActive(false);
        }
        else
        {
            coralState.SetActive(true);
        }
        for (int i = 0; i < ui.activeOnFirstLoadOnly.Length; i++)
        {
            ui.activeOnFirstLoadOnly[i].SetActive(gameData.firstLoad);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApp();
        }
    }
    void UpdateMethod()
    {
        ClearText();
       // LooseAll();
    }//custom update method
    void LooseAll()
    {
        if (hunger > 0)
            hunger -= .1f;
        if (thirst > 0)
            thirst -= .1f;
        if (walking > 0)
            walking -= .1f;
        if (boredness > 0)
            boredness -= .1f;
        if (energy > 0)
            energy -= .1f;
        SaveWhileInBackground();
    }//Method that makes koralj loose everything over time
    #region Koralj mechanics
    public void HungerMechanic()
    {
        hunger = Mathf.Clamp(hunger, min, max);
        hunger += 10;
        gameData.currentHunger = hunger;
        SaveGameData();
    }//A method that gives koralj food
    public void ThirstMechanic()//A method that gives koralj water
    {
        thirst = Mathf.Clamp(thirst, min, max);
        thirst += 10;
        gameData.currentThirst = thirst;
        SaveGameData();
    }
    public void WalkingMechanic()//A method that increases koraljs walking needs lmao
    {

        output = "";
        timer = 2;
        if (hunger > 20 && thirst > 20 && energy > 20)
        {
            walking = Math.Clamp(walking, 0, 100);
            walking += 30;
            energy -= 10;
            thirst -= 5;
            hunger -= 10;
           
        }
        else //Write an output depending on its hunger/thirst/energy state
        {
            if (hunger < 50)
            {
                output += "Im too hungry to go for a walk!\n";
            }
            if (thirst < 50)
            {
                output += "Im too thirsty to go for a walk!\n";
            }
            if (energy < 50)
            {
                output += "Im too tired to go for a walk!\n";
            }
            Debug.Log(output);
            ui.statusText.text = output;
        }

    }
    public void PlayMechanic()
    {

        if (hunger > 20 && thirst > 20 && energy > 20)
        {
            boredness = Mathf.Clamp(boredness, min, max);
            boredness += 10;
            energy -= 20;
            gameData.currentEnergy = energy;
            sceneManager.LoadScene("Game Medium"); 
        }
        else//Write an output depending on its hunger/thirst/energy state
        {
            output = "";
            timer = 2;

            //(float hunger, float thirst, float energy) stats = (hunger, this.thirst, this.energy);

            //switch (stats)
            //{
            //    case var tuple when tuple.hunger < 50:output+=" Im hungry!";break;
            //    case var tuple when tuple.thirst < 50:output+=" Give me water!"; break;
            //    case var tuple when tuple.energy < 50:output+=" Im sleepy"; break;
            //    default:Debug.Log("Tuple output");break;

            //}
            //Debug.Log(output);

            //string output = "";
            if (hunger < 50)
            {
                output += " Im too hungry to play! \n";
            }
            if (thirst < 50)
            {
                output += " Im too thirsty to play! \n";
            }
            if (energy < 50)
            {
                output += " Im too tired to play... \n";
            }
            Debug.Log(output);

            ui.statusText.text = output;
        }
        SaveGameData();
    }
    public void EnergyMechanic()
    {
        energy = Mathf.Clamp(energy, min, max);
        energy += 10;
        gameData.currentEnergy = energy;
        SaveGameData();
    }

    #endregion
    public void SaveDateOnQuit()
    {
        PlayerPrefs.SetString("lastDateString", DateTime.Now.ToBinary().ToString());
        PlayerPrefs.Save();
    }//On quit or button, save date and time to be used on next application startup
    public void SaveGameData()
    {
        SaveSystem.Save(gameData);
    }//Saves game data, like Coral mechanics status, date and time etc...
    public void FirstLoadSet(bool state)
    {
        gameData.firstLoad = state;
        SaveSystem.Save(gameData);
    }//Was the app loaded for the first time
    void LoadData()
    {      
        hunger = gameData.currentHunger;
        thirst = gameData.currentThirst;
        energy = gameData.currentEnergy;
    }//Loads game data that is used for Coral mechanics 
    void ClearText()
    {

        if (ui.statusText.text != string.Empty)
        {
            timer -= 1;
            if (timer <= 0)
            {
                ui.statusText.text = "";
                timer = 2;
            }
        }
    }//A method that clears a pop-up's text after a given time 
    void SaveWhileInBackground()
    {
        gameData.currentHunger = hunger;
        gameData.currentThirst = thirst;
        gameData.currentEnergy = energy;
        SaveGameData();
    }
    public void QuitApp()
    {
        Application.Quit();
    }
    void LoadDateAndTime()//Load date saved in the playerprefs, get current date and then compare them by substracting current date with last saved date
    {
        long lastDate = Convert.ToInt64(PlayerPrefs.GetString("lastDateString"));
        DateTime oldDate = DateTime.FromBinary(lastDate);
        Debug.Log(oldDate);
        Debug.Log(secondsPassedSinceLastQuit);

        currentDate = DateTime.Now;
        TimeSpan difference = currentDate.Subtract(oldDate);
        Debug.Log("Seconds since last quit: " + difference);
        secondsPassedSinceLastQuit = (float) difference.TotalSeconds;
        Debug.Log(secondsPassedSinceLastQuit);//Use this for the mechanic system(change values based on the formula that goes like this... Current date - LastDate the app was closed)
        testingTextForTime.text = "Last date and time: " + oldDate + "\n" + "Current date and time: " + currentDate + "\n" + "Difference" + difference;
    }
    void BackgroundValuesChange()
    {
        var subtractThis = secondsPassedSinceLastQuit / 60 * .005f;
        hunger -= subtractThis;
        thirst -= subtractThis;
        energy -= subtractThis;

        thirst = Math.Clamp(thirst, 0, 100);
        energy = Math.Clamp(energy, 0, 100);
        hunger = Math.Clamp(hunger, 0, 100);

        gameData.currentHunger = hunger;
        gameData.currentEnergy = energy;
        gameData.currentThirst = thirst;
        SaveGameData();
    }
    //void SetToZero(float value)
    //{
    //    value = 0;
    //}
   
}