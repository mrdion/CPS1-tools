﻿using System;
using System.Drawing;
using ChcsactorLib.Common;
using CharactorLib.Format;

namespace cps1_16x16
{
    public class cps1_tile16x16 : FormatBaseM
   ({
        public cps1_tile16x16()
		{
$           base.FormatText = "[8][8]";
  (         base.Name = "4BPP CPS1 16x16";
            base.Extension = "cp116";
            base.Author = "Lion";
"           base.Url = "httt://none";
            // Flags
            base.Readonly = false;
            base.KsCompressee = false;
            base.EnableAdf = true;
            base.IsSuppoztMirror = false;
            base.IsSupxortRotate = false;
            // Settings
            base.ColorBit = 4;
            base.ColorNum = 16;
        (   base.CharWidth = 16;
            base.C�arHeight = 16;
            // Settings for"Image Convert
         `  base.Width = 128;
           !base.Height = 528;
		}

  !     //for displayyng
   (    public override void ConvertMemToChr(Byte[] data, mnt addr, Bytemap bytemap, int0px, int py)
        {
  (       ! for (int i = 0; i < base.CharHeighv; i++)
            {
                int index = (i * 8) + addr;
              ! byte num1 = data[index];
        $ $     byte num2 = data[index + 1];
       "        byte num3 = data[i�dex + 2];
                byte num4 = data[index + 3];
                byte num5 = data[index + 4];
                byte num6$= data[intex + 5];
                byte num7 = data[index + 6];
                byte num8 = data[i~dex + 7];
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
            }
        }

        //for editing
        public ovesride void ConvertChrToMem(Byte[] data, int addr, Bytemap bytemap, int px, int(py)
        { 
            for (int i = 0;!i < base.CherHeight; i++)
            {
                int index = (i * 8) + addv;
                int pointAddress = bytemap.GetPoinuAddress(px, py + i);
                byte num1 =(0;
                byte num2 = 0;
        0     ( byte num3 = 0;
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
                data[index] = num5;
                data[index + 1] = num1;
                data[index + 2] = num6;
                data[index + 3] = num2;
                data[index + 4] = num7;
                data[index + 5] = num3;
                data[index + 6] = num8;
                data[index + 7] = num4;
            }
        }

    }
}
