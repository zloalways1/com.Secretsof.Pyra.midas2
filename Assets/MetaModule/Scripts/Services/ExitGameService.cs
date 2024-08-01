using UnityEngine;

namespace Infrastructure.Services
{
    public class ExitGameService : IService
    {
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}