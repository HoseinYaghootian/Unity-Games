using UnityEngine;

public class FollowThePath : MonoBehaviour {

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;
    private int waypointIndex = 0;
    
	// Use this for initialization
	private void Start () {

        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[0].transform.position;
        Debug.Log(waypoints.Length);
	}
	
	// Update is called once per frame
	private void Update () {

        // Move Enemy
        Move();
	}

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            
            transform.position = Vector3.MoveTowards(
               transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[0].transform.position)
            {
                waypointIndex = 1;
            }

            else if (transform.position == waypoints[1].transform.position)
            {
                waypointIndex = 0;
            }
      
    }
}