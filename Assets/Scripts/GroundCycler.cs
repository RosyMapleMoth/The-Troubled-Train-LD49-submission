using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCycler : MonoBehaviour
{
    /* 
     * A list that will contain all the prefabs for terrain tiles
     * 
     * 1) Placeholder Desert Tile
     */
    public List<GameObject> terrainTilePrefabs = new List<GameObject>();

    // The speed at which the terrain tiles cycle
    public float speed = 75;

    private GameObject prevTile;
    private GameObject currTile;
    private GameObject nextTile;

    private void Start()
    {
        // Initialize all three tiles with the first prefab in the list
        prevTile = GameObject.Instantiate(terrainTilePrefabs[0], new Vector3(0, 0, -500), Quaternion.Euler(0, 0, 0), transform); // Previous tile behind
        currTile = GameObject.Instantiate(terrainTilePrefabs[0], transform); // Current tile at 0
        nextTile = GameObject.Instantiate(terrainTilePrefabs[0], new Vector3(0, 0, 500), Quaternion.Euler(0, 0, 0), transform); // Next tile ahead
    }

    private void Update()
    {
        // Move each tile back
        prevTile.transform.position -= new Vector3(0, 0, (speed * Time.deltaTime));
        currTile.transform.position -= new Vector3(0, 0, (speed * Time.deltaTime));
        nextTile.transform.position -= new Vector3(0, 0, (speed * Time.deltaTime));

        // Check if the previous tile has crossed the threshold
        if(prevTile.transform.position.z <= -1000)
        {
            // Delete the previous tile
            Destroy(prevTile);

            // Cycle the current and next
            prevTile = currTile;
            currTile = nextTile;

            // Generate the new next
            nextTile = GameObject.Instantiate(terrainTilePrefabs[0], currTile.transform.position + new Vector3(0, 0, 500), Quaternion.Euler(0, 0, 0), transform);
        }

        if (speed <= 0)
        {
            GameUI.Instance.GameOver();
        }
    }
}
