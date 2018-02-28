using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArea : MonoBehaviour {

    //private float redframes = 0;
    // private float blueframes = 10;

    private float frames = 0;

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 5f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }

    // Update is called once per frame
    void Update () {

        frames = frames + 1;

       /* if (redframes == blueframes)
        {
            float temporary = redframes;
            redframes = blueframes;
            blueframes = redframes;
        }
        
        else if (redframes - blueframes > 10)
        {
            DrawLine(new Vector3(0, 0, -20), transform.position, Color.blue);
            blueframes = blueframes + 1;
        }

        else
        {
            DrawLine(new Vector3(0, 0, -20), transform.position, Color.red);
            redframes = redframes + 1;
        }*/

        if (frames % 20 > 10)
        {
            DrawLine(new Vector3(0, 0, -20), transform.position, Color.blue);
        }
        else
        {
            DrawLine(new Vector3(0, 0, -20), transform.position, Color.red);
        }

		
	}
}
