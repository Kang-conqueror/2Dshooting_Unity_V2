using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{

    //체력, 이동속도, 방어력, 방호력, 회전 속도
    public float Player_hp;

    public float Player_speed;

    public float Player_defence;

    public float Player_protection;

    public float Rotation_speed;

    //한 탄창의 총알 수, 클릭 당 총알 수, 
    public int Megazine;

    public int Click_per_bullets;

    //한 클릭에 총알이 여러발 나갈 때, 총알이 나가는 interval 변수
    public float Multiple_bullet_interval;

    //매 사격 당 interval 조절 변수
    public float Click_interval;

    //Rigidbody2d 와 Vector 값을 받기
    public Rigidbody2D R_b2;

    public Vector3 Move_vector;

    //Mouse 이동에 따른 회전을 위한 변수
    public Camera Cam;

    public Vector2 Mouse_pos;

    //회전과 사격을 위한 Vector2, Vector3
    public Vector2 Angle2;

    public Vector3 Angle3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  






}
