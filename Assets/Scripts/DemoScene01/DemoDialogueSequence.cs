using System.Collections.Generic;

public class DialogueSequence
{
    public static readonly List<TalkingCharacterModel> Scene01 = new List<TalkingCharacterModel>
    {
        // Convo 1
        new (Constants.MainCharacter2, $"Hey {Constants.MainCharacter1}!  Did you fall asleep at the office again?!"),
        new (Constants.MainCharacter1, $"No. I was just resting my eyes."),
        new (Constants.MainCharacter2, $"Huh? Resting your eyes? Really?"),
        new (Constants.MainCharacter2, $"I see the case files scattered around the room you know. How many times have I told you that you should take better care of yourself. Im-"),
        new (Constants.Phone, $"*Ring* *Ring* *Ring*" ),
        new (Constants.MainCharacter2, $" Let’s continue this talk later, someone’s calling"),
        new (Constants.MainCharacter2, $"Hello, this is the Myth&Mystery Agency, how may I help you?\r\n"),
        new (Constants.Phone, $"*heavy breathing*" ),
        new (Constants.MainCharacter2, $" Hello? Is anyone there?"),
        new (Constants.Phone, $"*slams*" ),
        new (Constants.MainCharacter1, $"What’s wrong?"),
        new (Constants.MainCharacter2, $"It’s nothing. Someone probably misdialed."),
        new (Constants.MainCharacter2, $"Nevermind that. Let’s clean up the office before a client comes in."),
    };

    /*
    public static readonly List<TalkingCharacterModel> Scene02 = new List<TalkingCharacterModel>
    ={
        // Convo 1
        new (Constants.MainCharacter2, $"{Constants.MainCharacter1} where are you?"),
        new (Constants.MainCharacter1, $"I'm here {Constants.MainCharacter2}, what's up?"),
        new (Constants.MainCharacter2, $"sentence 3"),
        new (Constants.MainCharacter2, $"sentence 4"),
        new (Constants.MainCharacter1, $"sentence 5"),
        new (Constants.MainCharacter1, $"sentence 6"),
        new (Constants.MainCharacter1, $"sentence 7"),
    };
    */
}

