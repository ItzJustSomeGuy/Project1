﻿using System;
using System.Collections.Generic;
using System.Text;
//01010100 01100101 01110011 01110100 => 'T' + 'e' + 's' + 't'

namespace binaryToTextTest
{
    public class Decoding
    {
        //This method will change a string into binary (to be used with the writing to a text file)
        public static string BinaryToString(string data)
        {
            List<byte> byteList = new List<byte>();
            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
        //This method will change binary to a string which we will use with the reading of the textfile
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char item in data.ToCharArray())
            {
                sb.Append(Convert.ToString(item, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
        //This will return the file's values as strings
        public static string FileToString(string filename)
        {
            string messageDecrypted = "";
            Filehandler fh = new Filehandler();
            List<string> myList = new List<string>();
            myList = fh.Readfile(filename);

            foreach (string line in myList)
            {
                messageDecrypted = messageDecrypted + BinaryToString(line);
            }
            return messageDecrypted;
        }
    }
}
