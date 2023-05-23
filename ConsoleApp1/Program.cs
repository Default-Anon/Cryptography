using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static string s_STR = "Trump graduated from the Wharton School with a bachelor's degree in 1968. He became president of his father's real estate business in 1971 and renamed it the Trump Organization. He expanded its operations to building and renovating skyscrapers, hotels, casinos, and golf courses and later started side ventures, mostly by licensing his name. From 2004 to 2015, he co-produced and hosted the reality television series The Apprentice. He and his businesses have been plaintiff or defendant in more than 4,000 state and federal legal actions, including six business bankruptcies.";
        static void Main(string[] args)
        {
            VigenereEncrypt vigenere = new VigenereEncrypt();
            vigenere.decrypt(vigenere.encrypt(s_STR, "Secret"), "Secret");
            Console.ReadLine();
        }
    }
}
