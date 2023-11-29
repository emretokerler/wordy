namespace Wordy.Levels
{
    public interface ILevel
    {
        void InitializeLevel();
        void StartLevel();
        void SetLevelConfig(LevelData _);
        bool Validate();
    }
}