using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Threading.Tasks;

namespace AzureSpeechToTextTR
{
    class Program
    {
        // LÜTFEN KENDİ BİLGİLERİNİZLE DEĞİŞTİRİN
        // Örn: Anahtar: 1a2b3c4d5e6f7g8h9i0j
        private const string SpeechKey = Environment.GetEnvironmentVariable("AZURE_SPEECH_KEY");

        // Örn: Bölge: polandcentral (Policy'nizin izin verdiği bölge)
        private const string SpeechRegion = Environment.GetEnvironmentVariable("AZURE_SPEECH_REGION");

        static async Task Main(string[] args)
        {
            Console.WriteLine("Türkçe Speech-to-Text Uygulaması Başlatıldı.");

            if (SpeechKey == "SENİN_AZURE_KONUŞMA_SERVİSİ_ANAHTARIN" || SpeechRegion == "SENİN_AZURE_BÖLGE_KİMLİĞİN")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHATA: Lütfen SpeechKey ve SpeechRegion değerlerini güncelleyin!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            await RecognizeSpeechAsync();
            Console.WriteLine("\nİşlem bitti. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }

        static async Task RecognizeSpeechAsync()
        {
            var speechConfig = SpeechConfig.FromSubscription(SpeechKey, SpeechRegion);

            speechConfig.SpeechRecognitionLanguage = "tr-TR";

            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            Console.WriteLine("Lütfen mikrofonunuza Türkçe konuşun (Konuşmayı bitirince duracaktır)...");

            var result = await recognizer.RecognizeOnceAsync();

            switch (result.Reason)
            {
                case ResultReason.RecognizedSpeech:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n[BAŞARILI] Algılanan Türkçe Metin: {result.Text}");
                    break;

                case ResultReason.NoMatch:
                    Console.WriteLine("[BAŞARISIZ] Ses algılandı ancak kelime tanınamadı.");
                    break;

                case ResultReason.Canceled:
                    var cancellation = CancellationDetails.FromResult(result);
                    Console.WriteLine($"[İPTAL EDİLDİ] İptal Sebebi: {cancellation.Reason}");
                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"[AZURE HATA] Detay: {cancellation.ErrorDetails}");
                        Console.WriteLine("Lütfen Anahtar ve Bölgeyi kontrol edin.");
                    }
                    break;
            }
            Console.ResetColor();
        }
    }
}