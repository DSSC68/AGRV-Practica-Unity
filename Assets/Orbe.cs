using UnityEngine;

public class Orbe : MonoBehaviour
{
    public float oscilationFrecuency;
    public float oscilationAmplitude;
    public float oscilationOffset = 1;

    public bool MustRotate;
    public float angularSpeed;

    public bool MustThrob;
    public float ThrobbingFrequency = 2;
    public float ThrobbingScale = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ypos = Mathf.Sin(Time.time * oscilationFrecuency) * oscilationAmplitude;
        transform.localPosition = 
            new Vector3(transform.localPosition.x, oscilationOffset + ypos, transform.localPosition.z);

        if(MustRotate)
        {
            transform.Rotate(Vector3.up, angularSpeed * Time.deltaTime);
        }

        if(MustThrob)
        {
            float scale = 1 + Mathf.Sin(ThrobbingFrequency * Time.time) * (ThrobbingScale-1);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
