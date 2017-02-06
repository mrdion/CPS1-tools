using System;
using System.Drawing;
using CharactorLib.Common;
using CharactorLib.Format;

namespace cps1_32x32
{
    public class cps1_tile32x32 : FormatBase
    {
        public cps1_tile32x32()
		{
            base.FormatText = "[8][8]";
            base.Name = "4BPP CPS1 32x32";
            base.Extension = "cp132";
            base.Author = "Dion";
            base.Url = "http://none";
            // Flags
            base.Readonly = false;
            base.IsCompressed = false;
            base.EnableAdf = true;
            base.IsSupportMirror = false;
            base.IsSupportRotate = false;
            // Settings
            base.ColorBit = 4;
            base.ColorNum = 16;
            base.CharWidth = 32;
            base.CharHeight = 32;
            // Settings for Image Convert
            base.Width = 128;
            base.Height = 128;
		}

        //for displaying
        public override void ConvertMemToChr(Byte[] data, int addr, Bytemap bytemap, int px, int py)
        {
            for (int i = 0; i < base.CharHeight; i++)
            {
                int index = (i * 16) + addr;
                byte num1 = data[index];
                byte num2 = data[index + 1];
                byte num3 = data[index + 2];
                byte num4 = data[index + 3];
                byte num5 = data[index + 4];
                byte num6 = data[index + 5];
                byte num7 = data[index + 6];
                byte num8 = data[index + 7];
                byte num1a = data[index + 8];
                byte num2a = data[index + 9];
                byte num3a = data[index + 10];
                byte num4a = data[index + 11];
                byte num5a = data[index + 12];
                byte num6a = data[index + 13];
                byte num7a = data[index + 14];
                byte num8a = data[index + 15];

                int pointAddress = bytemap.GetPointAddress(px, py + i);
                for (int j = 0; j < 8; j++)
                {
                    byte num9 = (byte)((num2 >> (7 - j)) & 1);
                    byte num10 = (byte)((num4 >> (7 - j)) & 1);
                    byte num11 = (byte)((num6 >> (7 - j)) & 1);
                    byte num12 = (byte)((num8 >> (7 - j)) & 1);
                    bytemap.Data[pointAddress++] = (byte)((((num12 << 3) | (num11 << 2)) | (num10 << 1)) | num9);
                }
                for (int k = 0; k < 8; k++)
                {
                    byte num13 = (byte)((num1 >> (7 - k)) & 1);
                    byte num14 = (byte)((num3 >> (7 - k)) & 1);
                    byte num15 = (byte)((num5 >> (7 - k)) & 1);
                    byte num16 = (byte)((num7 >> (7 - k)) & 1);
                    bytemap.Data[pointAddress++] = (byte)((((num16 << 3) | (num15 << 2)) | (num14 << 1)) | num13);
                }
                for (int j = 0; j < 8; j++)
                {
                    byte num9 = (byte)((num2a >> (7 - j)) & 1);
                    byte num10 = (byte)((num4a >> (7 - j)) & 1);
                    byte num11 = (byte)((num6a >> (7 - j)) & 1);
                    byte num12 = (byte)((num8a >> (7 - j)) & 1);
                    bytemap.Data[pointAddress++] = (byte)((((num12 << 3) | (num11 << 2)) | (num10 << 1)) | num9);
                }
                for (int k = 0; k < 8; k++)
                {
                    byte num13 = (byte)((num1a >> (7 - k)) & 1);
                    byte num14 = (byte)((num3a >> (7 - k)) & 1);
                    byte num15 = (byte)((num5a >> (7 - k)) & 1);
                    byte num16 = (byte)((num7a >> (7 - k)) & 1);
                    bytemap.Data[pointAddress++] = (byte)((((num16 << 3) | (num15 << 2)) | (num14 << 1)) | num13);
                }

            }
        }
 
