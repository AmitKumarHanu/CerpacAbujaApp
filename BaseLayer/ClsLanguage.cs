using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.IO;

namespace BaseLayer
{
    
    public class Language
    {
        public const string ALBANIAN = "sq";
        public const string AMHARIC = "am";
        public const string ARABIC = "ar";
        public const string ARMENIAN = "hy";
        public const string AZERBAIJANI = "az";
        public const string BASQUE = "eu";
        public const string BELARUSIAN = "be";
        public const string BENGALI = "bn";
        public const string BIHARI = "bh";
        public const string BULGARIAN = "bg";
        public const string BURMESE = "my";
        public const string CATALAN = "ca";
        public const string CHEROKEE = "chr";
        public const string CHINESE = "zh";
        public const string CHINESE_SIMPLIFIED = "zh-CN";
        public const string CHINESE_TRADITIONAL = "zh-TW";
        public const string CROATIAN = "hr";
        public const string CZECH = "cs";
        public const string DANISH = "da";
        public const string DHIVEHI = "dv";
        public const string DUTCH = "nl";
        public const string ENGLISH = "en";
        public const string ESPERANTO = "eo";
        public const string ESTONIAN = "et";
        public const string FILIPINO = "tl";
        public const string FINNISH = "fi";
        public const string FRENCH = "fr";
        public const string GALICIAN = "gl";
        public const string GEORGIAN = "ka";
        public const string GERMAN = "de";
        public const string GREEK = "el";
        public const string GUARANI = "gn";
        public const string GUJARATI = "gu";
        public const string HEBREW = "iw";
        public const string HINDI = "hi";
        public const string HUNGARIAN = "hu";
        public const string ICELANDIC = "is";
        public const string INDONESIAN = "id";
        public const string INUKTITUT = "iu";
        public const string ITALIAN = "it";
        public const string JAPANESE = "ja";
        public const string KANNADA = "kn";
        public const string KAZAKH = "kk";
        public const string KHMER = "km";
        public const string KOREAN = "ko";
        public const string KURDISH = "ku";
        public const string KYRGYZ = "ky";
        public const string LAOTHIAN = "lo";
        public const string LATVIAN = "lv";
        public const string LITHUANIAN = "lt";
        public const string MACEDONIAN = "mk";
        public const string MALAY = "ms";
        public const string MALAYALAM = "ml";
        public const string MALTESE = "mt";
        public const string MARATHI = "mr";
        public const string MONGOLIAN = "mn";
        public const string NEPALI = "ne";
        public const string NORWEGIAN = "no";
        public const string ORIYA = "or";
        public const string PASHTO = "ps";
        public const string PERSIAN = "fa";
        public const string POLISH = "pl";
        public const string PORTUGUESE = "pt-PT";
        public const string PUNJABI = "pa";
        public const string ROMANIAN = "ro";
        public const string RUSSIAN = "ru";
        public const string SANSKRIT = "sa";
        public const string SERBIAN = "sr";
        public const string SINDHI = "sd";
        public const string SINHALESE = "si";
        public const string SLOVAK = "sk";
        public const string SLOVENIAN = "sl";
        public const string SPANISH = "es";
        public const string SWAHILI = "sw";
        public const string SWEDISH = "sv";
        public const string TAJIK = "tg";
        public const string TAMIL = "ta";
        public const string TAGALOG = "tl";
        public const string TELUGU = "te";
        public const string THAI = "th";
        public const string TIBETAN = "bo";
        public const string TURKISH = "tr";
        public const string UKRAINIAN = "uk";
        public const string URDU = "ur";
        public const string UZBEK = "uz";
        public const string UIGHUR = "ug";
        public const string VIETNAMESE = "vi";
        public const string UNKNOWN = "";

        public Language()
        { //constructor
        }

     public string Translate(string stringToTranslate, string fromLanguage, string toLanguage)
        {
         
        // make sure that the passed string is not empty or null
        if (!String.IsNullOrEmpty(stringToTranslate))
        {
            // per Google's terms of use, we can only translate
           // a string of up to 5000 characters long
            if (stringToTranslate.Length <= 5000)
            {
                const int bufSizeMax = 65536; 
                const int bufSizeMin = 8192;  
    
                try
                {
                    // by default format? is text.  
	                    // so we don't need to send a format? key
                   string requestUri = @"http://ajax.googleapis.com/
				ajax/services/language/translate?v=1.0&q=" + 
                      stringToTranslate + "&langpair=" + 
                        fromLanguage + "%7C" + toLanguage;
    
                   // execute the request and get the response stream
                   HttpWebRequest request = 
				(HttpWebRequest)WebRequest.Create(requestUri);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
    
                    // get the length of the content returned by the request
                    int length = (int)response.ContentLength;
                    int bufSize = bufSizeMin;
    
                    if (length > bufSize)
                        bufSize = length > bufSizeMax ? bufSizeMax : length;
    
                    // allocate buffer and StringBuilder for reading response
                    byte[] buf = new byte[bufSize];
                    StringBuilder sb = new StringBuilder(bufSize);
    
                    // read the whole response
                    while ((length = responseStream.Read(buf, 0, buf.Length)) != 0)
                    {
                        sb.Append(Encoding.UTF8.GetString(buf, 0, length));
                    }
    
                    // the format of the response is like this
                    // {"responseData": {"translatedText":"¿Cómo estás?"}, "responseDetails": null, "responseStatus": 200}
                   // so now let's clean up the response by manipulating the string
                   string translatedText = sb.Remove(0, 36).ToString();
                  translatedText = translatedText.Substring(0, 
					translatedText.IndexOf("\"},"));
    
                    return translatedText;
                }
                catch
                {
                    return "Cannot get the translation.  Please try again later.";
                }
            }
            else
            {
                return "String to translate must be less than 5000 characters long.";
            }
        }
        else
        {
            return "String to translate is empty.";
        }
      }		
  
    }
}
