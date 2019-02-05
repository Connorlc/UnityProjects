using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float vegieRate = .1f;
    public float obstacleRate = .2f;

    public GameObject dirt;
    public GameObject[] walls;
    public GameObject[] vegetation;
    public GameObject[] obstacles;

    private void BuildWalls()
    {
        //place 4 corners
        Instantiate(walls[5], new Vector3(0, 0, 0), Quaternion.identity, this.transform); //bottom left
        Instantiate(walls[7], new Vector3(99, 0, 0), Quaternion.identity, this.transform); //bottom right
        Instantiate(walls[2], new Vector3(99, 99, 0), Quaternion.identity, this.transform); //top right
        Instantiate(walls[0], new Vector3(0, 99, 0), Quaternion.identity, this.transform); //top left
        
        //build bottom row left to right
        for(int i = 1; i < 99; i++) {
            Instantiate(walls[6], new Vector3(i, 0, 0), Quaternion.identity, this.transform);
        }

        //build right column bottom to top
        for (int i = 1; i < 99; i++) {
            Instantiate(walls[4], new Vector3(99, i, 0), Quaternion.identity, this.transform);
        }

        //build top row right to left
        for (int i = 98; i > 0; i--) {
            Instantiate(walls[1], new Vector3(i, 99, 0), Quaternion.identity, this.transform);
        }

        //build left column top to bottom
        for (int i = 98; i > 0; i--) {
            Instantiate(walls[3], new Vector3(0, i, 0), Quaternion.identity, this.transform);
        }
    }

    private void FillBoard()
    {
        //iterate through inner board 2x2 spaves at a time
        for(int j = 1; j < 99; j += 2) {
            for(int i = 1; i < 99; i += 2) {
                if(Random.Range(0, 1.99f) <= obstacleRate) { //randomly determine if obstacle or if plain dirt
                    //randomly pick an obstacle from the array
                    Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(i, j, 0), Quaternion.identity, this.transform);
                } else {
                    Instantiate(dirt, new Vector3(i, j, 0), Quaternion.identity, this.transform);
                    Instantiate(dirt, new Vector3(i + 1, j, 0), Quaternion.identity, this.transform);
                    Instantiate(dirt, new Vector3(i, j + 1, 0), Quaternion.identity, this.transform);
                    Instantiate(dirt, new Vector3(i + 1, j + 1, 0), Quaternion.identity, this.transform);

                    PlaceVegetation(i, j);
                }
            }
        }
    }

    private void PlaceVegetation(int x, int y)
    {
        //add vegetaion randomly on top of dirt
        if (Random.Range(0, 1.99f) <= vegieRate)
        { //bottom left dirt
            Instantiate(vegetation[Random.Range(0, vegetation.Length)], new Vector3(x, y, 0), Quaternion.identity, this.transform);
        }

        if (Random.Range(0, 1.99f) <= vegieRate)
        { //bottom right dirt
            Instantiate(vegetation[Random.Range(0, vegetation.Length)], new Vector3(x + 1, y, 0), Quaternion.identity, this.transform);
        }

        if (Random.Range(0, 1.99f) <= vegieRate)
        { //top left dirt
            Instantiate(vegetation[Random.Range(0, vegetation.Length)], new Vector3(x, y + 1, 0), Quaternion.identity, this.transform);
        }

        if (Random.Range(0, 1.99f) <= vegieRate)
        { //top right dirt
            Instantiate(vegetation[Random.Range(0, vegetation.Length)], new Vector3(x + 1, y + 1, 0), Quaternion.identity, this.transform);
        }
    }

    void Start()
    {
        //randomly generates map every time the game is run
        BuildWalls();
        FillBoard();
    }
    
    void Update()
    {
        
    }
}
