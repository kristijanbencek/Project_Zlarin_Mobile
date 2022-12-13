using UnityEngine;
using System;
using System.Collections;
public class GameManager : MonoBehaviour
{
    //Hrana
    public float hunger = 100; //Eat
    //Voda
    public float thirst = 100; //Drink
    //Šetnja
    public float walking = 100; //Play
    //Igra
    public float boredness = 100; //Walk
    //Spavanje
    public float tiredness = 100; //Sleep

    string output = "";
    //float max = 100;
    //float min = 0;

  
    private DateTime currentDate;
    private DateTime lastDateOnAppQuit;
    private TimeSpan difference;

  

  

    private void Awake()
    {
        long lastDateFetch = Convert.ToInt64(PlayerPrefs.GetFloat("lastDate"));        
        lastDateOnAppQuit = DateTime.FromBinary(lastDateFetch);
        currentDate = DateTime.Now;

        difference = currentDate.Subtract(lastDateOnAppQuit);
        Debug.Log(difference);
        Debug.Log(difference.TotalSeconds);
        

        //hunger = Mathf.Clamp(hunger, min, max);
        //thirst = Mathf.Clamp(thirst, min, max);
        //walking = Mathf.Clamp(walking, min, max);
        //boredness = Mathf.Clamp(boredness, min, max);
        //tiredness = Mathf.Clamp(tiredness, min, max);
    }
    void Start()
    {
        InvokeRepeating("UpdateMethod", 0, 1);
    }

    void UpdateMethod()
    {
        //Debug.Log("Test");
        //Debug.Log(hunger);
        LooseAll();
    }
    void LooseAll()
    {
        if(hunger > 0)
        hunger -= .1f;
        if(thirst >0)
        thirst -= .1f;
        if(walking >0)
        walking -= .1f;
        if(boredness > 0)
        boredness -= .1f;
        if(tiredness > 0)
        tiredness -= .1f;
       
    }
    #region Koralj mechanics
    public void HungerMechanic()
    {
        hunger += 10;
    }
    public void ThirstMechanic()
    {
        thirst += 10;
    }
    public void WalkingMechanic()
    {
        if (hunger > 50 && thirst > 50 && tiredness > 50)
        {
            walking += 10;
        }
        else //Write an output depending on its hunger/thirst/tiredness state
        {
            if (hunger < 50)
            {
                output+="Im too hungry to go for a walk!\n";
            }
            if (thirst < 50)
            {
                output += "Im too thirsty to go for a walk!\n";
            }
            if (tiredness < 50)
            {
                output += "Im too tired to go for a walk!\n";
            }
            Debug.Log(output);
            output = "";
        }
    }
    public void BorednessMechanic()
    {
        if (hunger > 50 && thirst > 50 && tiredness > 50)
        {
            boredness += 10;
        }
        else
        {
            
            //(float hunger, float thirst, float tiredness) stats = (hunger, this.thirst, this.tiredness);

            //switch (stats)
            //{
            //    case var tuple when tuple.hunger < 50:output+=" Im hungry!";break;
            //    case var tuple when tuple.thirst < 50:output+=" Give me water!"; break;
            //    case var tuple when tuple.tiredness < 50:output+=" Im sleepy"; break;
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
            if (tiredness < 50)
            {
                output += " Im too tired to play... \n";
            }
            Debug.Log(output);
            output = "";
        }
    }
    public void TirednessMechanic()
    {
        tiredness += 10;
    }
   
    #endregion
    public void SaveDateOnQuit()
    {
    
        float currentTime = DateTime.Now.Ticks;
        PlayerPrefs.SetFloat("lastDate", currentTime);
        PlayerPrefs.Save();
    }
}
