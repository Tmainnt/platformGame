using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 3f; // ค่าเลือดสูงสุด
    public float currentHealth; // ค่าเลือดปัจจุบัน

    public GameObject StartPoint;
    public GameObject player;

    void Start()
    {
        currentHealth = maxHealth; // เริ่มต้นค่าเลือดเป็นค่าสูงสุด
    }

    public void setCheckpoint(Vector3 newCheckpoint){
        StartPoint.transform.position = newCheckpoint;
    }

    // ฟังก์ชันสำหรับการรับความเสียหาย
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        // ตรวจสอบว่าค่าเลือดต่ำกว่าหรือเท่ากับ 0 หรือไม่
        if (currentHealth <= 0)
        {
            Die();
            Debug.Log("Player Die");
            player.transform.position = StartPoint.transform.position;

        }
    }

    // ฟังก์ชันสำหรับเมื่อตัวละครตาย
    void Die()
    {
        // ใส่โค้ดที่ต้องการเมื่อตัวละครตาย
        Debug.Log("Character has died.");
        // สามารถทำอะไรก็ตามที่ต้องการ เช่น เล่นเสียง แสดงอนิเมชั่น ฯลฯ
        currentHealth = maxHealth;
    }
}
