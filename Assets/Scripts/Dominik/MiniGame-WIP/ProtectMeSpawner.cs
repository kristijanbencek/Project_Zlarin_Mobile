using UnityEngine;

public class ProtectMeSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawners;
    [SerializeField] GameObject prefab;
    [SerializeField] float Timer;
    [SerializeField] float startTimer;
    private void Start()
    {
        InvokeRepeating("UpdateMethod", 1, 1);
    }
    void UpdateMethod()
    {
        
        if (ingame == true)
        {
            int randomSpawn = Random.Range(0, spawners.Length);
            Timer -= 1;
            if (Timer <= 0)
            {
                Instantiate(prefab, spawners[randomSpawn].transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("ProtectMeGame").transform);
               
                Timer = startTimer;
            }
        }
    }
    public bool ingame
    {
        get; set;
    }

}
