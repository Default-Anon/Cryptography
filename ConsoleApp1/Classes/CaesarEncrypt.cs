using System;
using System.Collections.Generic;
using System.Linq;

public class CaesarEncrypt : IEncrypt<int>
{
    const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string s_STR;
    internal Dictionary<char, uint> getCharsCounter(string encrypted_string)
    {
        encrypted_string = encrypted_string.ToUpper();
        Dictionary<char, uint> dictionary = new Dictionary<char, uint>();
        foreach (char s in encrypted_string) { dictionary[s] = 0; }
        foreach (char i in encrypted_string)
        {
            dictionary[i] += 1;
        }
        return dictionary;
    }
    internal char[] getArray(Dictionary<char, uint> dictionary)
    {
        char[] array = new char[dictionary.Count];
        foreach (var pair in dictionary)
        {
            uint counter = 0;
            foreach (var pair2 in dictionary)
            {
                if (pair.Value < pair2.Value)
                {
                    counter += 1;
                }
            }
            array[counter] = pair.Key;
        }
        return array;
    }
    public void crackCaesarEncrypt(string _encrypted)
    {
        var str = encrypt(_encrypted, 11);
        var dictionary = getCharsCounter(str);
        foreach (var c in str)
        {
            Console.Write(c);
        }
        Console.WriteLine("\n--------------------------------------");
        var arr = getArray(dictionary);
        int key = (ALPHABET.IndexOf(arr[0]) - ALPHABET.IndexOf('E')) % ALPHABET.Length; // 'e' || 'a' || 'i' || 't' 
        char[] ss = decrypt(str, key).ToArray<char>();

    }
    public string decrypt(string encryptText, int key)
    {
        string decrypt = "";
        encryptText = encryptText.ToUpper();
        for (int i = 0; i < encryptText.Length; i++)
        {
            char symbol = encryptText[i];
            int index = ALPHABET.IndexOf(symbol);
            int decryptIndex = (index - key) % ALPHABET.Length;
            decrypt += ALPHABET[decryptIndex < 0 ? ALPHABET.Length + decryptIndex : decryptIndex];
        }

        return decrypt;
    }
    public string encrypt(string planeText, int key)
    {
        string encrypt_text = "";
        planeText = planeText.ToUpper();

        for (int i = 0; i < planeText.Length; i++)
        {
            char a = planeText[i];
            int index = ALPHABET.IndexOf(a);
            if (index >= 0)
            {
                int encryptIndex = (index + key) % ALPHABET.Length;
                encrypt_text += ALPHABET[encryptIndex < 0 ? ALPHABET.Length + encryptIndex : encryptIndex];
            }
        }


        return encrypt_text;
    }
}
