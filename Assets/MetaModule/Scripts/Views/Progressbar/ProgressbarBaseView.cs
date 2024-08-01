using Cysharp.Threading.Tasks;
using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Views
{
    public abstract class ProgressbarBaseView : MetaViewAsync<float>
    {
        private float _showTime;
        
        public override async UniTask Show(float showTime)
        {
            _showTime = showTime;
            await ShowProgress();
        }

        protected abstract void AdjustVisual(float factor);

        private async UniTask ShowProgress()
        {
            float timer = 0;
            while (timer < _showTime)
            {
                float factor = timer / _showTime;
                
                AdjustVisual(factor);

                await UniTask.Yield(PlayerLoopTiming.Update);
                
                timer += Time.deltaTime;
            }
        }
    }
}