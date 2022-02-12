using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class Cube : MonoBehaviour
{
    [HideInInspector]
    public int number;
    protected Color color;
    protected TMP_Text[] text;
    private float speed = 0;
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            if (Mathf.Abs(speed) <= 5)
            {
                speed += value;
            }
            else
            {
                speed = transform.position.x > 0 ? 5 : -5;
            }
        }
    }
    protected Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Assign(int _number, Dictionary<int,Color> diction)
    {
        number = _number;
        color = diction[number];
        this.GetComponent<Renderer>().material.color = color;
        text = new TMP_Text[this.transform.childCount];
        for (int i = 0; i < text.Length; i++) {
            Transform child = this.transform.GetChild(i);
            text[i] = child?.GetComponent<TMP_Text>();
            text[i].text = number.ToString();
        }
    }
}
