using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Metadata;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTool.Converters
{
    public class IconNameConverter : IValueConverter
    {
        public IconNameConverter()
        {
            Paths = new Dictionary<string, StreamGeometry>();
            var source = Application.Current.Resources.MergedDictionaries;
            foreach (ResourceDictionary item in source)
            {
                //var dict = item as IDictionary<string, object>;
                //item.
                foreach (var resource in item)
                {
                    string key = resource.Key.ToString();
                    if (Application.Current.TryFindResource(key, out object obj1))
                    {
                        if (obj1 is StreamGeometry)
                        {
                            Paths.Add(key, obj1 as StreamGeometry);
                        }
                    }
                    else
                    {
                        Paths.Add(resource.Key.ToString(), null);//StreamGeometry
                    }

                }
            }
        }

        [Content]
        public Dictionary<string, StreamGeometry> Paths { get; set; }

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is null) return null;
            if (value is string s)
            {
                return Paths.TryGetValue(s, out var path) ? path : AvaloniaProperty.UnsetValue;
            }
            return AvaloniaProperty.UnsetValue;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
