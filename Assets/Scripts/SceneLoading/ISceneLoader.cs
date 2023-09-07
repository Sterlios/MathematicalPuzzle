using MenuScene.Objects;

namespace SceneLoading
{
	public interface ISceneLoader
	{
		void LoadMenu();
		void LoadLevel(LevelConfig level);
	}
}
