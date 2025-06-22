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
        StreamTransformation* encryptor = nullptr;

        std::string modeStr(mode);
        if (modeStr == "ECB") {
            ECB_Mode<AES>::Encryption* e = new ECB_Mode<AES>::Encryption;
            e->SetKey(key, AES::DEFAULT_KEYLENGTH);
            encryptor = e;
        } else if (modeStr == "CBC") {
            CBC_Mode<AES>::Encryption* e = new CBC_Mode<AES>::Encryption;
            e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
            encryptor = e;
        } else if (modeStr == "CFB") {
            CFB_Mode<AES>::Encryption* e = new CFB_Mode<AES>::Encryption;
            e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
            encryptor = e;
        } else if (modeStr == "OFB") {
            OFB_Mode<AES>::Encryption* e = new OFB_Mode<AES>::Encryption;
            e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
            encryptor = e;
        } else if (modeStr == "CTR") {
            CTR_Mode<AES>::Encryption* e = new CTR_Mode<AES>::Encryption;
            e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
            encryptor = e;
        } if (modeStr == "XTS") {
            SecByteBlock tweak(AES::BLOCKSIZE);
            memcpy(tweak, iv, AES::BLOCKSIZE); 
            XTS_Mode<AES>::Encryption* e = new XTS_Mode<AES>::Encryption;
            e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH * 2, tweak); 
            encryptor = e;
        }
        else if (modeStr == "GCM") {
            GCM<AES>::Encryption* e = new GCM<AES>::Encryption;
            e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv, AES::BLOCKSIZE);
            encryptor = e;
        }
        else if (modeStr == "CCM") {
            CCM<AES, 16>::Encryption* e = new CCM<AES, 16>::Encryption;
            e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv, AES::BLOCKSIZE);
            e->SpecifyDataLengths(0, 0, 0);
            encryptor = e;
        }
        else {
            std::cerr << "Unsupported mode: " << mode << std::endl;
            return;
        }

        FileSource fs(inputFile, true,
            new StreamTransformationFilter(*encryptor,
                new FileSink(outputFile),
                BlockPaddingSchemeDef::PKCS_PADDING));

        delete encryptor;
        std::cout << "[+] Encryption complete using mode " << mode << std::endl;
    }
    catch (const Exception& e) {
        std::cerr << "Encryption error: " << e.what() << std::endl;
    }
}

 
void AESDecrypt(const byte* key, const byte* iv, const char* inputFile, const char* outputFile, const char* mode)
{
    try {
        StreamTransformation* decryptor = nullptr;
        std::string modeStr(mode);

        if (modeStr == "ECB") {
            ECB_Mode<AES>::Decryption* d = new ECB_Mode<AES>::Decryption;
            d->SetKey(key, AES::DEFAULT_KEYLENGTH);
            decryptor = d;
        } else if (modeStr == "CBC") {
            CBC_Mode<AES>::Decryption* d = new CBC_Mode<AES>::Decryption;
            d->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
            decryptor = d;
        } else if (modeStr == "CFB") {
            CFB_Mode<AES>::Decryption* d = new CFB_Mode<AES>::Decryption;
            d->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
            decryptor = d;
        } else if (modeStr == "OFB") {
            OFB_Mode<AES>::Decryption* d = new OFB_Mode<AES>::Decryption;
            d->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
            decryptor = d;
        } else if (modeStr == "CTR") {
            CTR_Mode<AES>::Decryption* d = new CTR_Mode<AES>::Decryption;
            d->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv);
            decryptor = d;
        } if (modeStr == "XTS") {
            SecByteBlock tweak(AES::BLOCKSIZE);
            memcpy(tweak, iv, AES::BLOCKSIZE);
            XTS_Mode<AES>::Decryption* e = new XTS_Mode<AES>::Decryption;
            e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH * 2, tweak);
            encryptor = e;
        }
        else if (modeStr == "GCM") {
            GCM<AES>::Decryption* e = new GCM<AES>::Decryption;
            e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv, AES::BLOCKSIZE);
            encryptor = e;
        }
        else if (modeStr == "CCM") {
            CCM<AES, 16>::Decryption* e = new CCM<AES, 16>::Decryption;
            e->SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, iv, AES::BLOCKSIZE);
            e->SpecifyDataLengths(0, 0, 0); 
            encryptor = e;
        }
        else {
            std::cerr << "Unsupported mode: " << mode << std::endl;
            return;
        }

        FileSource fs(inputFile, true,
            new StreamTransformationFilter(*decryptor,
                new FileSink(outputFile),
                BlockPaddingSchemeDef::PKCS_PADDING));

        delete decryptor;

        std::cout << "[+] Decryption complete using mode " << mode << std::endl;
    }
    catch (const Exception& e) {
        std::cerr << "Decryption error: " << e.what() << std::endl;
    }
}

