#include <iostream>
#include <fstream>
#include <string>

// Crypto++ Headers
#include "cryptopp/cryptlib.h"
#include "cryptopp/hex.h"
#include "cryptopp/filters.h"
#include "cryptopp/aes.h"
#include "cryptopp/modes.h"
#include "cryptopp/osrng.h"
#include "cryptopp/files.h"
#include "cryptopp/secblock.h"
#include "cryptopp/xts.h"
#include "cryptopp/gcm.h"
#include "cryptopp/ccm.h"
#include "cryptopp/authenc.h"

using namespace CryptoPP;

// Export macro cho DLL
#ifdef _WIN32
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif

extern "C" EXPORT void GenerateAESKey(byte* key, byte* iv);
extern "C" EXPORT void SaveKeyToFile(const char* filename, const byte* key, const byte* iv);
extern "C" EXPORT void LoadKeyFromFile(const char* filename, byte* key, byte* iv);
extern "C" EXPORT void AESEncrypt(const byte *key, const byte *iv, const char* inputFile, const char* outputFile, const char* mode);
extern "C" EXPORT void AESDecrypt(const byte *key, const byte *iv, const char* inputFile, const char* outputFile, const char* mode);

// Helper: Ghi/Đọc file


void PrintHex(const char *label, const byte *data, size_t length)
{
    std::string encoded;
    StringSource(data, length, true,
                 new HexEncoder(
                     new StringSink(encoded)));
    std::cout << label << ": " << encoded << std::endl;
}

// Tạo key và IV
void GenerateAESKey(byte* key, byte* iv) {
    AutoSeededRandomPool prng;
    prng.GenerateBlock(key, AES::DEFAULT_KEYLENGTH);
    prng.GenerateBlock(iv, AES::BLOCKSIZE);
}

// Lưu key và IV
void SaveKeyToFile(const char* filename, const byte* key, const byte* iv) {
    
    FileSink file(filename, true);
    file.Put(key, AES::DEFAULT_KEYLENGTH);
    file.Put(iv, AES::BLOCKSIZE);
    file.MessageEnd();
    std::cout << "[+] Key and IV saved to file " << filename << std::endl;
}

// Load key và IV
void LoadKeyFromFile(const char* filename, byte* key, byte* iv) {
    try {
        FileSource file(filename, false);
        file.Attach(new ArraySink(key, AES::DEFAULT_KEYLENGTH));
        file.Pump(AES::DEFAULT_KEYLENGTH);

        file.Attach(new ArraySink(iv, AES::BLOCKSIZE));
        file.Pump(AES::BLOCKSIZE);

        PrintHex("Loaded Key", key, AES::DEFAULT_KEYLENGTH);
        PrintHex("Loaded IV", iv, AES::BLOCKSIZE);
    } catch (const CryptoPP::Exception& e) {
        std::cerr << "Error loading key and IV: " << e.what() << std::endl;
    }
}
 
