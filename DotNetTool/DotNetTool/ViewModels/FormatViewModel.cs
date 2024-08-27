using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DotNetTool.ViewModels
{
    public partial class FormatViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string text;

        [ObservableProperty]
        private string result;

        [RelayCommand]
        public void XmlFormat()
        {
            try
            {
                var xml = FormatXml(Text);
                Result = xml.ToString();
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
        }

        [RelayCommand]
        public void JsonFormat()
        {
            try
            {
                var jsonDocument = JsonDocument.Parse(Text);
                var formatJson = JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions()
                {
                    // 整齐打印
                    WriteIndented = true,
                    //重新编码，解决中文乱码问题
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
                Result = formatJson;
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
        }

        [RelayCommand]
        public async Task Copy()
        {
            try
            {
                if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    var clipboard = TopLevel.GetTopLevel(desktop.MainWindow)?.Clipboard;
                    var dataObject = new DataObject();
                    dataObject.Set(DataFormats.Text, Result);
                    await clipboard?.SetDataObjectAsync(dataObject);
                }

            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
        }


        public string FormatXml(string xml)
        {
            XDocument xDoc = XDocument.Parse(xml);
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    xDoc.WriteTo(writer);
                    writer.Flush();
                    return sw.ToString();
                }
            }
        }
    }
}
