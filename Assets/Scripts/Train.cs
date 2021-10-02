using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public new Camera camera; // Reference the camera, so it can be controlled

    public float cameraSpeed; // The speed at which the camera moves
    public float cameraZoomSpeed; // The speed at which the camera zooms out

    public GameObject locomotive; // The Prefab for the locomotive

    public GameObject hiddenCar; // The Prefab for cars whose contents have not been revealed;

    public List<GameObject> carTypes; // Prefabs for revealed cars

    private List<GameObject> cars; // All of the cars which form the train

    // Start is called before the first frame update
    void Start()
    {
        cars = new List<GameObject>();

        cars.Add(Instantiate(locomotive, transform));
        AddHiddenCar();
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.orthographicSize < 25)
        {
            if (camera.transform.position.z > ((cars.Count - 1) * -15.75f))
            {
                camera.transform.position -= new Vector3(0, 0, (cameraSpeed * Time.deltaTime));
            }
            if (camera.orthographicSize < (11 + (cars.Count * 2)))
            {
                camera.orthographicSize += cameraZoomSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (camera.transform.position.z > ((cars.Count - 1) * -21f))
            {
                camera.transform.position -= new Vector3(0, 0, (cameraSpeed * Time.deltaTime));
            }
        }

        // DEBUGING! :D
        if (Time.time > 2 && cars.Count == 2)
        {
            RevealCar();
        }
        if (Time.time > 4 && cars.Count == 3)
        {
            RevealCar();
        }
        if (Time.time > 6 && cars.Count == 4)
        {
            RevealCar();
        }
        if (Time.time > 8 && cars.Count == 5)
        {
            RevealCar();
        }
        if (Time.time > 10 && cars.Count == 6)
        {
            RevealCar();
        }
        if (Time.time > 12 && cars.Count == 7)
        {
            RevealCar();
        }
        if (Time.time > 14 && cars.Count == 8)
        {
            RevealCar();
        }
    }

    private void AddHiddenCar()
    {
        cars.Add(Instantiate(hiddenCar, transform));
        cars[cars.Count - 1].transform.position = new Vector3(0, 0, ((cars.Count - 1) * -21));
    }

    private void RevealCar()
    {
        Destroy(cars[cars.Count - 1]);
        cars[cars.Count - 1] = Instantiate(carTypes[0], transform);
        cars[cars.Count - 1].transform.position = new Vector3(0, 0, ((cars.Count - 1) * -21));
        AddHiddenCar();
        //ExpandView();
    }

    private void ExpandView()
    {
        //camera.transform.position -= new Vector3(0, 0, 15.75f);

        if(camera.orthographicSize < 25) // Eventually we want to stop zooming out and just move
        {
            camera.orthographicSize += 2;
        }
        
    }
}
