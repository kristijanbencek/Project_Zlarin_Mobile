using System;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] string output = "";
    [SerializeField] float max = 100;
    [SerializeField] float timer = 2;
    [SerializeField] float min = 0;
    [SerializeField] UI_Manager ui;

    //Save system
    public GameData gameData;
    public Text saveDataTest;
    public int test;

    [TextArea]
    public string myTextArea;
    //Hrana
    public float hunger; //Eat
    //Voda
    public float thirst = 100; //Drink
    //�etnja
    public float walking = 100; //Play
    //Igra
    public float boredness = 100; //Walk
    //Spavanje
    public float energy = 100; //Sleep

    private DateTime currentDate;
    private DateTime lastDateOnAppQuit;
    private TimeSpan difference;

    private void Awake()
    {
        gameData = SaveSystem.Load();
        LoadData();
        
        long lastDateFetch = Convert.ToInt64(PlayerPrefs.GetFloat("lastDate"));
        lastDateOnAppQuit = DateTime.FromBinary(lastDateFetch);
        currentDate = DateTime.Now.ToLocalTime();

        difference = currentDate.Subtract(lastDateOnAppQuit);
        Debug.Log(difference);
        Debug.Log(difference.TotalSeconds);
    }
    void Start()
    {
        InvokeRepeating("UpdateMethod", 0, 1);
    }

    void UpdateMethod()
    {
        
        ClearText();
        LooseAll();
    }
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
        SaveMe();
    }//A method that gives koralj food
    public void ThirstMechanic()//A method that gives koralj water
    {
        thirst = Mathf.Clamp(thirst, min, max);
        thirst += 10;
        gameData.currentThirst = thirst;
        SaveMe();
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
    public void BorednessMechanic()
    {

        if (hunger > 20 && thirst > 20 && energy > 20)
        {
            boredness = Mathf.Clamp(boredness, min, max);
            boredness += 10;
            energy -= 5;
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
        SaveMe();
    }
    public void EnergyMechanic()
    {
        energy = Mathf.Clamp(energy, min, max);
        energy += 10;
        gameData.currentEnergy = energy;
        SaveMe();
    }

    #endregion
    public void SaveDateOnQuit()
    {

        float currentTime = DateTime.Now.ToLocalTime().Ticks;
        PlayerPrefs.SetFloat("lastDate", currentTime);
        PlayerPrefs.Save();
    }
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
    }
    public void SaveMe()
    {
        SaveSystem.Save(gameData);
    }
    void LoadData()
    {
        hunger = gameData.currentHunger;
        thirst = gameData.currentThirst;
        energy = gameData.currentEnergy;
    }
    void SaveWhileInBackground()
    {
        gameData.currentHunger = hunger;
        gameData.currentThirst = thirst;
        gameData.currentEnergy = energy;
        SaveMe();
    }

}
