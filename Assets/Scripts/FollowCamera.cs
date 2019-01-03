using UnityEngine;

/// <summary>
/// Follow Camera scripts allows camera to follow the motion of player without jittering
/// </summary>
public class FollowCamera : MonoBehaviour
{
    //player Object
    public Transform PlayerToFollow;

    //smooth speed for fast or slow catchup
    [Range(0,1)]
    public float smoothSpeed;

    //rotation around y axis
    float pitch;

    //Provide a certain distance away from player
    public Vector3 offset;


    //Rotation Input
    void Update()
    {
        pitch = 2f * Input.GetAxis("Mouse X");

        transform.eulerAngles += new Vector3(0, pitch, 0);
    }

    //To avoid ambiguity between update functions. 
    void LateUpdate()               
    {
        Vector3 desiredPos= PlayerToFollow.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position,desiredPos,smoothSpeed*Time.deltaTime);      //Smoothly lerps between position
        transform.position = smoothedPos;
    }
}