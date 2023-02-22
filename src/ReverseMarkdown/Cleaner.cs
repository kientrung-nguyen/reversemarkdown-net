
using System;
using System.Text.RegularExpressions;

namespace ReverseMarkdown
{
    public static class Cleaner
    {
        private static string CleanTagBorders(string content, bool removeComments)
        {
            // content from some html editors such as CKEditor emits newline and tab between tags, clean that up
            if (removeComments)
            {
                content = content.Replace("\n\t", "");
                content = content.Replace(Environment.NewLine + "\t", "");
            }
            return content;
        }

        private static string NormalizeSpaceChars(string content)
        {
            // replace unicode and non-breaking spaces to normal space
            content = Regex.Replace(content, @"[\u0020\u00A0]", " ");
            return content;
        }

        public static string PreTidy(string content, bool removeComments)
        {
            content = NormalizeSpaceChars(content);
            content = CleanTagBorders(content, removeComments);

            return content;
        }
    }
}
