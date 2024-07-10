using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using COMMANDS;

public class CommandTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Running());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Command_Manager.instance.Execute("moveCharDemo", "left");
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            Command_Manager.instance.Execute("moveCharDemo", "right");
    }

    IEnumerator Running()
    {
        yield return Command_Manager.instance.Execute("print");
        yield return Command_Manager.instance.Execute("print_1p", "Hello World!");
        yield return Command_Manager.instance.Execute("print_mp", "Line1", "Line2", "Line3");

        yield return Command_Manager.instance.Execute("lambda");
        yield return Command_Manager.instance.Execute("lambda_1p", "Hello Lambda!");
        yield return Command_Manager.instance.Execute("lambda_mp", "Lambda1", "Lambda2", "Lambda3");

        yield return Command_Manager.instance.Execute("process");
        yield return Command_Manager.instance.Execute("process_1p", "3");
        yield return Command_Manager.instance.Execute("process_mp", "Process Line 1", "Process Line 2", "Process Line 3");
    }
}