void AESEncrypt(const byte* key, const byte* iv, const char* inputFile, const char* outputFile, const char* mode)
{
     try {
        std::string modeStr(mode);

        if (modeStr == "GCM" || modeStr == "CCM") {
            // GCM / CCM dùng authenticated encryption
            if (modeStr == "GCM") {
                GCM<AES>::Encryption gcm;
                gcm.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv, AES::BLOCKSIZE);

                AuthenticatedEncryptionFilter aef(
                    gcm,
                    new FileSink(outputFile),
                    false, 16 // 16 byte tag
                );

                FileSource fs(inputFile, true, new Redirector(aef));
            }
            else { // CCM
                CCM<AES, 16>::Encryption ccm;
                ccm.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv, AES::BLOCKSIZE);
                ccm.SpecifyDataLengths(0, 0, 0);

                AuthenticatedEncryptionFilter aef(
                    ccm,
                    new FileSink(outputFile),
                    false, 16 // 16 byte tag
                );

                FileSource fs(inputFile, true, new Redirector(aef));
            }
        }
        else {
            StreamTransformation* encryptor = nullptr;

            if (modeStr == "ECB") {
                ECB_Mode<AES>::Encryption* e = new ECB_Mode<AES>::Encryption;
                e->SetKey(key, AES::DEFAULT_KEYLENGTH);
                encryptor = e;
            }
            else if (modeStr == "CBC") {
                CBC_Mode<AES>::Encryption* e = new CBC_Mode<AES>::Encryption;
                e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
                encryptor = e;
            }
            else if (modeStr == "CFB") {
                CFB_Mode<AES>::Encryption* e = new CFB_Mode<AES>::Encryption;
                e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
                encryptor = e;
            }
            else if (modeStr == "OFB") {
                OFB_Mode<AES>::Encryption* e = new OFB_Mode<AES>::Encryption;
                e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
                encryptor = e;
            }
            else if (modeStr == "CTR") {
                CTR_Mode<AES>::Encryption* e = new CTR_Mode<AES>::Encryption;
                e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
                encryptor = e;
            }
            else if (modeStr == "XTS") {
                SecByteBlock tweak(iv, AES::BLOCKSIZE);
                XTS_Mode<AES>::Encryption* e = new XTS_Mode<AES>::Encryption;
                e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH * 2, tweak);
                encryptor = e;
            }
            else {
                std::cerr << "Unsupported mode: " << mode << std::endl;
                return;
            }

            // No padding cho các mode CTR, XTS, OFB, CFB
            FileSource fs(inputFile, true,
                new StreamTransformationFilter(*encryptor,
                    new FileSink(outputFile),
                    BlockPaddingSchemeDef::NO_PADDING));

            delete encryptor;
        }

        std::cout << "[+] Encryption complete using mode " << mode << std::endl;
    }
    catch (const Exception& e) {
        std::cerr << "Encryption error: " << e.what() << std::endl;
    }
}

 
void AESDecrypt(const byte* key, const byte* iv, const char* inputFile, const char* outputFile, const char* mode)
{
    try {
        std::string modeStr(mode);

        if (modeStr == "GCM" || modeStr == "CCM") {
            // Đọc toàn bộ file input
            std::string cipherWithTag;
            FileSource(inputFile, true, new StringSink(cipherWithTag));

            // Tách tag ra cuối (16 bytes)
            if (cipherWithTag.size() < 16) {
                std::cerr << "Input file too small to contain tag" << std::endl;
                return;
            }

            std::string ciphertext = cipherWithTag.substr(0, cipherWithTag.size() - 16);
            std::string tag = cipherWithTag.substr(cipherWithTag.size() - 16);

            if (modeStr == "GCM") {
                GCM<AES>::Decryption gcm;
                gcm.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv, AES::BLOCKSIZE);

                AuthenticatedDecryptionFilter df(
                    gcm,                          // GCM or CCM object
                    new FileSink(outputFile),
                    AuthenticatedDecryptionFilter::THROW_EXCEPTION,
                    16 // tag size in bytes
                );

                df.ChannelPut(AAD_CHANNEL, nullptr, 0);  // optional AAD
                df.ChannelMessageEnd(AAD_CHANNEL);

                // Ciphertext
                df.Put(reinterpret_cast<const byte*>(ciphertext.data()), ciphertext.size());

                // Authentication tag
                df.ChannelPut("MAC", reinterpret_cast<const byte*>(tag.data()), 16);
                df.ChannelMessageEnd("MAC");


                df.MessageEnd(); //
            }
            else { // CCM
                CCM<AES, 16>::Decryption ccm;
                ccm.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv, AES::BLOCKSIZE);
                ccm.SpecifyDataLengths(0, ciphertext.size(), 0);

                AuthenticatedDecryptionFilter df(
                    ccm,                          // GCM or CCM object
                    new FileSink(outputFile),
                    AuthenticatedDecryptionFilter::THROW_EXCEPTION,
                    16 // tag size in bytes
                );

                df.ChannelPut(AAD_CHANNEL, nullptr, 0);  // optional AAD
                df.ChannelMessageEnd(AAD_CHANNEL);

                // Ciphertext
                df.Put(reinterpret_cast<const byte*>(ciphertext.data()), ciphertext.size());

                // Authentication tag
                df.ChannelPut("MAC", reinterpret_cast<const byte*>(tag.data()), 16);
                df.ChannelMessageEnd("MAC");


                df.MessageEnd(); //
            }
        }
        else {
            StreamTransformation* decryptor = nullptr;

            if (modeStr == "ECB") {
                decryptor = new ECB_Mode<AES>::Decryption(key, AES::DEFAULT_KEYLENGTH);
            }
            else if (modeStr == "CBC") {
                decryptor = new CBC_Mode<AES>::Decryption(key, AES::DEFAULT_KEYLENGTH, iv);
            }
            else if (modeStr == "CFB") {
                decryptor = new CFB_Mode<AES>::Decryption(key, AES::DEFAULT_KEYLENGTH, iv);
            }
            else if (modeStr == "OFB") {
                decryptor = new OFB_Mode<AES>::Decryption(key, AES::DEFAULT_KEYLENGTH, iv);
            }
            else if (modeStr == "CTR") {
                decryptor = new CTR_Mode<AES>::Decryption(key, AES::DEFAULT_KEYLENGTH, iv);
            }
            else if (modeStr == "XTS") {
                SecByteBlock tweak(iv, AES::BLOCKSIZE);
                decryptor = new XTS_Mode<AES>::Decryption(key, AES::DEFAULT_KEYLENGTH * 2, tweak);
            }
            else {
                std::cerr << "Unsupported mode: " << mode << std::endl;
                return;
            }

            FileSource(inputFile, true,
                new StreamTransformationFilter(*decryptor,
                    new FileSink(outputFile),
                    BlockPaddingSchemeDef::NO_PADDING));

            delete decryptor;
        }

        std::cout << "[+] Decryption complete using mode " << mode << std::endl;
    }
    catch (const Exception& e) {
        std::cerr << "Decryption error: " << e.what() << std::endl;
    }
}

