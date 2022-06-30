using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube { get; private set;}
    public static MovingCube LastCube { get; private set;}
    public MoveDirection MoveDirection { get; internal set;}

    [SerializeField]
    private float moveSpeed = 1f;
    
    int x;

    void Awake()
    {
        if(LastCube == null)
            LastCube = GameObject.Find("Start").GetComponent<MovingCube>(); 
        CurrentCube = this;

        transform.localScale = new Vector3(LastCube.transform.localScale.x, transform.localScale.y, LastCube.transform.localScale.z);
    }

    void Start()
    {
        x = 0;    
    }

    void Update()
    {
        if(MoveDirection == MoveDirection.X)
        {
            if(transform.position.x > 1.49)
            {
                x = -1;
            }
            if(transform.position.x < -1.49)   
            {
                x = 1;
            }
            transform.Translate( x * transform.right * Time.deltaTime * moveSpeed , Space.World );
        }
        else
        {
            if(transform.position.z > 1.49)
            {
                x = -1;
            }
            if(transform.position.z < -1.49)   
            {
                x = 1;
            }
            transform.Translate( x * transform.forward * Time.deltaTime * moveSpeed , Space.World );
        }
    }

    private Color GetColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    internal void Stop()
    {
        moveSpeed = 0;
        float hangover = GetHangover();
        float direction = hangover > 0 ? 1f : -1f;
        
        float max = MoveDirection == MoveDirection.X ? LastCube.transform.localScale.x : LastCube.transform.localScale.z;
        if(Mathf.Abs(hangover) >= max)
        {
            LastCube = null;
            CurrentCube = null;
            SceneManager.LoadScene(0);
        }

        SplitCube(hangover, direction);

        LastCube = this;
    }

    private float GetHangover()
    {
        if(MoveDirection == MoveDirection.X)
        {
            return transform.position.x - LastCube.transform.position.x;
        }

        else
        {
            return transform.position.z - LastCube.transform.position.z;
        }
    }

    void SplitCube(float hangover, float direction)
    {
        if(MoveDirection == MoveDirection.X)
        {
            float newXScale = LastCube.transform.localScale.x - Mathf.Abs(hangover);
            float fallingCubeScale = transform.localScale.x - newXScale;
            float newXPosition = LastCube.transform.position.x + (hangover / 2);

            transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

            float cubeEdge = transform.position.x + ((newXScale / 2f) * direction);
            float fallingCubePosition = cubeEdge + ((fallingCubeScale / 2f) * direction);

            SpawnFallingCube(fallingCubePosition, fallingCubeScale);
        }
        else
        {
            float newZScale = LastCube.transform.localScale.z - Mathf.Abs(hangover);
            float fallingCubeScale = transform.localScale.z - newZScale;
            float newZPosition = LastCube.transform.position.z + (hangover / 2);

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZScale);
            transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

            float cubeEdge = transform.position.z + ((newZScale / 2f) * direction);
            float fallingCubePosition = cubeEdge + ((fallingCubeScale / 2f) * direction);

            SpawnFallingCube(fallingCubePosition, fallingCubeScale);
        }
    }

    void SpawnFallingCube(float fallingCubePosition, float fallingCubeScale)
    {
        var fallingCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fallingCube.AddComponent<Rigidbody>();
        fallingCube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;

        if(MoveDirection == MoveDirection.X)
        {
            fallingCube.transform.localScale = new Vector3(fallingCubeScale, transform.localScale.y, transform.localScale.z);
            fallingCube.transform.position = new Vector3(fallingCubePosition, transform.position.y, transform.position.z); 
        }
        else
        {
            fallingCube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingCubeScale);
            fallingCube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingCubePosition); 
        }

        Destroy(fallingCube.gameObject, 1f);
    }
}
