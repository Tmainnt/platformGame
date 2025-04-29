using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public Camera MainCamera; // กล้องหลัก
    public float shakeDuration = 0.1f; // ระยะเวลาการสั่น
    public float shakeAmount = 0.05f; // ระดับของการสั่น

    private Vector3 originalCameraPosition; // ตำแหน่งเริ่มต้นของกล้อง

    void Start()
    {
        // เก็บตำแหน่งเริ่มต้นของกล้อง
        if (MainCamera == null)
        {
            MainCamera = Camera.main; // หากไม่ได้กำหนดกล้องหลัก ให้ใช้กล้องหลักของฉัน
        }
        originalCameraPosition = MainCamera.transform.localPosition;
    }

    public void ShakeCamera()
    {
        // เริ่ม Coroutine เพื่อทำการสั่นกล้อง
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // สุ่มตำแหน่งใหม่สำหรับกล้องด้วยการเพิ่มค่าสุ่มในแนวแกน X และ Y
            Vector3 randomPoint = originalCameraPosition + Random.insideUnitSphere * shakeAmount;

            // กำหนดตำแหน่งใหม่ของกล้อง
            MainCamera.transform.localPosition = new Vector3(randomPoint.x, randomPoint.y, originalCameraPosition.z);

            // เพิ่มเวลาผ่านไป
            elapsedTime += Time.deltaTime;

            // รอเฟรมถัดไป
            yield return null;
        }

        // เมื่อเสร็จสิ้นการสั่น กลับสู่ตำแหน่งเริ่มต้นของกล้อง
        MainCamera.transform.localPosition = originalCameraPosition;
    }
}
