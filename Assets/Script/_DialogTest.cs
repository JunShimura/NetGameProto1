using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DialogTest : MonoBehaviour
{
    Dialog dialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog = GetComponentInChildren<Dialog>();
        dialog.Open("TEST OPEN");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
