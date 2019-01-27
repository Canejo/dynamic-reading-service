using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;

namespace DynamicReadingService.Common.Primitivo
{
    public static class StringExtensions
    {
        public static string RemoveHttpS(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                str = str.Replace("http://", "").Replace("https://", "");
                //Removendo o último caracter
                if (str.Length > 2 && str[str.Length - 1] == '/')
                    str = str.Substring(0, str.Length - 1);

            }
            return str;
        }

        public static bool CheckUrlLValid(this string source)
        {
            //Uri uriResult;
            //return Uri.TryCreate(source, UriKind.Absolute, out uriResult);

            return source.StartsWith("http://") || source.StartsWith("https://");
        }

        public static string CompleteUrl(this string url, string urlBase)
        {
            if (!string.IsNullOrWhiteSpace(url) && !string.IsNullOrWhiteSpace(urlBase) && urlBase.CheckUrlLValid())
            {
                //Url Não valida
                if (!url.CheckUrlLValid())
                {
                    //Completar url com domínio
                    if (url.Length > 0 && url[0] == '/')
                    {
                        Uri uri = new Uri(urlBase);
                        url = uri.Scheme + Uri.SchemeDelimiter + uri.Host + url;
                    }
                }
            }
            return url;
        }

        public static string ReplaceLastOccurrence(this string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }

        public static string GetHostUrl(this string source)
        {
            Uri myuri = new Uri(source);
            string pathQuery = myuri.PathAndQuery;
            string hostName = myuri.ToString().Replace(pathQuery, "");
            return hostName + "/";
        }

        public static string FormatarTextoURL(string textoComAcento)
        {
            string textoSemAcento = textoComAcento;

            if (!string.IsNullOrWhiteSpace(textoSemAcento))
            {
                textoSemAcento = textoSemAcento.Trim();

                StringBuilder sbReturn = new StringBuilder();
                var arrayText = textoSemAcento.Normalize(NormalizationForm.FormD).ToCharArray();

                foreach (char letter in arrayText)
                {
                    if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    {
                        sbReturn.Append(letter);
                    }
                }
                textoSemAcento = sbReturn.ToString();
                textoSemAcento = textoSemAcento.Replace("-", "");
                textoSemAcento = textoSemAcento.Replace(";", "");
                textoSemAcento = textoSemAcento.Replace(" ", "-");
            }

            return textoSemAcento;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string HtmlToText(this string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var root = doc.DocumentNode;
            var sb = new StringBuilder();
            foreach (var node in root.DescendantsAndSelf())
            {
                if (!node.HasChildNodes)
                {
                    string text = node.InnerText;
                    if (!string.IsNullOrEmpty(text))
                        sb.AppendLine(text.Trim());
                }
            }
            return HttpUtility.HtmlDecode(sb.ToString());
        }
    }
}
