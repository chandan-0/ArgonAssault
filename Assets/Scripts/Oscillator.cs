using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 movementVector=new Vector3(10f,10f,10f);
    [SerializeField] float period = 2f;

    [Range(0,1)] [SerializeField] float movementFactor; // zero for not moved and 1 for fully moved
    Vector3 startingPos;
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period == 0f) { return; }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float RawSinWave = Mathf.Sin(cycles * tau);
        print("Raw Sin Wave -> "+RawSinWave);
        movementFactor = RawSinWave / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
