using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class VigenereEncrypt: IEncrypt<string>
{
    public const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public string encrypt(string input, string key)
    {
        string encrypted_String = "";
        input = input.ToUpper();
        key = key.ToUpper();
        for (int i = 0, g = 0; i < input.Length && g < key.Length; i++, g++)
        {
            if (g + 1 == key.Length) { g = 0; }
            int offsetModuleIndex = (ALPHABET.IndexOf(input[i]) + ALPHABET.IndexOf(key[g])) % ALPHABET.Length;

            if (offsetModuleIndex < 0)
            {
                encrypted_String += ALPHABET[ALPHABET.Length - (offsetModuleIndex) * -1];
            }
            else
            {
                encrypted_String += ALPHABET[offsetModuleIndex];
            }
        }
        Console.WriteLine(encrypted_String + '\n');
        return encrypted_String;
    }
    public string decrypt(string input,string key) {
        string decrypt_String = "";
        input = input.ToUpper();
        key = key.ToUpper();
        for (int i = 0, g = 0; i < input.Length && g < key.Length; i++, g++)
        {
            if (g + 1 == key.Length) { g = 0; }
            int log = ALPHABET.IndexOf(input[i]);
            int log2 = ALPHABET.IndexOf(key[g]);
            int offsetModuleIndex = (ALPHABET.IndexOf(input[i]) - ALPHABET.IndexOf(key[g])) % ALPHABET.Length; // This crap not worked
            if (offsetModuleIndex < 0)
            {
                decrypt_String += ALPHABET[ALPHABET.Length - (offsetModuleIndex) * -1];
            }
            else
            {
                decrypt_String += ALPHABET[offsetModuleIndex];
            }
        }
        foreach (char c in decrypt_String)
        {
            if (c == 'Z')
            {
                Console.Write(' ');
            }
            else
            {
                Console.Write(c);
            }
        }
        return decrypt_String;
    }
}

