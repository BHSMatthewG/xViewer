using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xViewer.Handlers.Decompiler.Bytecode
{
    public class MSIL
    {
        private byte[] IL;
        private BinaryReader breader;
        private BinaryWriter bwriter;

        private enum OpcodeType
        {
            None            = 0,
            Add             = 0x58,
            Addovf          = 0xD6,
            Addovfun        = 0xD7,
            And             = 0x5F,
            BeqInt32Tar     = 0x3B,
            BeqsInt8Tar     = 0x2E,
            BgeInt32Tar     = 0x3C,
            BgeSInt8Tar     = 0x2F,
            BgeUnInt8Tar    = 0x41,
            BgeUnSInt8Tar   = 0x34,
        }

        public MSIL(byte[] ILArray)
        {
            IL = ILArray;
            bwriter = new BinaryWriter(new MemoryStream());
            bwriter.Write(IL);
            breader = new BinaryReader(bwriter.BaseStream);
        }

        private OpcodeType GetOpcode(byte[] il)
        {
            OpcodeType x = OpcodeType.None;
            if (il[0] == 0x58 && il.Count() == 1)
                x = OpcodeType.Add;
            if (il[0] == 0xD6 && il.Count() == 1)
                x = OpcodeType.Addovf;
            if (il[0] == 0xD7 && il.Count() == 1)
                x = OpcodeType.Addovfun;
            if (il[0] == 0x5F && il.Count() == 1)
                x = OpcodeType.And;
            if (il[0] == 0x3B && il.Count() == 1)
                x = OpcodeType.BeqInt32Tar;
            if (il[0] == 0x2E && il.Count() == 1)
                x = OpcodeType.BeqsInt8Tar;
            if (il[0] == 0x3C && il.Count() == 1)
                x = OpcodeType.BgeInt32Tar;
            if (il[0] == 0x2F && il.Count() == 1)
                x = OpcodeType.BgeSInt8Tar;
            if (il[0] == 0x41 && il.Count() == 1)
                x = OpcodeType.BgeUnInt8Tar;
            if (il[0] == 0x34 && il.Count() == 1)
                x = OpcodeType.BgeUnSInt8Tar;
            return x;
        }

        private byte[] readBytes()
        {
            byte[] ILSequence = new byte[] { };

            return ILSequence;
        }

        public string ReadNextInstruction()
        {
            string i = "";

            byte[] ILSequence = readBytes();

            return i;
        }
    }
}
