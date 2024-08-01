using Cysharp.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Screens;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Common
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] public RegistrationsBinder RegistrationsBinder;
        [SerializeField] public ServiceLocator ServiceLocator; 
        [SerializeField] public ScreenLocator ScreensLocator;

        private void Awake()
        {
            RegistrationsBinder.BindRegistrations(ServiceLocator);
            
            ScreensLocator.Register();

            ServiceLocator.Initialize();
            
            ScreensLocator.Initialize();
            
            ServiceLocator.PostInitialize();
        }

        private void Start()
        {
            StartAsync().Forget();
        }

        private async UniTaskVoid StartAsync()
        {
            await UniTask.NextFrame();
            
            LoadingScreen loadingScreen = ScreenLocator.GetScreen<LoadingScreen>();
            loadingScreen.Show();
        }

        private void Update()
        {
            ServiceLocator.UpdateServices(Time.deltaTime);
        }
    }
}