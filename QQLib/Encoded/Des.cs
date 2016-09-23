using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QQLib.Encoded
{
    public static class Des
    {
        public static string enString(string data)
        {
            string key1 = "c316e97c-9b6c-4f12-82d3-7b97ac21f704";
            string key2 = "f119bd1f-577e-445a-929d-b55a083ce4fb";
            string key3 = "4318db24-a0c7-4c79-9681-2d3d263f95b3";
            string enchex = strEnc(data, key1, key2, key3);
            return enchex;
        }


        public static string strEnc(string data, string firstKey, string secondKey, string thirdKey)
        {

            int leng = data.Length;
            string encData = "";
            byte[][] firstKeyBt = new byte[][] { }, secondKeyBt = new byte[][] { }, thirdKeyBt = new byte[][] { };
            int firstLength = 0, secondLength = 0, thirdLength = 0;

            if (firstKey != null && firstKey != "")
            {
                firstKeyBt = getKeyBytes(firstKey);
                firstLength = firstKeyBt.Length;
            }
            if (secondKey != null && secondKey != "")
            {
                secondKeyBt = getKeyBytes(secondKey);
                secondLength = secondKeyBt.Length;
            }
            if (thirdKey != null && thirdKey != "")
            {
                thirdKeyBt = getKeyBytes(thirdKey);
                thirdLength = thirdKeyBt.Length;
            }

            if (leng > 0)
            {
                if (leng < 4)
                {
                    byte[] bt = strToBt(data);
                    byte[] encByte = new byte[] { };
                    if (firstKey != null && firstKey != "" && secondKey != null && secondKey != "" && thirdKey != null && thirdKey != "")
                    {
                        byte[] tempBt;
                        int x, y, z;
                        tempBt = bt;
                        for (x = 0; x < firstLength; x++)
                        {
                            tempBt = enc(tempBt, firstKeyBt[x]);
                        }
                        for (y = 0; y < secondLength; y++)
                        {
                            tempBt = enc(tempBt, secondKeyBt[y]);
                        }
                        for (z = 0; z < thirdLength; z++)
                        {
                            tempBt = enc(tempBt, thirdKeyBt[z]);
                        }
                        encByte = tempBt;
                    }
                    else
                    {
                        if (firstKey != null && firstKey != "" && secondKey != null && secondKey != "")
                        {
                            byte[] tempBt;
                            int x, y;
                            tempBt = bt;
                            for (x = 0; x < firstLength; x++)
                            {
                                tempBt = enc(tempBt, firstKeyBt[x]);
                            }
                            for (y = 0; y < secondLength; y++)
                            {
                                tempBt = enc(tempBt, secondKeyBt[y]);
                            }
                            encByte = tempBt;
                        }
                        else
                        {
                            if (firstKey != null && firstKey != "")
                            {
                                byte[] tempBt;
                                int x = 0;
                                tempBt = bt;
                                for (x = 0; x < firstLength; x++)
                                {
                                    tempBt = enc(tempBt, firstKeyBt[x]);
                                }
                                encByte = tempBt;
                            }
                        }
                    }
                    encData = bt64ToHex(encByte);
                }
                else
                {
                    int iterator = Convert.ToInt32(leng / 4);
                    int remainder = leng % 4;
                    int i = 0;
                    for (i = 0; i < iterator; i++)
                    {
                        string tempData = data.Substring(i * 4 + 0, 4);
                        byte[] tempByte = strToBt(tempData);
                        byte[] encByte = new byte[] { };
                        if (firstKey != null && firstKey != "" && secondKey != null && secondKey != "" && thirdKey != null && thirdKey != "")
                        {
                            byte[] tempBt;
                            int x, y, z;
                            tempBt = tempByte;
                            for (x = 0; x < firstLength; x++)
                            {
                                tempBt = enc(tempBt, firstKeyBt[x]);
                            }
                            for (y = 0; y < secondLength; y++)
                            {
                                tempBt = enc(tempBt, secondKeyBt[y]);
                            }
                            for (z = 0; z < thirdLength; z++)
                            {
                                tempBt = enc(tempBt, thirdKeyBt[z]);
                            }
                            encByte = tempBt;
                        }
                        else
                        {
                            if (firstKey != null && firstKey != "" && secondKey != null && secondKey != "")
                            {
                                byte[] tempBt;
                                int x, y;
                                tempBt = tempByte;
                                for (x = 0; x < firstLength; x++)
                                {
                                    tempBt = enc(tempBt, firstKeyBt[x]);
                                }
                                for (y = 0; y < secondLength; y++)
                                {
                                    tempBt = enc(tempBt, secondKeyBt[y]);
                                }
                                encByte = tempBt;
                            }
                            else
                            {
                                if (firstKey != null && firstKey != "")
                                {
                                    byte[] tempBt;
                                    int x;
                                    tempBt = tempByte;
                                    for (x = 0; x < firstLength; x++)
                                    {
                                        tempBt = enc(tempBt, firstKeyBt[x]);
                                    }
                                    encByte = tempBt;
                                }
                            }
                        }
                        encData += bt64ToHex(encByte);
                    }
                    if (remainder > 0)
                    {
                        string remainderData = data.Substring(iterator * 4 + 0, remainder);
                        byte[] tempByte = strToBt(remainderData);
                        byte[] encByte = new byte[] { };
                        if (firstKey != null && firstKey != "" && secondKey != null && secondKey != "" && thirdKey != null && thirdKey != "")
                        {
                            byte[] tempBt;
                            int x, y, z;
                            tempBt = tempByte;
                            for (x = 0; x < firstLength; x++)
                            {
                                tempBt = enc(tempBt, firstKeyBt[x]);
                            }
                            for (y = 0; y < secondLength; y++)
                            {
                                tempBt = enc(tempBt, secondKeyBt[y]);
                            }
                            for (z = 0; z < thirdLength; z++)
                            {
                                tempBt = enc(tempBt, thirdKeyBt[z]);
                            }
                            encByte = tempBt;
                        }
                        else
                        {
                            if (firstKey != null && firstKey != "" && secondKey != null && secondKey != "")
                            {
                                byte[] tempBt;
                                int x, y;
                                tempBt = tempByte;
                                for (x = 0; x < firstLength; x++)
                                {
                                    tempBt = enc(tempBt, firstKeyBt[x]);
                                }
                                for (y = 0; y < secondLength; y++)
                                {
                                    tempBt = enc(tempBt, secondKeyBt[y]);
                                }
                                encByte = tempBt;
                            }
                            else
                            {
                                if (firstKey != null && firstKey != "")
                                {
                                    byte[] tempBt;
                                    int x;
                                    tempBt = tempByte;
                                    for (x = 0; x < firstLength; x++)
                                    {
                                        tempBt = enc(tempBt, firstKeyBt[x]);
                                    }
                                    encByte = tempBt;
                                }
                            }
                        }
                        encData += bt64ToHex(encByte);
                    }
                }
            }
            return encData;
        }



        public static byte[][] getKeyBytes(string key)
        {
            int leng = key.Length;
            int iterator = leng / 4;
            int remainder = leng % 4;

            byte[][] keyBytes = new byte[iterator][];
            if (remainder > 0)
            {
                keyBytes = new byte[iterator + 1][];
            }
            int i = 0;
            for (i = 0; i < iterator; i++)
            {

                keyBytes[i] = strToBt(key.Substring(i * 4 + 0, 4));
            }
            if (remainder > 0)
            {
                keyBytes[iterator] = strToBt(key.Substring(i * 4 + 0, remainder));
            }
            return keyBytes;
        }


        //备用
        public static byte[] strToBt111(string str)
        {
            return System.Text.Encoding.ASCII.GetBytes(str);
        }

        public static byte[] strToBt(string str)
        {
            int leng = str.Length;
            byte[] bt = new byte[64];
            char[] strArr = str.ToCharArray();

            if (leng < 4)
            {
                int i = 0, j = 0, p = 0, q = 0;
                for (i = 0; i < leng; i++)
                {
                    byte k = (byte)strArr[i];//charCodeAt
                    for (j = 0; j < 16; j++)
                    {
                        int pow = 1, m = 0;
                        for (m = 15; m > j; m--)
                        {
                            pow *= 2;
                        }
                        bt[16 * i + j] = Convert.ToByte(Convert.ToInt32(k / pow) % 2); // parseInt
                    }
                }
                for (p = leng; p < 4; p++)
                {
                    byte k = 0;
                    for (q = 0; q < 16; q++)
                    {
                        int pow = 1, m = 0;
                        for (m = 15; m > q; m--)
                        {
                            pow *= 2;
                        }
                        bt[16 * p + q] = Convert.ToByte(Convert.ToInt32(k / pow) % 2); // parseInt
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    byte k = (byte)strArr[i];//charCodeAt
                    for (int j = 0; j < 16; j++)
                    {
                        int pow = 1;
                        for (int m = 15; m > j; m--)
                        {
                            pow *= 2;
                        }
                        bt[16 * i + j] = Convert.ToByte(Convert.ToInt32(k / pow) % 2); // parseInt
                    }
                }
            }
            return bt;
        }

        public static string bt4ToHex(string binary)
        {
            string hex = "";
            switch (binary)
            {
                case "0000": hex = "0"; break;
                case "0001": hex = "1"; break;
                case "0010": hex = "2"; break;
                case "0011": hex = "3"; break;
                case "0100": hex = "4"; break;
                case "0101": hex = "5"; break;
                case "0110": hex = "6"; break;
                case "0111": hex = "7"; break;
                case "1000": hex = "8"; break;
                case "1001": hex = "9"; break;
                case "1010": hex = "A"; break;
                case "1011": hex = "B"; break;
                case "1100": hex = "C"; break;
                case "1101": hex = "D"; break;
                case "1110": hex = "E"; break;
                case "1111": hex = "F"; break;
            }
            return hex;
        }

        public static string hexToBt4(string hex)
        {
            string binary = "";
            switch (hex)
            {
                case "0": binary = "0000"; break;
                case "1": binary = "0001"; break;
                case "2": binary = "0010"; break;
                case "3": binary = "0011"; break;
                case "4": binary = "0100"; break;
                case "5": binary = "0101"; break;
                case "6": binary = "0110"; break;
                case "7": binary = "0111"; break;
                case "8": binary = "1000"; break;
                case "9": binary = "1001"; break;
                case "A": binary = "1010"; break;
                case "B": binary = "1011"; break;
                case "C": binary = "1100"; break;
                case "D": binary = "1101"; break;
                case "E": binary = "1110"; break;
                case "F": binary = "1111"; break;
            }
            return binary;
        }

        public static string byteToString(byte[] byteData)
        {
            string str = "";
            for (int i = 0; i < 4; i++)
            {
                int count = 0;
                for (int j = 0; j < 16; j++)
                {
                    int pow = 1;
                    for (int m = 15; m > j; m--)
                    {
                        pow *= 2;
                    }
                    count += byteData[16 * i + j] * pow;
                }
                if (count != 0)
                {
                    str += (char)count;
                }
            }
            return str;
        }

        public static string bt64ToHex(byte[] byteData)
        {
            string hex = "";
            for (int i = 0; i < 16; i++)
            {
                string bt = "";
                for (int j = 0; j < 4; j++)
                {
                    bt += byteData[i * 4 + j];
                }
                hex += bt4ToHex(bt);
            }
            return hex;
        }

        public static string hexToBt64(string hex)
        {
            string binary = "";
            for (int i = 0; i < 16; i++)
            {
                binary += hexToBt4(hex.Substring(i, 1));
            }
            return binary;
        }


        public static byte[] enc(byte[] dataByte, byte[] keyByte)
        {
            byte[][] keys = generateKeys(keyByte);
            byte[] ipByte = initPermute(dataByte);
            byte[] ipLeft = new byte[32];
            byte[] ipRight = new byte[32];
            byte[] tempLeft = new byte[32];

            int i = 0, j = 0, k = 0, m = 0, n = 0;
            for (k = 0; k < 32; k++)
            {
                ipLeft[k] = ipByte[k];
                ipRight[k] = ipByte[32 + k];
            }
            for (i = 0; i < 16; i++)
            {
                for (j = 0; j < 32; j++)
                {
                    tempLeft[j] = ipLeft[j];
                    ipLeft[j] = ipRight[j];
                }
                byte[] key = new byte[48];
                for (m = 0; m < 48; m++)
                {
                    key[m] = keys[i][m];
                }
                byte[] tempRight = xor(pPermute(sBoxPermute(xor(expandPermute(ipRight), key))), tempLeft);
                for (n = 0; n < 32; n++)
                {
                    ipRight[n] = tempRight[n];
                }

            }


            byte[] finalData = new byte[64];
            for (i = 0; i < 32; i++)
            {
                finalData[i] = ipRight[i];
                finalData[32 + i] = ipLeft[i];
            }
            return finallyPermute(finalData);
        }




        public static byte[] initPermute(byte[] originalData)
        {
            byte[] ipByte = new byte[64];
            for (int i = 0, m = 1, n = 0; i < 4; i++, m += 2, n += 2)
            {
                for (int j = 7, k = 0; j >= 0; j--, k++)
                {
                    if (originalData.Length > j * 8 + m)
                    {
                        ipByte[i * 8 + k] = originalData[j * 8 + m];
                        ipByte[i * 8 + k + 32] = originalData[j * 8 + n];
                    }
                }
            }
            return ipByte;
        }


        public static byte[] expandPermute(byte[] rightData)
        {
            byte[] epByte = new byte[48];
            for (int i = 0; i < 8; i++)
            {
                if (i == 0)
                {
                    epByte[i * 6 + 0] = rightData[31];
                }
                else
                {
                    epByte[i * 6 + 0] = rightData[i * 4 - 1];
                }
                epByte[i * 6 + 1] = rightData[i * 4 + 0];
                epByte[i * 6 + 2] = rightData[i * 4 + 1];
                epByte[i * 6 + 3] = rightData[i * 4 + 2];
                epByte[i * 6 + 4] = rightData[i * 4 + 3];
                if (i == 7)
                {
                    epByte[i * 6 + 5] = rightData[0];
                }
                else
                {
                    epByte[i * 6 + 5] = rightData[i * 4 + 4];
                }
            }
            return epByte;
        }

        public static byte[] xor(byte[] byteOne, byte[] byteTwo)
        {
            byte[] xorByte = new byte[byteOne.Length];
            for (int i = 0; i < byteOne.Length; i++)
            {
                xorByte[i] = Convert.ToByte(byteOne[i] ^ byteTwo[i]);
            }
            return xorByte;
        }



        public static byte[] sBoxPermute(byte[] expandByte)
        {

            byte[] sBoxByte = new byte[32];
            string binary = "";
            byte[][] s1 = new byte[4][]{
       new byte[]{14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
        new byte[]{0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
        new byte[]{4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
       new byte[] {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }};

            /* Table - s2 */
            byte[][] s2 = new byte[4][]{
        new byte[]{15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
       new byte[] {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
        new byte[]{0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
        new byte[]{13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }};

            /* Table - s3 */
            byte[][] s3 = new byte[4][]{
       new byte[] {10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
      new byte[]  {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
      new byte[]  {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
      new byte[]  {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }};
            /* Table - s4 */
            byte[][] s4 = new byte[4][]{
       new byte[] {7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
      new byte[]  {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
      new byte[]  {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
      new byte[]  {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }};

            /* Table - s5 */
            byte[][] s5 = new byte[4][]{
       new byte[] {2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
      new byte[]  {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
      new byte[]  {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
      new byte[]  {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 }};

            /* Table - s6 */
            byte[][] s6 = new byte[4][]{
        new byte[]{12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
       new byte[] {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
       new byte[] {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
       new byte[] {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }};

            /* Table - s7 */
            byte[][] s7 = new byte[4][]{
       new byte[] {4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
       new byte[] {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
       new byte[] {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
       new byte[] {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12}};

            /* Table - s8 */
            byte[][] s8 = new byte[4][]{
       new byte[] {13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
       new byte[] {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
       new byte[] {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
       new byte[] {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}};

            for (int m = 0; m < 8; m++)
            {
                int i = 0, j = 0;
                i = expandByte[m * 6 + 0] * 2 + expandByte[m * 6 + 5];
                j = expandByte[m * 6 + 1] * 2 * 2 * 2
                  + expandByte[m * 6 + 2] * 2 * 2
                  + expandByte[m * 6 + 3] * 2
                  + expandByte[m * 6 + 4];
                if (j > 15 || i > 3)
                {
                    binary = getBoxBinary(0);
                }
                else
                {
                    switch (m)
                    {
                        case 0:
                            binary = getBoxBinary(s1[i][j]);
                            break;
                        case 1:
                            binary = getBoxBinary(s2[i][j]);
                            break;
                        case 2:
                            binary = getBoxBinary(s3[i][j]);
                            break;
                        case 3:
                            binary = getBoxBinary(s4[i][j]);
                            break;
                        case 4:
                            binary = getBoxBinary(s5[i][j]);
                            break;
                        case 5:
                            binary = getBoxBinary(s6[i][j]);
                            break;
                        case 6:
                            binary = getBoxBinary(s7[i][j]);
                            break;
                        case 7:
                            binary = getBoxBinary(s8[i][j]);
                            break;
                    }
                }
                sBoxByte[m * 4 + 0] = Convert.ToByte(binary.Substring(0, 1)); // 转byte，本来是转int
                sBoxByte[m * 4 + 1] = Convert.ToByte(binary.Substring(1, 1));
                sBoxByte[m * 4 + 2] = Convert.ToByte(binary.Substring(2, 1));
                sBoxByte[m * 4 + 3] = Convert.ToByte(binary.Substring(3, 1));
            }
            return sBoxByte;
        }

        public static byte[] pPermute(byte[] sBoxByte)
        {
            byte[] pBoxPermute = new byte[32];
            pBoxPermute[0] = sBoxByte[15];
            pBoxPermute[1] = sBoxByte[6];
            pBoxPermute[2] = sBoxByte[19];
            pBoxPermute[3] = sBoxByte[20];
            pBoxPermute[4] = sBoxByte[28];
            pBoxPermute[5] = sBoxByte[11];
            pBoxPermute[6] = sBoxByte[27];
            pBoxPermute[7] = sBoxByte[16];
            pBoxPermute[8] = sBoxByte[0];
            pBoxPermute[9] = sBoxByte[14];
            pBoxPermute[10] = sBoxByte[22];
            pBoxPermute[11] = sBoxByte[25];
            pBoxPermute[12] = sBoxByte[4];
            pBoxPermute[13] = sBoxByte[17];
            pBoxPermute[14] = sBoxByte[30];
            pBoxPermute[15] = sBoxByte[9];
            pBoxPermute[16] = sBoxByte[1];
            pBoxPermute[17] = sBoxByte[7];
            pBoxPermute[18] = sBoxByte[23];
            pBoxPermute[19] = sBoxByte[13];
            pBoxPermute[20] = sBoxByte[31];
            pBoxPermute[21] = sBoxByte[26];
            pBoxPermute[22] = sBoxByte[2];
            pBoxPermute[23] = sBoxByte[8];
            pBoxPermute[24] = sBoxByte[18];
            pBoxPermute[25] = sBoxByte[12];
            pBoxPermute[26] = sBoxByte[29];
            pBoxPermute[27] = sBoxByte[5];
            pBoxPermute[28] = sBoxByte[21];
            pBoxPermute[29] = sBoxByte[10];
            pBoxPermute[30] = sBoxByte[3];
            pBoxPermute[31] = sBoxByte[24];
            return pBoxPermute;
        }


        public static byte[] finallyPermute(byte[] endByte)
        {
            byte[] fpByte = new byte[64];
            fpByte[0] = endByte[39];
            fpByte[1] = endByte[7];
            fpByte[2] = endByte[47];
            fpByte[3] = endByte[15];
            fpByte[4] = endByte[55];
            fpByte[5] = endByte[23];
            fpByte[6] = endByte[63];
            fpByte[7] = endByte[31];
            fpByte[8] = endByte[38];
            fpByte[9] = endByte[6];
            fpByte[10] = endByte[46];
            fpByte[11] = endByte[14];
            fpByte[12] = endByte[54];
            fpByte[13] = endByte[22];
            fpByte[14] = endByte[62];
            fpByte[15] = endByte[30];
            fpByte[16] = endByte[37];
            fpByte[17] = endByte[5];
            fpByte[18] = endByte[45];
            fpByte[19] = endByte[13];
            fpByte[20] = endByte[53];
            fpByte[21] = endByte[21];
            fpByte[22] = endByte[61];
            fpByte[23] = endByte[29];
            fpByte[24] = endByte[36];
            fpByte[25] = endByte[4];
            fpByte[26] = endByte[44];
            fpByte[27] = endByte[12];
            fpByte[28] = endByte[52];
            fpByte[29] = endByte[20];
            fpByte[30] = endByte[60];
            fpByte[31] = endByte[28];
            fpByte[32] = endByte[35];
            fpByte[33] = endByte[3];
            fpByte[34] = endByte[43];
            fpByte[35] = endByte[11];
            fpByte[36] = endByte[51];
            fpByte[37] = endByte[19];
            fpByte[38] = endByte[59];
            fpByte[39] = endByte[27];
            fpByte[40] = endByte[34];
            fpByte[41] = endByte[2];
            fpByte[42] = endByte[42];
            fpByte[43] = endByte[10];
            fpByte[44] = endByte[50];
            fpByte[45] = endByte[18];
            fpByte[46] = endByte[58];
            fpByte[47] = endByte[26];
            fpByte[48] = endByte[33];
            fpByte[49] = endByte[1];
            fpByte[50] = endByte[41];
            fpByte[51] = endByte[9];
            fpByte[52] = endByte[49];
            fpByte[53] = endByte[17];
            fpByte[54] = endByte[57];
            fpByte[55] = endByte[25];
            fpByte[56] = endByte[32];
            fpByte[57] = endByte[0];
            fpByte[58] = endByte[40];
            fpByte[59] = endByte[8];
            fpByte[60] = endByte[48];
            fpByte[61] = endByte[16];
            fpByte[62] = endByte[56];
            fpByte[63] = endByte[24];
            return fpByte;
        }

        public static string getBoxBinary(int i)
        {
            string binary = "";
            switch (i)
            {
                case 0: binary = "0000"; break;
                case 1: binary = "0001"; break;
                case 2: binary = "0010"; break;
                case 3: binary = "0011"; break;
                case 4: binary = "0100"; break;
                case 5: binary = "0101"; break;
                case 6: binary = "0110"; break;
                case 7: binary = "0111"; break;
                case 8: binary = "1000"; break;
                case 9: binary = "1001"; break;
                case 10: binary = "1010"; break;
                case 11: binary = "1011"; break;
                case 12: binary = "1100"; break;
                case 13: binary = "1101"; break;
                case 14: binary = "1110"; break;
                case 15: binary = "1111"; break;
            }
            return binary;
        }

        public static byte[][] generateKeys(byte[] keyByte)
        {
            byte[] key = new byte[56];
            byte[][] keys = new byte[16][];

            keys[0] = new byte[56];
            keys[1] = new byte[56];
            keys[2] = new byte[56];
            keys[3] = new byte[56];
            keys[4] = new byte[56];
            keys[5] = new byte[56];
            keys[6] = new byte[56];
            keys[7] = new byte[56];
            keys[8] = new byte[56];
            keys[9] = new byte[56];
            keys[10] = new byte[56];
            keys[11] = new byte[56];
            keys[12] = new byte[56];
            keys[13] = new byte[56];
            keys[14] = new byte[56];
            keys[15] = new byte[56];


            //keys[0] = new byte[560];
            //keys[1] = new byte[560];
            //keys[2] = new byte[560];
            //keys[3] = new byte[560];
            //keys[4] = new byte[560];
            //keys[5] = new byte[560];
            //keys[6] = new byte[560];
            //keys[7] = new byte[560];
            //keys[8] = new byte[560];
            //keys[9] = new byte[560];
            //keys[10] = new byte[560];
            //keys[11] = new byte[560];
            //keys[12] = new byte[560];
            //keys[13] = new byte[560];
            //keys[14] = new byte[560];
            //keys[15] = new byte[560];

            byte[] loop = new byte[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

            for (int ii = 0; ii < 7; ii++)
            {
                for (int j = 0, k = 7; j < 8; j++, k--)
                {
                    if (keyByte.Length > 8 * k + ii)
                    {
                        key[ii * 8 + j] = keyByte[8 * k + ii];
                    }
                }
            }

            int i = 0;
            for (i = 0; i < 16; i++)
            {
                byte tempLeft = 0;
                byte tempRight = 0;
                for (int j = 0; j < loop[i]; j++)
                {
                    tempLeft = key[0];
                    tempRight = key[28];
                    for (int k = 0; k < 27; k++)
                    {
                        key[k] = key[k + 1];
                        key[28 + k] = key[29 + k];
                    }
                    key[27] = tempLeft;
                    key[55] = tempRight;
                }
                byte[] tempKey = new byte[48];
                tempKey[0] = key[13];
                tempKey[1] = key[16];
                tempKey[2] = key[10];
                tempKey[3] = key[23];
                tempKey[4] = key[0];
                tempKey[5] = key[4];
                tempKey[6] = key[2];
                tempKey[7] = key[27];
                tempKey[8] = key[14];
                tempKey[9] = key[5];
                tempKey[10] = key[20];
                tempKey[11] = key[9];
                tempKey[12] = key[22];
                tempKey[13] = key[18];
                tempKey[14] = key[11];
                tempKey[15] = key[3];
                tempKey[16] = key[25];
                tempKey[17] = key[7];
                tempKey[18] = key[15];
                tempKey[19] = key[6];
                tempKey[20] = key[26];
                tempKey[21] = key[19];
                tempKey[22] = key[12];
                tempKey[23] = key[1];
                tempKey[24] = key[40];
                tempKey[25] = key[51];
                tempKey[26] = key[30];
                tempKey[27] = key[36];
                tempKey[28] = key[46];
                tempKey[29] = key[54];
                tempKey[30] = key[29];
                tempKey[31] = key[39];
                tempKey[32] = key[50];
                tempKey[33] = key[44];
                tempKey[34] = key[32];
                tempKey[35] = key[47];
                tempKey[36] = key[43];
                tempKey[37] = key[48];
                tempKey[38] = key[38];
                tempKey[39] = key[55];
                tempKey[40] = key[33];
                tempKey[41] = key[52];
                tempKey[42] = key[45];
                tempKey[43] = key[41];
                tempKey[44] = key[49];
                tempKey[45] = key[35];
                tempKey[46] = key[28];
                tempKey[47] = key[31];
                switch (i)
                {
                    case 0: for (int m = 0; m < 48; m++) { keys[0][m] = tempKey[m]; } break;
                    case 1: for (int m = 0; m < 48; m++) { keys[1][m] = tempKey[m]; } break;
                    case 2: for (int m = 0; m < 48; m++) { keys[2][m] = tempKey[m]; } break;
                    case 3: for (int m = 0; m < 48; m++) { keys[3][m] = tempKey[m]; } break;
                    case 4: for (int m = 0; m < 48; m++) { keys[4][m] = tempKey[m]; } break;
                    case 5: for (int m = 0; m < 48; m++) { keys[5][m] = tempKey[m]; } break;
                    case 6: for (int m = 0; m < 48; m++) { keys[6][m] = tempKey[m]; } break;
                    case 7: for (int m = 0; m < 48; m++) { keys[7][m] = tempKey[m]; } break;
                    case 8: for (int m = 0; m < 48; m++) { keys[8][m] = tempKey[m]; } break;
                    case 9: for (int m = 0; m < 48; m++) { keys[9][m] = tempKey[m]; } break;
                    case 10: for (int m = 0; m < 48; m++) { keys[10][m] = tempKey[m]; } break;
                    case 11: for (int m = 0; m < 48; m++) { keys[11][m] = tempKey[m]; } break;
                    case 12: for (int m = 0; m < 48; m++) { keys[12][m] = tempKey[m]; } break;
                    case 13: for (int m = 0; m < 48; m++) { keys[13][m] = tempKey[m]; } break;
                    case 14: for (int m = 0; m < 48; m++) { keys[14][m] = tempKey[m]; } break;
                    case 15: for (int m = 0; m < 48; m++) { keys[15][m] = tempKey[m]; } break;
                }
            }
            return keys;
        }
    }
}
