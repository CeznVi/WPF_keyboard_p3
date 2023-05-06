using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Клавиатурный_Тренажерь_Wpf.Lang
{
    class LanguageSwitcher
    {
        private List<string> _langs;

        public LanguageSwitcher(string pathToDir, string maskExt)
        {
            _langs = new List<string>();
            InitLangList(pathToDir, maskExt);
        }

        private void InitLangList(string pathToDir, string maskExt)
        {
            if (!Directory.Exists(pathToDir))
                throw new ArgumentException("Directory not found");

            var fileInDir = Directory.GetFiles(pathToDir);

            Regex regex = new Regex(@"\.(\w{2,3})\.resx$", RegexOptions.IgnoreCase);

            Match match;
            Group groupOne;

            foreach (var oneFilePath in fileInDir)
            {
                if (Path.GetExtension(oneFilePath).ToLower().Equals(maskExt.ToLower()))
                {
                    match = regex.Match(oneFilePath);
                    groupOne = match.Groups[1];
                    _langs.Add(groupOne.Value.Length == 0 ? "en" : groupOne.Value);
                }
            }
        }
        public List<string> Langs
        {
            get { return _langs; }
        }
    }
}
