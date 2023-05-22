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
        const string STR = "Join us at the kickoff of our newest hackathon dedicated to building on Internet Computer.In this event, hackers will find all the necessary info regarding participation in this hackathon: important dates, schedule, workshops, sponsors, prizes, submissions and more!The Launch will be followed by a workshop introducing hackers to the Internet Computer and Azle, hosted by Jordan Last of Demergent Labs.About Demergent Labs Demergent Labs is accelerating the adoption of Web3, the Internet Computer, and sustainable open source. Find out more here.About Internet Computer The Internet Computer is a blockchain that enables developers, organizations, and entrepreneurs to build and deploy secure, autonomous, and tamper-proof canisters, an evolution of smart contracts. Find out more here.About Encode ClubEncode Club is a web3 education community learning and building together through fantastic programmes with the leading protocols in the space. Together we organise programmes like education series, bootcamps, hackathons, accelerators both online and in person. We then help our community get jobs and funding for projects and startups. Find out more on our website and join the Discord!";

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
            foreach(var pair in dictionary)
            {
                uint counter = 0;
                foreach(var pair2 in dictionary)
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
            int key = ALPHABET.IndexOf(arr[0]) - ALPHABET.IndexOf('e'); // 'e' || 'a' || 'i' || 't' 
            char[] ss = decrypt(encrypt(STR, 9), key).ToArray<char>();
            for(int i = 0; i < ss.Length; i++)
            {
                if (ss[i] == 'Z')
                {
                    ss[i] = ' ';
                }
            }
            Console.Write(ss);

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
