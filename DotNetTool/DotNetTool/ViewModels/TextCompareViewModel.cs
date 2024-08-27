using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTool.ViewModels
{
    public partial class TextCompareViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string text1;

        [ObservableProperty]
        private string text2;
    }
}
