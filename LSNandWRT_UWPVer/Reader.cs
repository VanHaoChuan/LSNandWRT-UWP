using System;
using Windows.Globalization;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;

namespace LaW
{
    namespace Reader
    {
        public class Reader
        {

            public static async void Read(LaW.Word _word, bool _switched, MediaElement _mediaElement)
            {

                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                if (!_switched)
                {
                    ApplicationLanguages.PrimaryLanguageOverride = Language.CurrentInputMethodLanguageTag;
                    var stream = await synthesizer.SynthesizeTextToStreamAsync(_word.WordText);
                    _mediaElement.SetSource(stream, stream.ContentType);
                    _mediaElement.Play();
                }
                else
                {
                    ApplicationLanguages.PrimaryLanguageOverride = Language.CurrentInputMethodLanguageTag;
                    var stream = await synthesizer.SynthesizeTextToStreamAsync(_word.Translation);
                    _mediaElement.SetSource(stream, stream.ContentType);
                    _mediaElement.Play();
                }
            }
            public static async void Read(LaW.Word _word, MediaElement _mediaElement)
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                var stream = await synthesizer.SynthesizeTextToStreamAsync(_word.AdditionalInformation);
                _mediaElement.Language = Language.CurrentInputMethodLanguageTag;
                _mediaElement.SetSource(stream, stream.ContentType);
                ApplicationLanguages.PrimaryLanguageOverride = Language.CurrentInputMethodLanguageTag;
                _mediaElement.Play();


            }

            public static async void Beep(MediaElement _mediaElement)
            {
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                var stream = await speechSynthesizer.SynthesizeTextToStreamAsync("Right");
                _mediaElement.Language = Language.CurrentInputMethodLanguageTag;
                _mediaElement.SetSource(stream, stream.ContentType);
                ApplicationLanguages.PrimaryLanguageOverride = Language.CurrentInputMethodLanguageTag;
                _mediaElement.Play();

            }
        }
    }
}