using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Markup;

namespace calendar
{
    // based on http://summergoat.wordpress.com/2008/07/08/enum-getvalues-markup-extension/
    public class EnumDescExtension : MarkupExtension
    {
        private readonly Type _enumType;

        public EnumDescExtension(Type enumType)
        {
            if (enumType == null)

                throw new ArgumentNullException("enumType");

            if (!enumType.IsEnum)

                throw new ArgumentException("Argument enumType must derive from type Enum.");

            _enumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            List<string> tmpList = new List<string>();

            foreach (var i in Enum.GetValues(_enumType))
            {
                FieldInfo fi = i.GetType().GetField(i.ToString());

                if (fi != null)
                {
                    object[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);

                    if (attrs != null && attrs.Length > 0)
                        tmpList.Add(((DescriptionAttribute)attrs[0]).Description);
                }
            }
            return tmpList.ToArray();
        }
    }
}
