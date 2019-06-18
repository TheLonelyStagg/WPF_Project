using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common;

namespace WPF_Project
{
    public class Skin
    {
        public void Change(SkinEnum Skin, ResourceDictionary resources)
        {
            skin = Skin;
            resources.Clear();
            resources.MergedDictionaries.Clear();
            if (skin == SkinEnum.Default)
                ApplyResources("/Styles;component/Default.xaml", resources);
            else if (skin == SkinEnum.Nightmod)
                ApplyResources("/Styles;component/NightMod.xaml", resources);
            ApplyResources("/Styles;component/Shared.xaml", resources);
        }

        private void ApplyResources(string src, ResourceDictionary resources)
        {
            var dict = new ResourceDictionary() { Source = new Uri(src, UriKind.Relative) };
            foreach (var mergeDict in dict.MergedDictionaries)
            {
                resources.MergedDictionaries.Add(mergeDict);
            }

            foreach (var key in dict.Keys)
            {
                resources[key] = dict[key];
            }
        }

        public SkinEnum skin;
    }
}
