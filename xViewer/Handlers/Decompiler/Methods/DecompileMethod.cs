using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using xViewer.Handlers.Decompiler.Bytecode;

namespace xViewer.Handlers.Decompiler.Methods
{
    public static class DecompileMethod
    {
        private static string ParseType(Type t)
        {
            switch (t.ToString())
            {
                case "System.Void":
                    return "void";
                case "System.Boolean":
                    return "bool";
                case "System.String":
                    return "string";
                case "System.Int32":
                    return "int";
                case "System.Type":
                    return "Type";
                case "System.TypeCode":
                    return "TypeCode";
                case "System.Action":
                    return "Action";
                case "System.Object":
                    return "object";
                case "System.Drawing.Image":
                    return "Image";
            }
            return t.ToString();
        }

        private static string GetArgs(MethodInfo info)
        {
            string ret = "";

            int i = 0;
            foreach (ParameterInfo pInfo in info.GetParameters())
            {
                i = i + 1;
                if (i == info.GetParameters().Count())
                {
                    string pType = ParseType(pInfo.ParameterType);
                    ret = ret + pType + " ";
                    ret = ret + pInfo.Name + "";
                    if (pInfo.HasDefaultValue)
                    {
                        if (pInfo.DefaultValue == null)
                        {
                            ret = ret + " = null";
                        } else
                        {
                            if (pType == "string")
                            {
                                ret = ret + " = \"" + pInfo.DefaultValue.ToString() + "\"";
                            } else
                            {
                                ret = ret + " = " + pInfo.DefaultValue.ToString();
                            }
                        }
                    }
                } else
                {
                    string pType = ParseType(pInfo.ParameterType);
                    ret = ret + pType + " ";
                    ret = ret + pInfo.Name + ", ";
                    if (pInfo.HasDefaultValue)
                    {
                        if (pInfo.DefaultValue == null)
                        {
                            ret = ret + " = null, ";
                        }
                        else
                        {
                            if (pType == "string")
                            {
                                ret = ret + " = \"" + pInfo.DefaultValue.ToString() + "\", ";
                            } else
                            {
                                ret = ret + " = " + pInfo.DefaultValue.ToString() + ", ";
                            }
                        }
                    }
                }
            }

            return ret;
        }

        private static string DecompileBody(MethodBody body)
        {
            string ret = "/*\n";
            MSIL il = new MSIL(body.GetILAsByteArray());
            string instruct;

            return ret + "\n*/";
        }

        public static string Decompile(MethodInfo info)
        {
            MethodBody body = info.GetMethodBody();
            ParameterInfo pInfo = info.ReturnParameter;
            TypeInfo tInfo = pInfo.ParameterType.GetTypeInfo();

            string ret = "";
            // Regular Signatures
            ret = ret + "// Decompiled by xDec - Custom IL/CIL Decompiler\n";
            ret = ret + "// MN: " + info.Name + " | PM: " + info.IsPrivate + " | MDT: " + info.MetadataToken.ToString() + "\n";

            ret = ret + "\n";
            // time for huge chain of if statements
            if (info.IsPublic)
            {
                ret = ret + "public ";
            }
            if (info.IsPrivate)
            {
                ret = ret + "private ";
            }
            if (info.IsStatic)
            {
                ret = ret + "static ";
            }
            if (info.IsVirtual)
            {
                ret = ret + "virtual ";
            }

            // get return type
            ret = ret + ParseType(info.ReturnType) + " ";

            // put together name and args
            ret = ret + info.Name + "(" + GetArgs(info) + ")\n";
            ret = ret + "{\n";
            ret = ret + DecompileBody(body) + "\n";
            ret = ret + "}";
            //ret = ret + pInfo.

            return ret;
        }
    }
}
