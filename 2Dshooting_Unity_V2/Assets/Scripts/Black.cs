using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black : Player_control
{
    //탱크가 사용하는 Gun의 좌표, 탱크와 Gun의 벡터를 저장할 변수
    public Transform Gun;

    public Vector2 Tank_gun_vec;

    // Start is called before the first frame update
    void Start()
    {
         //게임 시작 시, rigidbody 2d component 받아오기
        R_b2 = gameObject.GetComponent<Rigidbody2D>();

        //시작 시 main camera 받기
        Cam = Camera.main;

        //생성시, Gun의 transform 정보 가져오기
        Gun = transform.Find("Black_gun");

    }

    // Update is called once per frame
    void Update()
    {
        Move_vector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        R_b2.AddForce(Move_vector.normalized * Player_speed);


        //Mouse의 좌표 받아오기
        Mouse_pos = Cam.ScreenToWorldPoint(Input.mousePosition);

        //Mouse 좌표에서 자신의 좌표 빼서 벡터값 구하기
        Angle2 = Mouse_pos - (Vector2)transform.position;

        //탱크 중앙에서 포신으로 향하는 벡터값을 구하기
        Tank_gun_vec = (Vector2)Gun.transform.position - (Vector2)transform.position;

        //Tank_gun_vec과 Angle2의 각도를 구해, 180보다 적으면 위로, 크면 아래로 회전?
        float A = Quaternion.FromToRotation(Tank_gun_vec, Angle2).eulerAngles.z;

        //각도의 값에 따라 회전 방향을 결정해줌.
        if (A < 1 || A > 359) {
        }

        else if (A > 180) {
            transform.Rotate(0, 0, -Time.deltaTime * Rotation_speed, Space.Self);
        }

        else if (A < 180) {
            transform.Rotate(0, 0, Time.deltaTime * Rotation_speed, Space.Self);
        }
    }

    //충돌 판정
    private void OnTriggerEnter2D(Collider2D other) {
        
    }












}
