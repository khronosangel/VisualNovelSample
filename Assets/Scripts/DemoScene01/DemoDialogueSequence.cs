using System.Collections.Generic;

public class DialogueSequence
{
    public static readonly List<TalkingCharacterModel> Scene01 = new List<TalkingCharacterModel>
    {
        // Convo 1
        new (Constants.MainCharacter2, $"{Constants.MainCharacter1} where are you?"),
        new (Constants.MainCharacter1, $"I'm here {Constants.MainCharacter2}, what's up?"),
        new (Constants.MainCharacter2, $"sentence 3"),
        new (Constants.MainCharacter2, $"sentence 4"),
        new (Constants.MainCharacter1, $"sentence 5"),
        new (Constants.MainCharacter1, $"sentence 6"),
        new (Constants.MainCharacter1, $"sentence 7"),
    };
}

