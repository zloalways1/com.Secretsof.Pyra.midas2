using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Infrastructure.Components
{
    [RequireComponent(typeof(TMP_Text))]
    [ExecuteInEditMode]
    public class TextDataLoader : MonoBehaviour
    {
        [SerializeField] private string SourceUrl;
        [SerializeField] private bool Load;
        
        private AsyncLazy<string> _loadTextRequest;

        private void Update()
        {
            if (Load)
            {
                Load = false;
                SetText().Forget();
            }
        }

        private async UniTaskVoid SetText()
        {
            TMP_Text text = GetComponent<TMP_Text>();
            text.text = await RequestLoadTextAsync(this.GetCancellationTokenOnDestroy());
        }

        private async UniTask<string> RequestLoadTextAsync(CancellationToken cancellationToken)
        {
            if (IsServerRequestCompleted())
            {
                _loadTextRequest = LoadText(cancellationToken).ToAsyncLazy();
            }

            return await _loadTextRequest.Task;
        }

        private bool IsServerRequestCompleted()
        {
            return _loadTextRequest?.Task.Status.IsCompleted() ?? true;
        }

        private async UniTask<string> LoadText(CancellationToken cancellationToken)
        {
            UnityWebRequest request = UnityWebRequest.Get(SourceUrl);

            await request
                .SendWebRequest()
                .WithCancellation(cancellationToken);
            
            if (request.result == UnityWebRequest.Result.ConnectionError)
                return request.error;
            
            return request.downloadHandler.text;
        }
    }
}