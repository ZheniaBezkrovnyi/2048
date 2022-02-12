using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndCanvas : MonoBehaviour
{
    public TextMesh textMesh;
    [SerializeField] protected Button button;
    [SerializeField] private Text textNumber;
    private static int score;

    public static void WriteTexAndBoom(int scorePlus, Cube cube)
    {
        ScoreAndCanvas scoreAndCanvas = Camera.main.GetComponent<ScoreAndCanvas>();
        score += scorePlus;
        scoreAndCanvas.textNumber.text = score.ToString();
        Boom(cube);
        void Boom(Cube cubee)
        {
            if (cube.number >= 256)
            {
                TextMesh boom = Instantiate(scoreAndCanvas.textMesh, cubee.transform.position, Quaternion.identity);
                boom.color = EntireCube.allCube[cubee.number];
                boom.GetComponent<Animator>().Play("AnimBoom");
            }
        }
    }
}
