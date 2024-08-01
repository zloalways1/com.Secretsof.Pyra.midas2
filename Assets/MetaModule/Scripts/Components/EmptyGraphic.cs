using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Components
{
    [RequireComponent(typeof(CanvasRenderer))]
    public class EmptyGraphic : Graphic
    {
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }
}