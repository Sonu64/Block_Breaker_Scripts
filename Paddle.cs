using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // configuration parameters
    [SerializeField] float screenWidthInUnits;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        //Debug.Log(mousePosInUnits);

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX); 
        // if we go outside of limit, the value is not returned, mousePosInUnits still increases
        // but paddlePos.x stays as it was before.
     
        transform.position = paddlePos;
    }
}
