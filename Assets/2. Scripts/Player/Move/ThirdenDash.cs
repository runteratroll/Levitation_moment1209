using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdenDash : MonoBehaviour
{
    public PlayerRoot playerRoot;
    public float dashSpeed;
    public float dashTime;
    public float dashCoolTime;
    private float startCoolTime;
    private StarterAssetsInputs _input;
    // Start is called before the first frame update
    void Start()
    {
        startCoolTime = Time.time;
       

        _input = GetComponent<StarterAssetsInputs>();
        rigid = GetComponent<Rigidbody>();
    }

    Rigidbody rigid;
    // Update is called once per frame
    private void FixedUpdate()
    {
        if(_input.dash && Time.time > startCoolTime + dashCoolTime )
        {
            startCoolTime = Time.time;
            StartCoroutine(Dash());
        }
        _input.dash = false;
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

       // rigid.AddForce(playerRoot.move * dashSpeed, ForceMode.Impulse);
        while (Time.time < startTime + dashTime)
        {

            Debug.Log("대쉬이동");
            playerRoot.camPos.transform.position += playerRoot.move * dashSpeed * Time.deltaTime;
        
             yield return null;
        }
        _input.dash = false;
    }
}
