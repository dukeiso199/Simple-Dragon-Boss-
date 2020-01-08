using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneLifeCycle : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            
            //StartCoroutine(StoneEnd());
            Destroy(this.gameObject, 6);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator StoneEnd()
    {

        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);

    }
}
