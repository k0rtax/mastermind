using System;
using System.Linq;
using static MastermindLibrary.Enums;
using static MastermindLibrary.Constants;

namespace MastermindLibrary
{
    public static class MastermindGameLogic
    {
        #region methods

        #region private methods

        private static string CheckInput(Farbe?[] secret, Farbe?[] guess)
        {
            if (secret.Length == 0 || guess.Length == 0)
                return NoInputError;

            return secret.Length != guess.Length ? MissmatchError : null;
        }

        private static int GetMissplaced(Farbe?[] secret, Farbe?[] guess)
        {
            int missplaced = 0;

            Farbe?[] distinctArray = guess.Where(x => x != null).Distinct().ToArray();

            for (int i = 0; i < distinctArray.Length; i++)
            {
                int hitsInSecret = Array.FindAll(secret, x => x == distinctArray[i]).Length;
                int hitsInGuess = Array.FindAll(guess, x => x == distinctArray[i]).Length;

                if (hitsInSecret > hitsInGuess)
                    missplaced += hitsInGuess;
                else if (hitsInGuess < hitsInSecret)
                    missplaced += hitsInSecret;
                else
                    missplaced += hitsInSecret;
            }

            return missplaced;
        }

        private static string GetResultString(int wellplaced, int missplaced)
        {
            return wellplaced switch
            {
                0 when missplaced == 0 => //no hits
                    $"no {nameof(wellplaced)} and no {nameof(missplaced)}",
                _ => $"{wellplaced} {nameof(wellplaced)} and {missplaced} {nameof(missplaced)}"
            };
        }

        private static int GetWellplaced(Farbe?[] secret, Farbe?[] guess)
        {
            int wellplaced = 0;

            for (int i = 0; i < guess.Length; i++)
                if (secret[i] == guess[i])
                {
                    secret[i] = null;
                    guess[i] = null;

                    wellplaced++;
                }

            return wellplaced;
        }

        #endregion

        #region public methods

        public static string GetGameResult(Farbe?[] secret, Farbe?[] guess)
        {
            return CheckInput(secret, guess) ?? GetResultString(GetWellplaced(secret, guess), GetMissplaced(secret, guess));
        }

        #endregion

        #endregion
    }
}