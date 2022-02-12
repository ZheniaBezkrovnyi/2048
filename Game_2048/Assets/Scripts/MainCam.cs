using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class MainCam : TouchToScreen
{
    [SerializeField] private Cube cube;
    private Cube currentCube;
    void Start()
    {
        button.onClick.AddListener(() =>
            StartCoroutine(CreateCube())
        );
    }
    public void Update()
    {
        Touch(ref currentCube);
        if(currentCube != null)
            currentCube.transform.position = new Vector3(Mathf.Clamp(currentCube.Speed,-3,3), currentCube.transform.position.y, currentCube.transform.position.z);
    }
    IEnumerator CreateCube()
    {
        //ChangeLang();
        for (; ; )
        {
            yield return null;
            if (currentCube == null)
            {
                yield return new WaitForSeconds(1f);
                currentCube = Instantiate(cube, new Vector3(0, cube.transform.localScale.y/2, -5), Quaternion.identity);
            }
        }
    }
}
