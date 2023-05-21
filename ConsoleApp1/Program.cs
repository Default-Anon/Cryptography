using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        const string ALPHABET = " !ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string decrypt(string encryptText, int key)
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
        static string encrypt(string planeText, int key)
        {
            string encrypt_text = "";
            planeText = planeText.ToUpper();

            for(int i = 0;i < planeText.Length; i++)
            {
                char a = planeText[i];
                int index = ALPHABET.IndexOf(a);
                int encryptIndex = (index + key) % ALPHABET.Length;
                encrypt_text += ALPHABET[encryptIndex < 0 ? ALPHABET.Length + encryptIndex : encryptIndex];
            }



            return encrypt_text;
        }
        static void Main(string[] args)
        { 

            string msg = "Hello! yz!! Vataguax!";
            string encryptText = encrypt(msg, 3);
            Console.WriteLine(encryptText);
            Console.WriteLine(decrypt(encryptText, 3));
            Console.Read();
        }
    }
}
