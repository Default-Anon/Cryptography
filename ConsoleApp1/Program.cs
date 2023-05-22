using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    internal class Program
    {
        const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string STR = "Let's move further here. We get the values inside the Dictionary.So, let's move further to check out the values the user enters to check whether the matter is inside the Dictionary.Now, here we are, corresponding with the name directly.So,  let's get the words inside the array we want to find and then iterate that array with the Dictionary Key to see the value and return based on the result we get.So, this will get too complex and long a solution for a short statement.So, in all my blogs and articles, I have said to think a little more to make the code optimized and reusable for any other project.So, we can create a function and declare one variable with a loop, and at the runtime of the loop, we initialize it with the value. Confused ...?";

        static Dictionary<char,uint> getCharsCounter(string encrypted_string)
        {
            encrypted_string = encrypted_string.ToUpper();
            Dictionary<char,uint> dictionary = new Dictionary<char,uint>();
            foreach(char s in encrypted_string) { dictionary[s] = 0; }
            foreach(char i in encrypted_string)
            {
                if(i != ' ' &&  i != '!' && i != '.' && i != ',' && i != '?')
                {
                    dictionary[i] += 1;
                }
            }
            return dictionary;
        }
        static char[] getArray(Dictionary<char,uint> dictionary)
        {
            char[] array = new char[dictionary.Count];
            var dict = dictionary.ToList();
            foreach(var pair in dict)
            {
                uint counter = 0;
                foreach(var pair2 in dict)
                {
                    if(pair.Value < pair2.Value)
                    {
                        counter += 1;
                    }
                }
                array[counter] = pair.Key;
            }
            return array;
        }
        static void crackCaesarEncrypt()
        {
            var dictionary = getCharsCounter(encrypt(STR,9));
            var arr = getArray(dictionary);
            int key = ALPHABET.IndexOf(arr[0]) - ALPHABET.IndexOf('e');
            Console.WriteLine(decrypt(encrypt(STR, 9), key));

        }
        
        
        
        
        
        
        
        
        static string decrypt(string encryptText, int key)
        {
            string decrypt = "";
            encryptText = encryptText.ToUpper();
            for (int i = 0; i < encryptText.Length; i++)
            {
                char symbol = encryptText[i];
                int index = ALPHABET.IndexOf(symbol);
                int decryptIndex = index - key;
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
            crackCaesarEncrypt();
            Console.ReadLine();
        }
    }
}
