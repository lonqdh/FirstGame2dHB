using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image imageFill;
    [SerializeField] Vector3 offset; // offset la do lech giua cai UI nay voi target de khong bi dinh vao character
    float hp;
    float maxHp;

    private Transform target;

    private void Update()
    {
        imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp / maxHp, Time.deltaTime * 5f);
        transform.position = target.position + offset;
    }
    
    //OnInit de khoi tao lai toan bo gia tri khi ta goi no len
    public void OnInit(float maxHp,Transform target)
    {
        this.target = target;
        this.maxHp = maxHp;
        hp = maxHp;
        imageFill.fillAmount = 1;
    }

    public void SetNewHp(float hp)
    {
        this.hp = hp;
        //imageFill.fillAmount = hp / maxHp;
    }
}
