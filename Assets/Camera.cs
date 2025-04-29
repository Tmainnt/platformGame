using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ตำแหน่งที่ต้องการให้กล้องติดตาม
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            // หาตำแหน่งใหม่ของกล้องโดยใช้ฟังก์ชัน SmoothDamp
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.y = transform.position.y;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
