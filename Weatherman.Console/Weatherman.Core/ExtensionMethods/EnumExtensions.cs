using System.ComponentModel;
using System.Linq;
using Weatherman.Core.Enums;

namespace Weatherman.Core.ExtensionMethods
{
    public static class EnumExtensions
    {
        public static string GetDescription(this WindDirections _enum)
        {
            var memberInfo = typeof(WindDirections).GetMember(_enum.ToString());
            var enumValueMemberInfo = memberInfo.FirstOrDefault(m => m.DeclaringType == typeof(WindDirections));
            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            
            return ((DescriptionAttribute)valueAttributes[0]).Description;
            
        }
    }
}