using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private MovingCube cubePrefab;
    [SerializeField]
    private MoveDirection moveDirection;

    private float smoothFactor = 200;
    private int color = 0;

    public void SpawnCube() 
    {
        var cube = Instantiate(cubePrefab);
        
        cube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((color/100f) % 1f, 1f, 1f));
        color = color + 5;

        float x = moveDirection == MoveDirection.X ? transform.position.x : MovingCube.LastCube.transform.position.x;
        float z = moveDirection == MoveDirection.Z ? transform.position.z : MovingCube.LastCube.transform.position.z;
        if(MovingCube.LastCube != null && MovingCube.LastCube.gameObject != GameObject.Find("Start"))
        { 
            cube.transform.position = new Vector3(
                x, 
                MovingCube.LastCube.transform.position.y + cubePrefab.transform.localScale.y,
                z
            );
        }
        else
        {
            cube.transform.position = transform.position;
        }
        
        cube.MoveDirection = moveDirection;
           
        Vector3 newPos = new Vector3(
            Camera.main.transform.position.x, 
            Camera.main.transform.position.y + cubePrefab.transform.localScale.y,
            Camera.main.transform.position.z
        );

        Camera.main.transform.position = Vector3.Lerp(
            Camera.main.transform.position,
            newPos,
            Time.deltaTime * smoothFactor
        );
    }   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, cubePrefab.transform.localScale);
    }
}

public enum MoveDirection
{
    X,
    Z
}
