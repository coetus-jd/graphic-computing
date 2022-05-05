using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VisualizationPipeline.Assets.Scripts.Enums;

public abstract class BasePipeline : MonoBehaviour
{
    [SerializeField] protected GameObject Objects;
    
    protected GameObject ObjectInPipeline
    {
        get { return GameObject.FindGameObjectWithTag(Tags.ObjectInPipeline); }
    }

    public abstract void Reset();
}
