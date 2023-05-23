internal interface IEncrypt<T>
{
    string encrypt(string _msg, T key);
    string decrypt(string _encryptedMsg, T key);
}
