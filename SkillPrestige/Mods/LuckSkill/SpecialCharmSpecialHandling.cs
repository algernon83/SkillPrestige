﻿using SkillPrestige.Logging;
using SkillPrestige.Professions;
using StardewValley;

namespace SkillPrestige.Mods.LuckSkill
{
    /// <summary>
    /// Special handling for adding the special charm effect from the luck profession.
    /// </summary>
    public class SpecialCharmSpecialHandling : IProfessionSpecialHandling
    {
        public void ApplyEffect()
        {
            Logger.LogInformation("Applying special charm effect.");
            Game1.player.hasSpecialCharm = true;
        }

        public void RemoveEffect()
        {
            Logger.LogInformation("Removing special charm effect.");
            Game1.player.hasSpecialCharm = false;
        }
    }
}
