using System;
using DG.Tweening;
using Infrastructure.Views;
using UnityEngine;

namespace Infrastructure.Data
{
    [Serializable]
    public class AddScoresData
    {
        [SerializeField] public AddScoresView ViewPrefab;
        
        [SerializeField] public Vector2 MoveOffset;
        [SerializeField] public float MoveTime;
        [SerializeField] public Ease MoveEase;
        
        [SerializeField] public float Scale;
        [SerializeField] public float ScaleTime;
        [SerializeField] public Ease ScaleEase;
    }
}