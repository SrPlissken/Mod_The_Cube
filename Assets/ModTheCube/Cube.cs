using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    // Initial cube speed
    private float cubeSpeed = 10f;
    private int selectedAxis = 0; 
    // Limit cube position bounds
    private float cubePositionRangeX = 10f;
    private float cubePositionRangeY = 5f;
    private float cubePositionRangeZ = 10f;
    // Set maximun scale factor
    private float scaleFactorLimit = 10f;

    // Set timer variables
    private float actionTimer;
    private float actionTimerLimit = 3f;
    private int selectedAction;

    // Store cube modes
    private string[] cubeModes;
    
    void Start()
    {
        // Add cube mood modes
        cubeModes = new string[] 
        {
            "ChangeCubeRotationSpeed",
            "ChangeCubeRotationAxis",
            "ChangeCubeLocation",
            "ChangeCubeScale",
            "ChangeCubeMaterialColor",
            "ChangeCubeMaterialOpacity"
        };
        
    }
    
    void Update()
    {
        // Start timer
        actionTimer += Time.deltaTime;
        // Check if timer reach limit, then change action
        if(actionTimer > actionTimerLimit)
        {
            actionTimer = 0;
            // Set new action and execute it
            selectedAction = Random.Range(0,cubeModes.Length);
            InvokeRepeating(cubeModes[selectedAction],0.0f,0.0f);
        }
        // Rotate cube
        RotateCubeOnAxis(selectedAxis);
    }

    // Rotate cube on selected axis
    private void RotateCubeOnAxis(int selectedAxis)
    {
        if(selectedAxis == 0)
            transform.Rotate(cubeSpeed * Time.deltaTime, 0.0f, 0.0f);
        else if(selectedAxis == 1)
            transform.Rotate(0.0f, cubeSpeed * Time.deltaTime, 0.0f);
        else if(selectedAxis == 2)
            transform.Rotate(0.0f, 0.0f, cubeSpeed * Time.deltaTime);
    }

    // Randomly change cube Axis rotation
    private void ChangeCubeRotationAxis()
    {
        selectedAxis = Random.Range(0,3);
    }

    // Randomly change the rotation speed of the cube
    private void ChangeCubeRotationSpeed()
    {
        cubeSpeed = Random.Range(1f,20f);
    }  

    // Randomly change the position of the cube on all axis
    private void ChangeCubeLocation()
    {
        transform.position = new Vector3(Random.Range(-cubePositionRangeX, cubePositionRangeX),
                                            Random.Range(-cubePositionRangeY, cubePositionRangeY),
                                            Random.Range(-cubePositionRangeZ, cubePositionRangeZ));
    }

    // Randomly change the scale of the cube
    private void ChangeCubeScale()
    {
        float scaleFactor = Random.Range(0, scaleFactorLimit);
        transform.localScale = Vector3.one * scaleFactor;
    }

    // Randomly change the color of the cube
    private void ChangeCubeMaterialColor()
    {
        Material material = Renderer.material;
        Color newCubeColor = new Color(Random.Range(0.0f,1f),
                                            Random.Range(0.0f,1f),
                                            Random.Range(0.0f,1f), 
                                            material.color.a);
        
        material.color = newCubeColor;
    }

    // Randomly change the opacity of the cube
    private void ChangeCubeMaterialOpacity()
    {
        Material material = Renderer.material;
        Color newCubeOpacity = new Color(material.color.r,
                                            material.color.g,
                                            material.color.b, 
                                            Random.Range(0.0f, 1f));
        material.color = newCubeOpacity;
    }
}
