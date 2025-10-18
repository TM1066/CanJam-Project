using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementIncrement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementIncrement *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementIncrement /= 2;
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0, movementIncrement);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0, -movementIncrement);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-movementIncrement, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(movementIncrement, 0);
        }

        //Camera.main.transform.position = this.transform.position;
    }
}
