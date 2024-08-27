using Avalonia.Controls.Templates;
using Avalonia.Controls;
using DotNetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTool
{
    internal class ViewLocator : IDataTemplate
    {
        public Control Build(object data)
        {

            var name = data.GetType().Name!.Replace("ViewModel", "View");
            var type = Type.GetType("DotNetTool.Pages." + name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}
