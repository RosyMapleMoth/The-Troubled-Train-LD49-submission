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

    private bool cameraSnapping = false; // Used to determine if the car is snapping 
    private float cameraSnapTime = 0f; // Used to track when the camera started snapping
    private Vector3 cameraSnapStart = new Vector3(); // The location the camera snapped from
    private Vector3 cameraSnapStop = new Vector3(); // The location the camera is snapping to

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
        if(!cameraSnapping) // Only allow the player to move the camera if the game isn't controlling it
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (camera.transform.position.z < -15.75f)
                {
                    camera.transform.position += new Vector3(0, 0, (cameraSpeed * Time.deltaTime));
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (camera.transform.position.z > (-15.75f - (21 * cars.Count)))
                {
                    camera.transform.position -= new Vector3(0, 0, (cameraSpeed * Time.deltaTime));
                }
            }
        }
        else
        {
            camera.transform.position = Vector3.Lerp(cameraSnapStart, cameraSnapStop, (Time.time - cameraSnapTime));

            if (Time.time > cameraSnapTime + 1)
            {
                cameraSnapping = false;
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
        MoveCameraToCar(cars.Count - 2);
    }

    private void RevealCar(int index)
    {
        Destroy(cars[cars.Count - 1]);
        cars[cars.Count - 1] = Instantiate(carTypes[index], transform);
        cars[cars.Count - 1].transform.position = new Vector3(0, 0, ((cars.Count - 1) * -21));
        AddHiddenCar();
    }

    private void MoveCameraToCar(int index)
    {
        cameraSnapping = true;
        cameraSnapStart = camera.transform.position;
        cameraSnapStop = new Vector3(camera.transform.position.x, camera.transform.position.y, (-15.75f - (21 * index)));
        cameraSnapTime = Time.time;
    }
}