        //for editing
        public override void ConvertChrToMem(Byte[] data, int addr, Bytemap bytemap, int px, int py)
        {
            for (int i = 0; i < base.CharHeight; i++)
            {
                int index = (i * 16) + addr;
                int pointAddress = bytemap.GetPointAddress(px, py + i);
                byte num1 = 0;
                byte num2 = 0;
                byte num3 = 0;
                byte num4 = 0;
                for (int j = 0; j < 8; j++)
                {
                    byte num9 = (byte)(bytemap.Data[pointAddress++]);
                    byte num20 = (byte)(num9 & 1);
                    byte num21 = (byte)((num9 >> 1) & 1);
                    byte num22 = (byte)((num9 >> 2) & 1);
                    byte num23 = (byte)((num9 >> 3) & 1);
                    num1 = (byte)(num1 | ((byte)(num20 << (7 - j))));
                    num2 = (byte)(num2 | ((byte)(num21 << (7 - j))));
                    num3 = (byte)(num3 | ((byte)(num22 << (7 - j))));
                    num4 = (byte)(num4 | ((byte)(num23 << (7 - j))));
                }
                byte num5 = 0;
                byte num6 = 0;
                byte num7 = 0;
                byte num8 = 0;
                for (int k = 0; k < 8; k++)
                {
                    byte num10 = (byte)(bytemap.Data[pointAddress++]);
                    byte num25 = (byte)(num10 & 1);
                    byte num26 = (byte)((num10 >> 1) & 1);
                    byte num27 = (byte)((num10 >> 2) & 1);
                    byte num28 = (byte)((num10 >> 3) & 1);
                    num5 = (byte)(num5 | ((byte)(num25 << (7 - k))));
                    num6 = (byte)(num6 | ((byte)(num26 << (7 - k))));
                    num7 = (byte)(num7 | ((byte)(num27 << (7 - k))));
                    num8 = (byte)(num8 | ((byte)(num28 << (7 - k))));
                }

                byte num1a = 0;
                byte num2a = 0;
                byte num3a = 0;
                byte num4a = 0;
                for (int j = 0; j < 8; j++)
                {
                    byte num9 = (byte)(bytemap.Data[pointAddress++]);
                    byte num20 = (byte)(num9 & 1);
                    byte num21 = (byte)((num9 >> 1) & 1);
                    byte num22 = (byte)((num9 >> 2) & 1);
                    byte num23 = (byte)((num9 >> 3) & 1);
                    num1a = (byte)(num1a | ((byte)(num20 << (7 - j))));
                    num2a = (byte)(num2a | ((byte)(num21 << (7 - j))));
                    num3a = (byte)(num3a | ((byte)(num22 << (7 - j))));
                    num4a = (byte)(num4a | ((byte)(num23 << (7 - j))));
                }

                byte num5a = 0;
                byte num6a = 0;
                byte num7a = 0;
                byte num8a = 0;
                for (int k = 0; k < 8; k++)
                {
                    byte num10 = (byte)(bytemap.Data[pointAddress++]);
                    byte num25 = (byte)(num10 & 1);
                    byte num26 = (byte)((num10 >> 1) & 1);
                    byte num27 = (byte)((num10 >> 2) & 1);
                    byte num28 = (byte)((num10 >> 3) & 1);
                    num5a = (byte)(num5a | ((byte)(num25 << (7 - k))));
                    num6a = (byte)(num6a | ((byte)(num26 << (7 - k))));
                    num7a = (byte)(num7a | ((byte)(num27 << (7 - k))));
                    num8a = (byte)(num8a | ((byte)(num28 << (7 - k))));
                }
                
                data[index] = num5;
                data[index + 1] = num1;
                data[index + 2] = num6;
                data[index + 3] = num2;
                data[index + 4] = num7;
                data[index + 5] = num3;
                data[index + 6] = num8;
                data[index + 7] = num4;

                data[index + 8] = num5a;
                data[index + 9] = num1a;
                data[index + 10] = num6a;
                data[index + 11] = num2a;
                data[index + 12] = num7a;
                data[index + 13] = num3a;
                data[index + 14] = num8a;
                data[index + 15] = num4a;

            }
        
        }

    }
}
