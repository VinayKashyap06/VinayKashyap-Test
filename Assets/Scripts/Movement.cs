using UnityEngine;

/// <summary>
/// Movement of player
/// </summary>
public class Movement : MonoBehaviour
{
    float speed;
    float moveHorizontal;
    float moveVertical;
    float pitch;

    void Start()
    {
        speed = 7f;
    }  

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
       
        transform.Translate(moveHorizontal,0,moveVertical);

        pitch = 2f * Input.GetAxis("Mouse X");

        transform.eulerAngles += new Vector3(0, pitch, 0);
    }
}