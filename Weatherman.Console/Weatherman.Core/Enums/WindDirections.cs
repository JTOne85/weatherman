using System.ComponentModel;

namespace Weatherman.Core.Services
{
    public enum WindDirections
    {
        [Description("North")] N = 0,
        [Description("North North-East")] NNE = 1,
        [Description("North-East")] NE = 2,
        [Description("East North East")] ENE = 3,
        [Description("East")] E = 4,
        [Description("East South East")] ESE = 5,
        [Description("South East")] SE = 6,
        [Description("South South East")] SSE = 7,
        [Description("South")] S = 8,
        [Description("South South West")] SSW = 9,
        [Description("South West")] SW = 10,
        [Description("West South West")] WSW = 11,
        [Description("West")] W = 12,
        [Description("West North West")] WNW = 13,
        [Description("North West")] NW = 14,
        [Description("North North West")] NNW = 15
    }
}