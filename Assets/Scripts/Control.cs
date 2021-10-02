using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Control : MonoBehaviour
{
    public int ySize;
    public int xSize;

    public GameObject ControlBody;

    public bool[,] oddShapeCheck; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool isOddShape()
    {
        return false;
    }

}
