// See https://aka.ms/new-console-template for more information
using AESEncryption;
using System;
using System.Security.Cryptography;

string original = "Here is some data to encrypt!";

// Create a new instance of the Aes
// class.  This generates a new key and initialization
// vector (IV).
using (Aes myAes = Aes.Create())
{
    var aes = new AES();
    // Encrypt the string to an array of bytes.
    byte[] encrypted = aes.EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

    // Decrypt the bytes to a string.
    string roundtrip = aes.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

    //Display the original data and the decrypted data.
    Console.WriteLine("Original:   {0}", original);
    Console.WriteLine("Encrypted:   {0}", System.Text.Encoding.UTF8.GetString(encrypted, 0, encrypted.Length));
    Console.WriteLine("Round Trip: {0}", roundtrip);
}

