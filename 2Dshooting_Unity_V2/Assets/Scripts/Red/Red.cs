using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Player_control
{
    //탱크가 사용하는 Gun의 좌표, 탱크와 Gun의 벡터를 저장할 변수
    public Transform Gun;

    //탱크가 사용하는 전용 총알을 받을 변수 저장
    public GameObject Red_bullet;

    public Vector2 Tank_gun_vec;

    //현재 장탄 수를 저장할 변수 선언
    private int Loaded_bullets;

    //탱크마다 사용하는 총의 수가 다르니, 반동 변수를 탱크에서 선언
    public float Recoil_power;

    //재장전을 구현하기 위해 재장전 시점의 시간을 저장할 변수
    public float Reload_time;

    //총알의 탄퍼짐 정도를 우주선에서 선언
    public float Spread_bullet;


    // Start is called before the first frame update
    void Start()
    {
         //게임 시작 시, rigidbody 2d component 받아오기
        R_b2 = gameObject.GetComponent<Rigidbody2D>();

        //시작 시 main camera 받기
        Cam = Camera.main;

        //생성시, Gun의 transform 정보 가져오기
        Gun = transform.Find("Red_gun");

        //Player_control에서 가져온 Megazine(탄창 당 총알 수)를 현재 총알 수에 대입, 바로 사격 가능하게함
        Loaded_bullets = Megazine;

        //
        Reload_time = Time.time - Reload_interval;


        //Coroutine 활성화시키기
        Start_shoot_bullet();

    }

    //탱크의 사격 기능을 넣은 Coroutine 선언
    public void Start_shoot_bullet() {
        StartCoroutine("Shoot_bullet");
    }

    //총알 발사를 담당하는 IEnumerator 함수 
    IEnumerator Shoot_bullet(){

        while (true) {

            //장전된 총알이 남아있을 때
            if (Loaded_bullets > 0) {

                //마우스 클릭을 입력받았을 때
                if (Input.GetMouseButton(0)) {

                    //Player_control에서 가져온 Click_per_bullets, 한 클릭 당 나가는 총알 수만큼
                    //반복문을 돌려 총알을 생성시킴
                    for (int i = 0; i < Click_per_bullets; i++) {

                        //Invoke를 이용해 일정 시간 후 함수가 실행되게 함.
                        //Player_control에서 가져온 Mutiple 변수는, 총알이 한 클릭에 여러발 나갈 때 총알 발사 interval
                        Invoke("Shoot", Multiple_bullet_interval * i);
                        Invoke("Recoil", Multiple_bullet_interval * i);

                    }

                    //장전된 총알 수 -= 1
                    Loaded_bullets -= 1;

                    //Player_control에서 가져온, Click_interval(클릭 interval, 연사 속도 조절 변수)
                    //WaitforSeconds를 통해 interval만큼 대기, if절에 접근하지 않게 함
                    yield return new WaitForSeconds(Click_interval);

                }

                yield return new WaitForSeconds(0f);
            }

            yield return new WaitForSeconds(0f);
        }    
    }
    

    // Update is called once per framew
    void Update()
    {   
        //키보드 입력에 따른 이동 구현
        Move_vector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);        
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


        Reload();

    }


    //시간의 흐름에 따라 자동으로 재장전을 해주는 함수
    //Invoke를 안쓰고 어떻게 구현하지?
    private void Reload() {

        //현재 장전된 총알 수가 최대가 아닌 경우
        if (Loaded_bullets < Megazine) {

            //매 Reload_interval 마다 총알 추가
            if (Time.time - Reload_time >= Reload_interval) {
                
                //총알 추가 후, Time.time으로 현재 시각 대입해주기
                Loaded_bullets += 1;
                Reload_time = Time.time;

            }

        }

    }



    //충돌 판정
    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    //클릭에 반응해서, 포신의 반대 방향으로 반동을 주는 함수
    private void Recoil(){

        //탱크와 포신을 잇는 벡터의 방향을 반대로 하고, 정규화 후 반동력을 곱한 값을 AddForce로 주기
        R_b2.AddForce(-Tank_gun_vec.normalized * Recoil_power);
    }

    //Instantiate로 총알을 생성하는 함수, Gun의 position에서 생성된다
    private void Shoot(){
        Instantiate(Red_bullet, Gun.position, Gun.rotation);
    }




}
