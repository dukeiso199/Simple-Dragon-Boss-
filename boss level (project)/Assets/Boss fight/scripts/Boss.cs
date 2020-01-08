using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    // healthbar
    public int bossHP = 100;
    public Slider healthBar;
    // animation for charge and shake
    private Animator anim;
    public Camera camera;
     private Animator anim2;
    // int to choose attack
    public int chosen;
    //fallin rocks attack
    [SerializeField] GameObject[] fallingPoints;
    public GameObject stone;
    // fire breath 
    public GameObject firebreath;
    public GameObject fireSpawn;
    //// text
    public Text[] signs;
    void Start()
    {
        attackSystem();

        // animator for dragon
        anim = GetComponent<Animator>();
        // animator for camera
        anim2 = camera.GetComponent<Animator>();

    }
    void Update()
    {

        healthBar.value = bossHP;
        if (bossHP == 0)
        {
            anim.Play("death");
            Destroy(gameObject);
        }
        

    }
    //attack system
    public int RandomNumber()
    {
        return Random.Range(1, 5);

    }
    public void attackSystem()
    {
        StartCoroutine(CHooseAttack());

    }
    IEnumerator CHooseAttack()
    {
        chosen = RandomNumber();
        yield return new WaitForSeconds(2);
        BossAttacks(chosen);
        yield return new WaitForSeconds(2);
        anim.Play("Dragonidle");

    }

    public void BossAttacks(int choose)
    {
        switch (choose)
        {
            case 1:
                StartCoroutine(RoarAttack());

                break;
            case 2:
                StartCoroutine(chargeattack());

                break;
            case 3:
                StartCoroutine(FallingStones());

                break;
            case 4:
                StartCoroutine(BreathAttack());

                break;
        }
        

    }
   


    // charge attack code
    
    IEnumerator chargeattack()
    {
        signs[0].gameObject.SetActive(true);

        yield return new WaitForSeconds(1);
        ChargeAttack();
        yield return new WaitForSeconds(2);
        ChargeBack();
        yield return new WaitForSeconds(2);

        anim.Play("DragonIdle");
        yield return new WaitForSeconds(2);
        attackSystem();



    }
    public void ChargeAttack ()
    {
        anim.Play("ChargeAttack");


    }
    public void ChargeBack()
    {
        anim.Play("BackCharge");
        signs[0].gameObject.SetActive(false);

    }


    // roar attack code

    IEnumerator RoarAttack()
    {
        signs[1].gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        Roar();
        yield return new WaitForSeconds(3);
        anim.Play("DragonIdle");

        yield return new WaitForSeconds(2);
        attackSystem();


    }
    public void Roar()
    {
        anim.Play("Roar");
        anim2.Play("ShakeCamera");
        signs[1].gameObject.SetActive(false);



    }

    // falling stones code
    IEnumerator FallingStones()
    {
        signs[2].gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        anim.Play("DragonStomp");
        anim2.Play("Camerashakev");
        yield return new WaitForSeconds(3);
        FallinngDown();
        yield return new WaitForSeconds(3);
        anim.Play("DragonIdle");
        yield return new WaitForSeconds(2);
        attackSystem();


    }
    public void FallinngDown()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(stone, fallingPoints[i].transform.position, Quaternion.identity);
        }
        signs[2].gameObject.SetActive(false);


    }

    // try to make stones fall randomly

    public int RandomNumber2()
    {
        return Random.Range(0, 3);

    }
    //firebreath code
        IEnumerator BreathAttack()
    {
        signs[3].gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        anim.Play("firebreath");
        //Dragonbreath();
        yield return new WaitForSeconds(1);
        anim.Play("DragonIdle");
        yield return new WaitForSeconds(1);
        attackSystem();

    }
    public void Dragonbreath()
    {
        Instantiate(firebreath, fireSpawn.transform.position, Quaternion.identity);
        signs[3].gameObject.SetActive(false);


    }
}
