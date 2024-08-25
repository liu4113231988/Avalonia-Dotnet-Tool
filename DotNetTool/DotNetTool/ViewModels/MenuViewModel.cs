using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTool.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>()
        {
            new() { MenuHeader = "工作台", Key = MenuKeys.MenuKeyDashboard,MenuIconName="Dashboard" },
            new() { MenuHeader = "时间转换",Key = MenuKeys.MenuKeyTimestamp,MenuIconName="Timestamp" },
            new() { MenuHeader = "系统设置", Key = MenuKeys.MenuKeySetting , MenuIconName = "Setting"},
        };
        }
    }

    public static class MenuKeys
    {
        public const string MenuKeySetting = "Setting";

        public const string MenuKeyTimestamp = "Timestamp";

        public const string MenuKeyDashboard = "Dashboard";
    }
}
