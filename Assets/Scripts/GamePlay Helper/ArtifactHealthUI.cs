using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArtifactHealthUI : MonoBehaviour
{
    
    [SerializeField]
    private Slider artifactHealthSlider;

    [SerializeField]
    private Artifact artifact;

    private void Start() {
        
        artifactHealthSlider.maxValue = artifact.maxhelth;
        artifactHealthSlider.value = artifact.maxhelth;

    }

    private void Update() {
        
        artifactHealthSlider.value = artifact.helath;

    }
}
