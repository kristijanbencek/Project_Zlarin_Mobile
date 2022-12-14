using UnityEngine;

public class DestroyPlayerMech : MonoBehaviour
{
    [SerializeField] float stopDistance;
    [SerializeField] float timeToKill;
    public Vector2 playerObject;
    public Rigidbody2D thisRb;
    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("ProtectPlayer").transform.position;
        thisRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

       
        //thisRb.position = Vector2.MoveTowards(transform.position, playerObject, stopDistance)*Time.deltaTime * timeToKill;
        thisRb.position = Vector2.Lerp(transform.position, playerObject, timeToKill * Time.time);
    }
    private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }


}
