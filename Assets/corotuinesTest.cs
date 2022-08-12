using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corotuinesTest : MonoBehaviour
{
    public int i = 0;

    public bool a = false;
    // Start is called before the first frame update
    IEnumerator myMethod()
    {
        while (i<10000)
        {
            print(i);
            i++;
            yield return new WaitForSeconds(1f);
        }

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (a)
        {
            StartCoroutine(myMethod());
        }
    }
}
