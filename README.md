# 🎤 Azure Türkçe Speech-to-Text Uygulaması

Bu proje, **C# Konsol Uygulaması** kullanılarak **Azure AI Konuşma Servisi (Speech Service)** ile Türkçe (tr-TR) konuşmayı gerçek zamanlı olarak metne çeviren (Speech-to-Text) bir demo uygulamasıdır.

Projenin temel amacı, modern bulut servislerini kullanarak yüksek doğrulukta bir ses tanıma işlevinin C# diline nasıl entegre edileceğini göstermektir.

## 🌟 Temel Özellikler

* **Türkçe Tanıma:** Konuşma dili olarak `tr-TR` ayarlanmıştır.
* **Mikrofon Girişi:** Bilgisayarın varsayılan mikrofonundan ses alır.
* **Güvenli Anahtar Yönetimi:** Hassas API anahtarları doğrudan kodda tutulmaz, Çevre Değişkenleri (Environment Variables) kullanılarak gizlenir.
* **Konsol Çıktısı:** Tanınan metni anlık olarak konsola yazar.

## 🛠️ Kullanılan Teknolojiler

* **C#** ve **.NET** (Konsol Uygulaması)
* **Microsoft.CognitiveServices.Speech** (Azure AI Konuşma SDK'sı)

---

## 🔒 GÜVENLİK ve KURULUM TALİMATLARI

Bu proje, güvenlik amacıyla Azure API Anahtarlarını doğrudan kodda (hardcode) tutmaz. Kendi Azure Konuşma kaynağınızdan aldığınız Anahtar ve Bölge bilgilerini sisteme tanıtmanız gerekmektedir.

### 1. NuGet Paketini Yükleme

Projeye aşağıdaki NuGet paketini yükleyin:

```bash
Microsoft.CognitiveServices.Speech
