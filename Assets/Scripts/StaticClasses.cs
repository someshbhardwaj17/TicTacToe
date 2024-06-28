using System.Collections.Generic;

public class Combination
{
  public static List<int> winCombinationList = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 3, 6, 9, 2, 5, 8, 1, 4, 7, 1, 5, 9, 3, 5, 7 };
}
public class SceneData
{
  public const int initScene = 0;
  public const int lobbyScene = 1;
  public const int gameScene = 2;
}

public class GameSettings
{
  public enum GameLevel { Easy = 3, Medium = 4, Hard = 5 };
  public enum GameType { SinglePlayer, Multiplayer };

  public enum InputImageType { Cross = 0 , Circle = 1};

  public static GameLevel gameLevel;
  public static GameType gameType;
  public static InputImageType mainPlayerImageType;
  public static InputImageType otherPlayerImageType;
}