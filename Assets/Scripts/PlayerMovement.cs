using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementIncrement;
    private Vector3 tempLocation = new Vector3();

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.PlayerCanMove)
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
        }
    }

    void LateUpdate()
    {
        if (this.transform.position.x > tempLocation.x)
        {
            this.transform.rotation = new Quaternion(0, 0, 0, this.transform.rotation.w);
        }
        else
        {
            this.transform.rotation = new Quaternion(0,-180,0,this.transform.rotation.w);
        }
        tempLocation = this.transform.position;
    }
}
