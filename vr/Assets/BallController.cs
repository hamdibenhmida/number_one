using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 startPos;
    public Vector3 endPos;
    private bool hasTransformed = false;
    public GameObject goal;
    public AudioSource goaaal;

    void Start()
    {
        // Set the starting position to a random position within the specified range
        startPos = new Vector3(25.89f, 0.185f, 11.16f);

        // Set the ending position to a random position within the specified range
        endPos = new Vector3(Random.Range(10.3f, 11.145f), Random.Range(00.65f, 2f), Random.Range(9f, 13.3f));

        // Set the initial position of the ball to the starting position
        transform.position = startPos;
    }

    void Update()
    {
        // If the ball has not yet transformed and is close to the end position, transform it
        if (!hasTransformed  )
        {
            if (Vector3.Distance(transform.position, endPos) <= 0.1f)
            {
                hasTransformed = true;

                // Set the ball as a child of the end position

                transform.position = endPos;
            }// Otherwise, move the ball towards the end position
            else
            {
                float distance = Vector3.Distance(startPos, endPos);
                float duration = distance / speed;
                float t = Mathf.PingPong(Time.time, duration) / duration;
                transform.position = Vector3.Lerp(startPos, endPos, t);
            }
        }
        
        
       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chebka"))
        {
            Debug.Log("goaaaallll");
            goal.SetActive(true);
            goaaal.Play();
            
        }
    }
}
