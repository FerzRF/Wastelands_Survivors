using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Получаем ввод по горизонтальной оси (клавиши A и D или стрелки влево и вправо)
        float horizontalInput = Input.GetAxis("Horizontal");
        // Получаем ввод по вертикальной оси (клавиши W и S или стрелки вверх и вниз)
        float verticalInput = Input.GetAxis("Vertical");

        // Вычисляем новое положение объекта, учитывая ввод и скорость перемещения
        Vector3 moveDirectionRaw = new Vector3(horizontalInput, 0f, verticalInput);
        Vector3 moveDirectionTurned = moveDirectionRaw * moveSpeed * Time.deltaTime;
        if (horizontalInput != 0 && verticalInput !=0)
        {
            moveDirectionTurned /= Mathf.Sqrt(2);
        }
        Vector3 moveDirection = Quaternion.Euler(0, 45, 0) * moveDirectionTurned;
        transform.position += moveDirection;
    }
}
