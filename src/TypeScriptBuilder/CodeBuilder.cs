using System;
using System.IO;
using System.Text;

namespace TypeScriptBuilder
{
    public class CodeTextBuilder
    {
        readonly StringBuilder
            _builder;
        int
            _openScopes = 0;
        bool
            _closeLine = false;

        public CodeTextBuilder()
        {
            _builder = new StringBuilder();
        }

        void EmitIdent()
        {
            for (int i = 0; i < this._openScopes; i++)
                _builder.Append('\t');
        }

        void CloseLine()
        {
            if (_closeLine)
            {
                _builder.AppendLine();
                _closeLine = false;
            }
        }

        public void OpenScope()
        {
            CloseLine();

            EmitIdent();
            _builder.AppendLine("{");

            ++_openScopes;
        }

        public void CloseScope()
        {
            if (_openScopes == 0)
                throw new Exception("scope is not open");

            CloseLine();

            --_openScopes;

            EmitIdent();
            _builder.AppendLine("}");
        }

        public void AppendLine(string text = "")
        {
            string
                temp;

            using (var reader = new StringReader(text))
                while ((temp = reader.ReadLine()) != null)
                {
                    EmitIdent();
                    _builder.AppendLine(temp);
                }

            _closeLine = false;
        }

        public void Append(string text)
        {
            _builder.Append(text);
            _closeLine = true;
        }

        public override string ToString()
        {
            if (_openScopes > 0)
                throw new Exception("scope is not closed");

            return _builder.ToString();
        }
    }
}