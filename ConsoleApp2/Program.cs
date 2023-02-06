using System.Security.Cryptography;
using ConsoleApp2;

var original = "Привет мир";
Console.WriteLine($"Исходный текст: {original}");

using Aes myAes = Aes.Create();

Console.WriteLine($"_____________");

Console.WriteLine("Ключ: " + CryptographyTools.ByteToArrayToString(myAes.Key));
Console.WriteLine("Длина ключа: " + myAes.KeySize + " бит, " + myAes.Key.Length + " байт");

Console.WriteLine("Вектор: " + CryptographyTools.ByteToArrayToString(myAes.IV));
Console.WriteLine("Длина вектора: " + myAes.IV.Length  + " байт");

Console.WriteLine($"_____________");

var shifr = CryptographyTools.EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);
Console.WriteLine("Зашифрованный текст: " + CryptographyTools.ByteToArrayToString(shifr));

var res = CryptographyTools.DecryptStringToBytes_Aes(shifr, myAes.Key, myAes.IV);
Console.WriteLine("Расшифрованный текст: " + res);