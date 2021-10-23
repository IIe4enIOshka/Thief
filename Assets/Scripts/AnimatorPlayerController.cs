using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorPlayerController
{
    public static class Params
    {
        public const string Speed = nameof(Speed);
        public const string Jump = nameof(Jump);
    }

    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string Run = nameof(Run);
        public const string Jump = nameof(Jump);
    }
}
