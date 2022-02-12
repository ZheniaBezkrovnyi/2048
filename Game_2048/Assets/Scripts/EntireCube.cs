using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class EntireCube : Cube
{
    public static Dictionary<int, Color> allCube = new Dictionary<int, Color>()
    {
        { 2, Color.red },
        { 4, new Color32(128,128,0,255)},
        { 8, Color.green},
        { 16, Color.blue },
        { 32, new Color32(255,128,0,255)},
        { 64, new Color32(128,128,255,255)},
        { 128, new Color32(255,128,128,255)},
        { 256, new Color32(255,0,255,255)},
        { 512, new Color32(128,255,128,255)},
        { 1024, new Color32(64,128,64,255)},
        { 2048, new Color32(0,128,255,255)},
        { 4096, new Color32(32,32,32,255)}
    };
    private void OnEnable()
    {
        int random = Random.Range(1, 4);
        Assign((int)Mathf.Pow(2, random), allCube);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Cube>()?.number == number &&  number != Mathf.Pow(2, allCube.Count)) // если 2 максимального number, ничего не будет при коллизии
        {
            Cube cube = collision.gameObject.GetComponent<Cube>();
            if (rb.velocity.magnitude > cube.GetComponent<Rigidbody>().velocity.magnitude)
            {
                StartCoroutine(Successfull());
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
    private IEnumerator Successfull()
    {
        yield return null; // логично было бы чтобы колизия исполнялась у обоих одновременно, но почемуто так не работает тут, поэтому жду кадр
        Assign(number * 2, allCube);
        ScoreAndCanvas.WriteTexAndBoom(number * 2, this);
        GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.Impulse);
        Explode(3, 150);
        void Explode(float radius, float force)
        {
            Collider[] colliderAll = Physics.OverlapSphere(transform.position, radius);
            for (int i = 0; i < colliderAll.Length; i++)
            {
                Rigidbody rg = colliderAll[i].GetComponent<Rigidbody>();
                if (rg)
                {
                    rg.AddExplosionForce(force, transform.position, radius);
                }
            }
        }
    }
}
