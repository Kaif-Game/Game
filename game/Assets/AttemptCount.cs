using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptCount : MonoBehaviour
{
    [SerializeField] private TextMesh textMesh;

    private void Start()
    {
        textMesh.text = "Attempt " + PlayerLife.GetAttemptCount().ToString();
    }
}
