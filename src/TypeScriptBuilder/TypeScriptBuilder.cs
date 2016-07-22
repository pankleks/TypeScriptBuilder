using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TypeScriptBuilder
{
    public class TypeScriptBuilder
    {
        HashSet<Type> _defined = new HashSet<Type>();
        Stack<Type> _toDefine = new Stack<Type>();
        CodeTextBuilder _builder = new CodeTextBuilder();

        public void ToDefine(Type type)
        {
            if (_defined.Add(type))
                _toDefine.Push(type);
        }

        string WithoutGeneric(Type type)
        {
            return type.Name.Split('`')[0];
        }

        public string TypeName(Type type)
        {
            var
                ti = type.GetTypeInfo();

            if (ti.IsGenericParameter)
                return type.Name;

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    if (ti.IsEnum)
                    {
                        ToDefine(type);
                        return type.Name;
                    }

                    return "number";
                case TypeCode.Decimal:
                case TypeCode.Double:
                    return "number";
                case TypeCode.Boolean:
                    return "boolean";
                case TypeCode.String:
                    return "string";
                case TypeCode.DateTime:
                    return "Date";
                case TypeCode.Object:
                    if (type.IsArray)
                        return TypeName(type) + "[]";
                    if (type == typeof(object))
                        return "Object";

                    if (ti.IsGenericType)
                    {
                        var
                            genericType = ti.GetGenericTypeDefinition();
                        var
                            generics = ti.GetGenericArguments();

                        if (genericType == typeof(List<>))
                            return TypeName(generics[0]) + "[]";

                        if (genericType == typeof(Dictionary<,>))
                        {
                            if (generics[0] != typeof(int) && generics[0] != typeof(string))
                                throw new NotSupportedException($"int or string expected as dictionary key, type {type.FullName}");

                            return $"{{ [index: {TypeName(generics[0])}]: {TypeName(generics[1])} }}";
                        }

                        ToDefine(genericType);

                        return $"{WithoutGeneric(genericType)}<{string.Join(", ", generics.Select(e => TypeName(e)))}>";
                    }

                    ToDefine(type);

                    return type.Name;
                default:
                    throw new NotSupportedException($"type {type.FullName} not supported");
            }
        }
        public void DefineType(Type type)
        {
            var
                ti = type.GetTypeInfo();

            if (ti.IsEnum)
            {
                _builder.AppendLine($"export enum {type.Name}");
                _builder.OpenScope();

                foreach (var e in Enum.GetValues(type))
                    _builder.AppendLine($"{e} = {(int)e},");

                _builder.CloseScope();
                _builder.AppendLine();
                return;
            }

            _builder.Append($"export interface ");

            if (ti.IsGenericType)
            {
                _builder.Append(WithoutGeneric(type));
                _builder.Append("<");

                _builder.Append(string.Join(", ", ti.GetGenericArguments().Select(e => e.Name)));

                _builder.Append(">");
            }
            else
                _builder.Append(type.Name);

            var
                baseType = ti.BaseType;

            if (baseType != null && baseType != typeof(object))
                _builder.AppendLine($" extends {TypeName(baseType)}");

            _builder.OpenScope();

            Type
                fieldType;

            foreach (var fi in type.GetFields())
            {
                if (fi.DeclaringType == type)   // only fields defined in that type
                {
                    var
                        nullable = Nullable.GetUnderlyingType(fi.FieldType);
                    if (nullable != null)
                        fieldType = fi.FieldType.GetGenericArguments()[0];
                    else
                        fieldType = fi.FieldType;

                    _builder.AppendLine($"{fi.Name}{(nullable != null ? "?" : "")}: {TypeName(fieldType)};");
                }
            }

            _builder.CloseScope();
            _builder.AppendLine();
        }

        public override string ToString()
        {
            while (_toDefine.Count > 0)
                DefineType(_toDefine.Pop());

            return _builder.ToString();
        }
    }
}
