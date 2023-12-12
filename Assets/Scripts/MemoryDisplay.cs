using System.Text;
using Unity.Profiling;
using TMPro;
using UnityEngine;
using System.Collections;

public class MemoryDisplayt : MonoBehaviour
{

    public TextMeshProUGUI memText;

    void Update()
    {
        memText.text = "Memory: " + SystemInfo.systemMemorySize;
    }

}