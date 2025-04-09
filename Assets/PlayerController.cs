using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Vector3 CameraOffset = new Vector3(0, 0, 0);
    public Camera myCamera;

    Animator animatorController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (myCamera != null)
        {
            myCamera.transform.position = transform.position + CameraOffset;
            myCamera.transform.rotation = Quaternion.Euler(75, 0, 0); // Top-down
        }

        animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        //transform.position +=
        //        new Vector3(0, 0, 0.1f*deltaTime);

        //transform.localPosition = new Vector3(0, 0, 0.1f * deltaTime);

        //W, A, S, D
        transform.localPosition += new Vector3(0, 0, Input.GetAxis("Vertical") * deltaTime);
        transform.localPosition += new Vector3(Input.GetAxis("Horizontal") * deltaTime, 0, 0);

        //Salto
        var pos = transform.position;
        pos.y += Input.GetButton("Jump") ? 1 * deltaTime : 0;
        transform.position = pos;

        if(myCamera != null)
        {
            myCamera.transform.position = transform.position + CameraOffset;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(movement != Vector3.zero)
        {
            //transform.forward = movement.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = 
                Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

            animatorController.SetBool("moving", true);
        }
        else
        {
            animatorController.SetBool("moving", false);
        }

    }
}
