using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToScreen : JSONLanguag
{
    public void Touch(ref Cube currentCube)
    {
        if(Input.touchCount > 0 && currentCube != null)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                currentCube.Speed = touch.deltaPosition.x/70;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                currentCube.GetComponent<Rigidbody>().AddForce(0, 0, 1000f, ForceMode.Acceleration);
                currentCube = null;
            }
        }
    }
}
