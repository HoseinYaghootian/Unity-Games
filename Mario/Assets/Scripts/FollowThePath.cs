using UnityEngine;

public class FollowThePath : MonoBehaviour {

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float speed = 1f;
    private int waypointIndex;
    private Rigidbody2D rb;
    int direction1D;
    Vector2 direction2D;
    Vector3 direction3D;

	// Use this for initialization
	private void Start () {
        Debug.Log(waypoints.Length);
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction1D = 0; 
        waypointIndex = 1;
	}

	private void Update () {
         Move();   
	}

    void FixedUpdate() {
         
    }

    // Method that actually make Enemy walk
    private void Move()
    {
        if (transform.position.x == waypoints[0].transform.position.x)
        {
            waypointIndex = 1;
            //direction1D = -1;         
        }

        else if (transform.position.x == waypoints[1].transform.position.x)
        {
           waypointIndex = 0;
           //direction1D = 1;
        }

        //direction2D = new Vector2(direction1D, 0);
        //direction3D = new Vector3(direction1D, 0, 0);

        //transform.position += direction3D * speed * Time.deltaTime;
        //transform.Translate(direction3D * speed * Time.deltaTime);   
        
        transform.position = Vector3.MoveTowards(
            transform.position,
            waypoints[waypointIndex].transform.position,
            speed * Time.deltaTime
        );
       

        //rb.position += direction2D * speed * Time.deltaTime;
        //rb.MovePosition(transform.position + direction3D  * speed * Time.deltaTime);
        //rb.velocity = new Vector2(speed * direction1D, 0);
    }
}