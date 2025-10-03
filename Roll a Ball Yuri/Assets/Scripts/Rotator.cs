using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(Random.Range(10, 45), Random.Range(25, 60), Random.Range(40, 75))* Time.deltaTime);
        //transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
