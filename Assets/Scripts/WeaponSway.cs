using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float bobbingSpeed = 0.18f;          
    public float bobbingAmount = 0.05f;         
    public float horizontalBobbingAmount = 0.02f; 
    public Vector3 midpoint;                   

    private float timer = 0.0f;
    private Vector3 originalPosition;
    private float verticalRandomOffset;
    private float horizontalRandomOffset;
    [SerializeField] private float swaysmooth;
    [SerializeField] private float swayammount;

    void Start()
    {
        originalPosition = transform.localPosition;
        midpoint = originalPosition;

        verticalRandomOffset = Random.Range(0f, Mathf.PI * 2);
        horizontalRandomOffset = Random.Range(0f, Mathf.PI * 2);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float swayX = Input.GetAxisRaw("Mouse X") * swayammount;
        float swayY = Input.GetAxisRaw("Mouse Y") * swayammount;

        Quaternion swayrotationX = Quaternion.AngleAxis(-swayY, Vector3.right);
        Quaternion swayrotationY = Quaternion.AngleAxis(swayX, Vector3.up);

        Quaternion targetrotation = swayrotationX * swayrotationY;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetrotation, swaysmooth * Time.deltaTime);


        if (Mathf.Abs(horizontal) < 0.01f && Mathf.Abs(vertical) < 0.01f)
        {
            timer = 0.0f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, midpoint, Time.deltaTime * 5);
            return;
        }

        timer += bobbingSpeed * Time.deltaTime;

        if (timer > Mathf.PI * 2)
        {
            timer -= Mathf.PI * 2;
        }

        float waveSlice = Mathf.Sin(timer + verticalRandomOffset);
        float verticalOffset = waveSlice * bobbingAmount * Random.Range(0.9f, 1.1f); // Add small random factor
        float horizontalOffset = Mathf.Cos(timer + horizontalRandomOffset) * horizontalBobbingAmount * Random.Range(0.9f, 1.1f); 

        float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        totalAxes = Mathf.Clamp01(totalAxes);

        Vector3 newPosition = new Vector3(midpoint.x + (horizontalOffset * totalAxes), midpoint.y + (verticalOffset * totalAxes), midpoint.z);

        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, Time.deltaTime * 5);
    }
}
