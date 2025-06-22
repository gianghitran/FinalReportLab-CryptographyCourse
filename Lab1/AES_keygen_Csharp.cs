using System;
using System.Runtime.InteropServices;

class AESInterop
{
    const int AES_KEY_SIZE = 16;
    const int AES_IV_SIZE = 16;

    [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GenerateAESKey")]
    public static extern void GenerateAESKey(byte[] key, byte[] iv);

    [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SaveKeyToFile")]
    public static extern void SaveKeyToFile(string filename, byte[] key, byte[] iv);

    [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LoadKeyFromFile")]
    public static extern void LoadKeyFromFile(string filename, byte[] key, byte[] iv);

    [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AESEncrypt")]
    public static extern void AESEncrypt(byte[] key, byte[] iv, string inputFile, string outputFile, string mode);


    [DllImport("AES_KeyGen.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AESDecrypt")]
    public static extern void AESDecrypt(byte[] key, byte[] iv, string inputFile, string outputFile, string mode);
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            ShowUsage();
            return;
        }

        string command = args[0].ToLower();

        switch (command)
        {
            case "generate":
                if (args.Length != 2)
                {
                    Console.WriteLine("Usage: AESInterop.exe generate <keyfile>");
                    return;
                }
                GenerateKey(args[1]);
                break;
            case "load":
                if (args.Length != 2)
                {
                    Console.WriteLine("Usage: AESInterop.exe load <keyfile>");
                    return;
                }
                byte[] key = new byte[AES_KEY_SIZE];
                byte[] iv = new byte[AES_IV_SIZE];
                LoadKey(args[1], key, iv);
                break;
            case "encrypt":
                if (args.Length != 4)
                {
                    Console.WriteLine("Usage: AESInterop.exe encrypt <keyfile> <inputfile> <outputfile>");
                    return;
                }
                Encrypt(args[1], args[2], args[3]);
                break;

            case "decrypt":
                if (args.Length != 4)
                {
                    Console.WriteLine("Usage: AESInterop.exe decrypt <keyfile> <inputfile> <outputfile>");
                    return;
                }
                Decrypt(args[1], args[2], args[3]);
                break;

            default:
                ShowUsage();
                break;
        }
    }

    static void ShowUsage()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  AESInterop.exe generate <keyfile>");
        Console.WriteLine("  AESInterop.exe load <keyfile>");
        Console.WriteLine("  AESInterop.exe encrypt <keyfile> <inputfile> <outputfile>");
        Console.WriteLine("  AESInterop.exe decrypt <keyfile> <inputfile> <outputfile>");
    }

    static void GenerateKey(string keyfile)
    {
        byte[] key = new byte[AES_KEY_SIZE];
        byte[] iv = new byte[AES_IV_SIZE];

        GenerateAESKey(key, iv);
        Console.WriteLine("Generated Key: " + BitConverter.ToString(key).Replace("-", ""));
        Console.WriteLine("Generated IV : " + BitConverter.ToString(iv).Replace("-", ""));

        SaveKeyToFile(keyfile, key, iv);
        Console.WriteLine("[+] Key and IV saved to: " + keyfile);
    }

    static void LoadKey(string keyfile, byte[] key, byte[] iv)
    {
        LoadKeyFromFile(keyfile, key, iv);
        Console.WriteLine("-> Loaded Key: " + BitConverter.ToString(key).Replace("-", ""));
        Console.WriteLine("-> Loaded IV : " + BitConverter.ToString(iv).Replace("-", ""));
    }

    static void Encrypt(string keyfile, string input, string output)
    {
        byte[] key = new byte[AES_KEY_SIZE];
        byte[] iv = new byte[AES_IV_SIZE];
        LoadKey(keyfile, key, iv);

        AESEncrypt(key, iv, input, output);
        Console.WriteLine($"[+] Encrypted {input} to {output}");
    }

    static void Decrypt(string keyfile, string input, string output)
    {
        byte[] key = new byte[AES_KEY_SIZE];
        byte[] iv = new byte[AES_IV_SIZE];
        LoadKey(keyfile, key, iv);

        AESDecrypt(key, iv, input, output);
        Console.WriteLine($"[+] Decrypted {input} to {output}");
    }
}