﻿using System.Linq;
using SkillPrestige.Logging;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace SkillPrestige.Commands
{
    /// <summary>
    /// Represents the command that resets the player's professions after all professions has been removed.
    /// </summary>
    /// // ReSharper disable once UnusedMember.Global - referenced via reflection
    internal class GetAllProfessionsCommand : SkillPrestigeCommand
    {

        public GetAllProfessionsCommand() : base("player_getallprofessions", "Returns a list of all professions the player has.") { }

        protected override bool TestingCommand => true;

        protected override void ApplyCommandEffect(object sender, EventArgsCommand e)
        {
            const string professionSeparator = ", ";
            if (Game1.player == null)
            {
                Log.AsyncR("A game file must be loaded in order to run this command.");
                return;
            }
            Logger.LogInformation("getting list of all professions...");
            foreach (var skill in Skill.AllSkills)
            {
                var allObtainedProfessions = skill.Professions.Where(x => Game1.player.professions.Contains(x.Id));
                var professionNames = string.Join(professionSeparator, allObtainedProfessions.Select(x => x.DisplayName).ToArray()).TrimEnd(professionSeparator.ToCharArray());
                Log.AsyncG($"{skill.Type.Name} skill (level: {skill.GetSkillLevel()}) professions: {professionNames}");
            }
            Logger.LogInformation("list of all professions retrieved.");
        }
    }
}
