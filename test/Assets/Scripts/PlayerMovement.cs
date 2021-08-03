using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeed = 180f;

    float shipBoundaryRadius = 0.5f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //ROTATE the ship.

        //Grbab our rotation quaternion
        Quaternion rot = transform.rotation;

        //Grab the  euler angle
        float z = rot.eulerAngles.z;

        //Change the Z angle based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        //Recreate the quaternion
        rot = Quaternion.Euler(0, 0, z);

        //feed thequaternion into our rotation
        transform.rotation = rot;

        // MOVE the ship.
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        //RESTICT the player to the camera boundaries!

        //first do vertical, because it's simpler
        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }
        //now calculate the orthographic  width based on the screenratio
        float screenRatio = (float)Screen.width / (float)Screen.height;  //Warning! will be weird!
        float width0rtho = Camera.main.orthographicSize * screenRatio;
        //now do horizontal bounds
        if (pos.x + shipBoundaryRadius > width0rtho)
        {
            pos.x = width0rtho - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < -width0rtho)
        {
            pos.x = -width0rtho + shipBoundaryRadius;
        }
        transform.position = pos;
    }
}
