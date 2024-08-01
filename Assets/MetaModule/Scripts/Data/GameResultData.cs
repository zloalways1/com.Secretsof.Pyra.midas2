namespace Infrastructure.Data
{
    public class GameResultData
    {
        public GameResult Result = GameResult.Undefined;
        public float FinishTime = 0;
        public int Stars = 0;
        public int CurrentLevel;

        public bool IsWin() => Result == GameResult.Win;
        public bool IsLose() => Result == GameResult.Lose;
    }
}