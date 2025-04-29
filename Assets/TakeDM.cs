using UnityEngine;
using System.Collections;

public class TakeDB : MonoBehaviour
{
    public Color damageColor = Color.red; // สีที่จะเปลี่ยนเมื่อโดนสิ่งที่ทำให้เกิดความเสี่ยง
    public float damageDuration = 0.5f; // ระยะเวลาที่ต้องการให้เปลี่ยนสี

    private SpriteRenderer characterRenderer; // Renderer ของตัวละคร
    private Color originalColor; // สีเดิมของตัวละคร

    private CameraShake cameraShake; // สคริปต์ CameraShake

    public GameObject StartPoint;

    public GameObject player;

    void Start()
    {
        characterRenderer = GetComponent<SpriteRenderer>();
        originalColor = characterRenderer.material.color; // บันทึกสีเดิม

        // ระบุสคริปต์ CameraShake
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard")) // ตรวจสอบว่าชนกับสิ่งที่เกิดความเสี่ยงหรือไม่
        {
            // เรียกฟังก์ชันที่เปลี่ยนสีและเด้งออกไป
            TakeDamage();

            // เรียกฟังก์ชันที่ทำให้กล้องสั่น
            cameraShake.ShakeCamera(); // ใช้ cameraShake ที่เราได้ประกาศไว้ใน Start() แทน MainCamera

            // ลดเลือดของตัวละคร
            HealthSystem healthSystem = GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(1); // ปรับค่าความเสียหายตามที่ต้องการ
                Debug.Log("Player Get Damage");
            }
        }
    }

    void TakeDamage()
    {
        // เปลี่ยนสีของตัวละครเป็นสีที่กำหนด
        characterRenderer.color = damageColor;

        // เรียก Coroutine สำหรับการกลับสีกลับมาเป็นเดิม
        StartCoroutine(ResetColor());
    }

    IEnumerator ResetColor()
    {
        // รอเป็นเวลาจนกระทั่งเสร็จสิ้นการเปลี่ยนสี
        yield return new WaitForSeconds(damageDuration);
        
        // เปลี่ยนสีกลับเป็นสีเดิม
        characterRenderer.color = originalColor;
    }
}
